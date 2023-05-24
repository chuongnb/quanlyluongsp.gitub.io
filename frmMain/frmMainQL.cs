using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Diagnostics;

namespace frmMain
{
    public partial class frmMainQL : Form
    {
        //hàm nhận ID đăng nhập từ frmLogin
        public string _messageAccount;
        public string MessageAccount
        {
            get { return _messageAccount; }
            set { _messageAccount = value; }
        }

        public frmMainQL()
        {
            InitializeComponent();
        }

        //Vác class vào xài
        clsNhanVienHC nv = new clsNhanVienHC();
        clsCongNhan cn = new clsCongNhan();
        clsLuongHC lhc = new clsLuongHC();
        clsLuongCN lcn = new clsLuongCN();
        clsAccount acc = new clsAccount();

        //Sự kiện khi load form
        private void frmMain_Load(object sender, EventArgs e)
        {
            //Xóa tabpage phù hợp với ID đăng nhập (phân quyền)
            if (_messageAccount.Contains("CN"))//Nếu là công nhân đăng nhập, ẩn các tab Danh sách & bảng lương hành chính
            {
                tabMain.TabPages.Remove(tabpageDanhSach);
                tabMain.TabPages.Remove(tabpageBangLuongHC);
            }
            else if (_messageAccount.Contains("QL"))//Nếu là quản lý đăng nhập, ẩn tab bảng lương công nhân
                tabMain.TabPages.Remove(tabpageBangLuongCN);
            else if (_messageAccount.Contains("NV"))//Nếu là nhân viên đăng nhập, ẩn các tab Danh sách & bảng lương công nhân
            {
                tabMain.TabPages.Remove(tabpageBangLuongCN);
                tabMain.TabPages.Remove(tabpageDanhSach);
            }
            cboTimKiem.SelectedIndex = 0;//Gán giá trị mặc định cho cbo tìm kiếm
            CreateColumns(lvwDanhSach); // tạo cột cho lvwDanhSach
            CreateColumnsLuongCN(lvwChiTietLuongCN);
            LoadToListView(lvwDanhSach);//Load dữ liệu lên lvwDanhSach
            //Load thông tin lên các tabPage theo Id trên
            if (_messageAccount.Contains("CN"))//Nếu ID đăng nhập là công nhân
                LoadThongTinCNToTabPage(_messageAccount);
            else // Còn lại
                LoadThongTinNVToTabPage(_messageAccount);
        }
        //tính tổng lương nhân viên hành chính
        string TongLuongNV(tblNhanVienHanhChinh n, tblLuongHC lhc)
        {
            float HS = Convert.ToInt32(n.HeSoLuong);//hệ số
            float SNL = Convert.ToInt32(lhc.SoNgayLam);//số ngày làm
            float SGN = Convert.ToInt32(lhc.SoGioNgoai);//số giờ ngoài
            float PC = Convert.ToInt32(n.PhuCap);//phụ cấp
            float TongLuong = HS / 30 * SNL + SGN * (HS / 30 / 24) * 2 + PC;//tổng lương
            return Math.Round(TongLuong, 0).ToString("#,##0");//làm tròn, viết dưới dạng dấu phảy hàng nghìn
        }
        //Tính tổng lương công nhân
        string TongLuongCN(tblCongNhan c, IEnumerable<tblLuongCN> dsLcn)
        {
            float LCD = Convert.ToInt32(c.HeSoLuongCD);//hệ số lương công đoạn
            float TongLuong = 0;//tổng lương
            foreach (tblLuongCN Lcn in dsLcn)//tính tổng lương
            {
                TongLuong += (Convert.ToInt32(Lcn.HeSoCa) * Convert.ToInt32(Lcn.SoLuong));//hệ số ca* số lượng
            }
            TongLuong *= LCD;//*lương công đoạn
            return TongLuong.ToString("#,##0");//viết dưới dạng dấu phảy hàng nghìn
        }
        //Load thông tin lên tabPage
        public void LoadThongTinNVToTabPage(string strID)
        {
            //TabPage bảng lương
            tblNhanVienHanhChinh NV = nv.GetOneNV(strID);//Lấy thông tin theo id
            tblLuongHC LuongHC = lhc.GetLuongThuocNV(strID);//Lấy thông tin lương theo id
            txtHSLuong.Text = NV.HeSoLuong.ToString();//hệ số lương
            txtPhuCap.Text = NV.PhuCap.ToString();//phụ cấp
            txtSoNgayLam.Text = LuongHC.SoNgayLam.ToString();//số ngày làm
            txtSoGioNgoai.Text = LuongHC.SoGioNgoai.ToString();//số giờ ngoài
            txtTongLuongNV.Text = TongLuongNV(NV, lhc.GetLuongThuocNV(strID));//tổng lương
            //TabPage Tài khoản
            txtIDNV.Text = NV.IDNV;//lấy ID
            txtHoTenNV.Text = NV.HoTen;//lấy họ tên
            if (NV.GioiTinh.Contains("Nam"))//lấy giới tính
                radNamNV.Checked = true;
            else
                radNuNV.Checked = true;
            txtNgaySinhNV.Text = String.Format("{0:dd-MM-yyyy}", NV.NgaySinh);//lấy ngày sinh
            txtNgayBDLamNV.Text = String.Format("{0:dd-MM-yyyy}", NV.NgayBatDau);//lấy ngày bắt đầu làm
        }
        //load thông tin công nhân lên tabpage
        public void LoadThongTinCNToTabPage(string strID)
        {
            //TabPage bảng lương
            tblCongNhan CN = cn.GetOneCN(strID);//Lấy thông tin theo id
            IEnumerable<tblLuongCN> LuongCN = lcn.GetLCNThuocCN(strID);//Lấy thông tin lương theo id
            txtCongDoan.Text = CN.CongDoan.ToString();//lấy công đoạn
            txtHSLuongCD.Text = CN.HeSoLuongCD.ToString();//lấy hệ số lương công đoạn
            txtTongLuongCN.Text = TongLuongCN(CN, lcn.GetLCNThuocCN(CN.IDCN));//tính tổng lương
            lvwChiTietLuongCN.Items.Clear();//dọn chỗ để load lên
            ListViewItem ItemLCN;//tạo item
            int i = 0;
            foreach (tblLuongCN Lcn in LuongCN)//load
            {
                i += 1;
                ItemLCN = CreateItem(Lcn);//tạo item = 1 phần tử trong danh sách thông tin lương
                lvwChiTietLuongCN.Items.Add(ItemLCN);//add vào list view
            }
            //TabPage Tài khoản
            txtIDCN.Text = CN.IDCN;//lấy id
            txtHoTenCN.Text = CN.HoTen;//lấy họ tên
            if (CN.GioiTinh.Contains("Nam"))//lấy giới tính
                radNamCN.Checked = true;
            else
                radNuCN.Checked = true;
            txtNgaySinhCN.Text = String.Format("{0:dd-MM-yyyy}", CN.NgaySinh);//lấy ngày sinh
            txtNgayBDLamCN.Text = String.Format("{0:dd-MM-yyyy}", CN.NgayBatDau);//lấy ngày bắt đầu làm
        }
        //Tạo item cho lvwChiTietLuongCN
        ListViewItem CreateItem(tblLuongCN lcn)
        {
            ListViewItem lvwItem;//tạo biến kiểu listviewitem
            lvwItem = new ListViewItem(lcn.HeSoCa.ToString());//điền thông tin cột đầu tiên
            lvwItem.SubItems.Add(lcn.SoLuong.ToString());//điền thông tin cột thứ 2
            lvwItem.Tag = lcn;//nhet vao de su dung muc dich khac (mu dich 1)
            return lvwItem;
        }
        // Tạo cột cho lvwDanhSach
        public void CreateColumns(ListView lvw)
        {
            lvw.Columns.Clear();
            lvw.View = View.Details;
            lvw.GridLines = true;
            lvw.FullRowSelect = true;
            lvw.Columns.Add("ID",118);
            lvw.Columns.Add("Họ tên",286);
            lvw.Columns.Add("Giới tính", 134);
            lvw.Columns.Add("Ngày sinh", 193);
            lvw.Columns.Add("Ngày bắt đầu làm", 193);
            lvw.Columns.Add("Tổng lương", 240, HorizontalAlignment.Right);
        }

        /*//Vẽ Item cho tabControl
        private void tabMain_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;

            // Thêm tabPage từ Colecction
            TabPage _tabPage = tabMain.TabPages[e.Index];

            // Lấy kích thước cho tabPage
            Rectangle _tabBounds = tabMain.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {

                // Tạo sự khác biệt cho tab được chọn
                _textBrush = new SolidBrush(Color.Black);
                g.FillRectangle(Brushes.LightBlue, e.Bounds);
            }
            else
            {
                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            // Sử dụng font cho tab
            Font _tabFont = new Font("Arial", (float)12.0, GraphicsUnit.Pixel);

            // Căn lề cho chữ trong tab
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Near;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString("             "+_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));

            // Thêm icon vào tab
            Image img = tabMain.ImageList.Images[tabMain.TabPages[e.Index].ImageIndex+1];
            float _y = ((_tabBounds.Height - img.Height) / 2.0f) + _tabBounds.Y;
            e.Graphics.DrawImage(img, 5, _y);
        }*/
        //Nút sửa
        private void btnAccountSuaTTCN_Click(object sender, EventArgs e)
        {
            //Mở khóa text box để sửa
            txtHoTenCN.Enabled = true;
            radNamCN.Enabled = true;
            radNuCN.Enabled = true;
            txtNgaySinhCN.Enabled = true;
            btnAccountSuaTTCN.Enabled = false;
            btnAccountHuyCN.Enabled = true;
            btnAccountLuuCN.Enabled = true;
        }
        private void btnAccountSuaTTNV_Click(object sender, EventArgs e)
        {
            //Mở khóa text box để sửa
            txtHoTenNV.Enabled = true;
            radNamNV.Enabled = true;
            radNuNV.Enabled = true;
            txtNgaySinhNV.Enabled = true;
            btnAccountSuaTTNV.Enabled = false;
            btnAccountHuyNV.Enabled = true;
            btnAccountLuuNV.Enabled = true;
        }
        //nút đổi pass
        private void btnAccountDoiMKNV_Click(object sender, EventArgs e)
        {
            frmDoiMK frm = new frmDoiMK();
            frm.MessageAccount = txtIDNV.Text;//truyền id đến form đổi pass
            frm.ShowDialog();//mở form đổi pass
        }
        private void btnAccountDoiMKCN_Click(object sender, EventArgs e)
        {
            frmDoiMK frm = new frmDoiMK();
            frm.MessageAccount = txtIDCN.Text;//truyền id đến form đổi pass
            frm.ShowDialog();//mở form đổi pass
        }
        //nút hủy
        private void btnAccountHuyNV_Click(object sender, EventArgs e)
        {
            if (_messageAccount.Contains("CN"))//nếu ad đăng nhập là công nhân
                LoadThongTinCNToTabPage(_messageAccount);//load thông tin công nhân lên tabpage
            else//nếu là nhân viên, quản lý
                LoadThongTinNVToTabPage(_messageAccount);//load thông tin nhân viên lên tabpage
            txtHoTenNV.Enabled = false;
            radNamNV.Enabled = false;
            radNuNV.Enabled = false;
            txtNgaySinhNV.Enabled = false;
            txtNgayBDLamNV.Enabled = false;
            btnAccountHuyNV.Enabled = false;
            btnAccountSuaTTNV.Enabled = true;
            btnAccountLuuNV.Enabled = false;
        }
        //nút hủy cho tab công nhân
        private void btnAccountHuyCN_Click(object sender, EventArgs e)
        {
            if (_messageAccount.Contains("CN"))//nếu ad đăng nhập là công nhân
                LoadThongTinCNToTabPage(_messageAccount);//load thông tin công nhân lên tabpage
            else//nếu là nhân viên, quản lý
                LoadThongTinNVToTabPage(_messageAccount);//load thông tin nhân viên lên tabpage
            txtHoTenCN.Enabled = false;
            radNamCN.Enabled = false;
            radNuCN.Enabled = false;
            txtNgaySinhCN.Enabled = false;
            txtNgayBDLamCN.Enabled = false;
            btnAccountHuyCN.Enabled = false;
            btnAccountSuaTTCN.Enabled = true;
            btnAccountLuuCN.Enabled = false;
        }
        //Xóa right space
        public static string RTrim(string s)
        {
            //"Le Tan Dung    "
            int i = s.Length - 1;
            while (s[i] == ' ')
            {
                i--;
            }
            s = s.Substring(0, i + 1);
            return s;
        }
        //Tạo list view item (NV)
        ListViewItem TaoItemNV(tblNhanVienHanhChinh n)
        {
            ListViewItem lvwItem;
            lvwItem = new ListViewItem(n.IDNV);
            lvwItem.SubItems.Add(RTrim(n.HoTen));
            lvwItem.SubItems.Add(RTrim(n.GioiTinh));
            lvwItem.SubItems.Add(String.Format("{0:dd-MM-yyyy}",n.NgaySinh)); //định dạng ngày theo dd-MM-yyyy
            lvwItem.SubItems.Add(String.Format("{0:dd-MM-yyyy}", n.NgayBatDau)); // như trên
            lvwItem.SubItems.Add(TongLuongNV(nv.GetOneNV(n.IDNV),lhc.GetLuongThuocNV(n.IDNV)).ToString());
            return lvwItem;
        }

        //Tạo list view item (CN)
        ListViewItem TaoItemCN(tblCongNhan c)
        {
            ListViewItem lvwItem;
            lvwItem = new ListViewItem(c.IDCN);
            lvwItem.SubItems.Add(RTrim(c.HoTen));
            lvwItem.SubItems.Add(RTrim(c.GioiTinh));
            lvwItem.SubItems.Add(String.Format("{0:dd-MM-yyyy}", c.NgaySinh));//định dạng ngày theo dd-MM-yyyy
            lvwItem.SubItems.Add(String.Format("{0:dd-MM-yyyy}", c.NgayBatDau));
            lvwItem.SubItems.Add(TongLuongCN(c,lcn.GetLCNThuocCN(c.IDCN)).ToString());
            lvwItem.Tag = c;
            return lvwItem;
        }

        //Load NV lên listview
        void LoadNVToListView(ListView lvw, IEnumerable<tblNhanVienHanhChinh> dsNV)
        {
            ListViewItem ItemNV;
            foreach (tblNhanVienHanhChinh n in dsNV)
            {
                ItemNV = TaoItemNV(n);
                lvw.Items.Add(ItemNV);
            }
        }

        //Load CN lên listview
        void LoadCNToListView(ListView lvw, IEnumerable<tblCongNhan> dsCN)
        {
            ListViewItem ItemCN;
            foreach (tblCongNhan c in dsCN)
            {
                ItemCN = TaoItemCN(c);
                lvw.Items.Add(ItemCN);
            }
        }

        //Load NV, CN lên list view
        void LoadToListView(ListView lvw)
        {
            lvw.Items.Clear();
            IEnumerable<tblNhanVienHanhChinh> n = nv.GetAllNhanVien();
            IEnumerable<tblCongNhan> c = cn.GetAllCongNhan();
            LoadCNToListView(lvw, c);
            LoadNVToListView(lvw, n);
        }

        // sự kiện chọn item trong lvwDanhSach
        private void lvwDanhSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwDanhSach.SelectedItems.Count == 1)//Chọn 1 đối tượng
            {
                btnDanhSachSuaTT.Enabled = true;//Mở chức năng sửa
                btnDanhSachXoaNS.Enabled = true;//Mở chức năng xóa
            }
            else if (lvwDanhSach.SelectedItems.Count > 1)//chọn hơn 1 đối tượng
            {
                btnDanhSachSuaTT.Enabled = false; // khóa chức năng sửa
            }
            else if (lvwDanhSach.SelectedItems.Count < 1)
                btnDanhSachXoaNS.Enabled = false;
        }

        private void btnDanhSachSuaTT_Click(object sender, EventArgs e)
        {
            tblCongNhan c = null;
            string idnv;
            if ((lvwDanhSach.SelectedItems[0].Text).Contains("CN")) //nếu ID có 'CN' thì mở form công nhân
            {
                c = cn.GetOneCN(lvwDanhSach.SelectedItems[0].Text); // lưu thông tin công nhân vào biến c
                frmSuaCN frm = new frmSuaCN(); //tạo biến form mới
                frm.MessageC = c; // gửi biến c vào form vừa tạo (gán c vào lớp nhận thông điệp)
                //mở form .ShowDialog() chỉ khi đóng form frm mọi hoạt động trên form khác với được tiếp tục
                frm.ShowDialog();
                lvwDanhSach.Items.Clear();
                LoadToListView(lvwDanhSach);
                btnDanhSachSuaTT.Enabled = false;//form đóng khóa nút sửa thông tin
            }
            else//còn lại mở form nhân viên hành chính
            {
                idnv = lvwDanhSach.SelectedItems[0].Text; //lưu id nhân viên vào biến idnv
                frmSuaNV frm = new frmSuaNV();
                frm.MessageN = idnv;
                frm.ShowDialog();
                lvwDanhSach.Items.Clear();
                LoadToListView(lvwDanhSach);
                LoadThongTinNVToTabPage(_messageAccount);
                btnDanhSachSuaTT.Enabled = false;//form đóng khóa nút sửa thông tin
            }
        }
        // Hỏi trước khi đóng
        private void frmMainQL_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có chắc muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
                e.Cancel = true;
        }

        private void btnDanhSachThemNV_Click(object sender, EventArgs e)
        {                   
            frmThemNV frm = new frmThemNV();
            frm.ShowDialog();
            lvwDanhSach.Items.Clear();
            LoadToListView(lvwDanhSach);
        }

        private void btnDanhSachThemCN_Click(object sender, EventArgs e)
        {
            frmThemCN frm = new frmThemCN();
            frm.ShowDialog();
            lvwDanhSach.Items.Clear();
            LoadToListView(lvwDanhSach);
        }

        private void btnDanhSachXoaNS_Click(object sender, EventArgs e)
        {
            DialogResult r;
            string ID;
            int vtthuc;//biến lưu vị trí thực trong danh sách
            if (lvwDanhSach.SelectedItems.Count > 0)
            {
                r = MessageBox.Show("Bạn chắc chắn xóa?", "Hỏi xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1);
                if (r == DialogResult.Yes)
                {
                    for (int i = 0; i < lvwDanhSach.SelectedItems.Count; i++)
                    {
                        vtthuc = lvwDanhSach.SelectedIndices[i];//lấy vị trí thực trong danh sách
                        string IDLay = (lvwDanhSach.Items[vtthuc].Text).ToUpper();
                        if (IDLay.Contains("CN")) //nếu ID có 'CN' thì mở form công nhân
                        {
                            ID = lvwDanhSach.Items[vtthuc].Text;
                            cn.DeleteCongNhan(cn.GetOneCN(ID));
                            acc.DeleteAccCongNhan(acc.GetAccountCN(ID));
                            foreach (tblLuongCN luong in lcn.GetLCNThuocCN(ID))
                                lcn.DeleteLuongCongNhan(luong);
                        }
                        else
                        {
                            ID = lvwDanhSach.Items[vtthuc].Text;
                            nv.DeleteNhanVien(nv.GetOneNV(ID));
                            lhc.DeleteLuongNhanVien(lhc.GetLuongThuocNV(ID));
                            acc.DeleteAccNhanVien(acc.GetAccountNV(ID));
                        }
                    }
                    btnDanhSachXoaNS.Enabled = false;
                }
                else
                    btnDanhSachXoaNS.Enabled = false;
                lvwDanhSach.Items.Clear();
                LoadToListView(lvwDanhSach);
            }
        }
        //Tạo item chứa thông tin nhân viên hoặc quản lý
        tblNhanVienHanhChinh TaoNhanVien(tblNhanVienHanhChinh NV)
        {
            tblNhanVienHanhChinh n = new tblNhanVienHanhChinh();
            n.IDNV = txtIDNV.Text;
            n.HoTen = txtHoTenNV.Text;            
            n.NgaySinh = Convert.ToDateTime(txtNgaySinhNV.Text).Date;// .Date : chỉ lấy ngày tháng năm, k lấy time
            n.NgayBatDau = NV.NgayBatDau;
            n.HeSoLuong = NV.HeSoLuong;
            n.PhuCap = NV.PhuCap;
            n.IDHopDong = NV.IDHopDong;
            if (radNamNV.Checked == true)
                n.GioiTinh = "Nam";
            else
                n.GioiTinh = "Nữ";
            return n;
        }
        //tạo item chứa thông tin công nhân
        tblCongNhan TaoCongNhan(tblCongNhan CN)
        {
            tblCongNhan c = new tblCongNhan();
            c.IDCN = txtIDCN.Text;
            c.HoTen = txtHoTenCN.Text;
            c.NgayBatDau = Convert.ToDateTime(txtNgayBDLamCN.Text);
            c.NgaySinh = Convert.ToDateTime(txtNgaySinhCN.Text);
            if (radNamCN.Checked == true)
                c.GioiTinh = "Nam";
            else
                c.GioiTinh = "Nữ";
            c.CongDoan = CN.CongDoan;
            c.HeSoLuongCD = CN.HeSoLuongCD;
            c.IDSanPham = CN.IDSanPham;
            return c;
        }
        //Lưu sửa thông tin cá nhân
        private void btnAccountLuuNV_Click(object sender, EventArgs e)
        {
            if (clsCheck.DOBCheck(txtNgaySinhNV.Text) == false)
            {
                MessageBox.Show("Định dạng ngày sinh không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNgaySinhNV.Focus();
            }
            else
            {
                DialogResult r;
                r = MessageBox.Show("Lưu những thay đổi?", "Thông báo",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    btnAccountSuaTTNV.Enabled = true;
                    btnAccountLuuNV.Enabled = false;
                    tblNhanVienHanhChinh n = TaoNhanVien(nv.GetOneNV(_messageAccount));//tạo item chứa thông tin nhân viên trên textbox
                    nv.SuaNV(n);//Lưu vào database
                    btnAccountHuyNV.Enabled = false;
                    txtHoTenNV.Enabled = false;
                    radNamNV.Enabled = false;
                    radNuNV.Enabled = false;
                    txtNgaySinhNV.Enabled = false;
                    txtNgayBDLamNV.Enabled = false;
                }
            }          
        }
        //lưu thông tin cho tab công nhân
        private void btnAccountLuuCN_Click(object sender, EventArgs e)
        {
            if (clsCheck.DOBCheck(txtNgaySinhCN.Text) == false)
            {
                MessageBox.Show("Định dạng ngày sinh không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNgaySinhCN.Focus();
            }
            else
            {
                DialogResult r;
                r = MessageBox.Show("Lưu những thay đổi?", "Thông báo",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    btnAccountSuaTTCN.Enabled = true;
                    btnAccountLuuCN.Enabled = false;
                    tblCongNhan c = TaoCongNhan(cn.GetOneCN(_messageAccount));//tạo item chứa thông tin nhân viên trên textbox
                    cn.SuaCN(c);//Lưu vào database
                    btnAccountHuyCN.Enabled = false;
                    txtHoTenCN.Enabled = false;
                    radNamCN.Enabled = false;
                    radNuCN.Enabled = false;
                    txtNgaySinhCN.Enabled = false;
                    txtNgayBDLamCN.Enabled = false;
                }

            }
        }
        //Autocomplet
        void XuLyHoTroAutocomplete()
        {
            string strTimKiem = txtTimKiem.Text;
            IEnumerable<tblCongNhan> dsCN = cn.GetAllCongNhan();// Lấy danh sách tất cả công nhân
            IEnumerable<tblNhanVienHanhChinh> dsNV = nv.GetAllNhanVien();// Lấy danh sách tất cả nhân viên
            txtTimKiem.AutoCompleteCustomSource.Clear();
            if (cboTimKiem.SelectedIndex == 0) //Nếu chọn tìm theo ID công nhân
            {                
                foreach (tblCongNhan c in dsCN)
                    txtTimKiem.AutoCompleteCustomSource.Add(c.IDCN);//Add item autocomplete vào txt tìm kiếm
            }
            else if (cboTimKiem.SelectedIndex == 1)//Nếu chọn tìm theo ID nhân viên
            {                
                foreach (tblNhanVienHanhChinh n in dsNV)
                    txtTimKiem.AutoCompleteCustomSource.Add(n.IDNV);//Add item autocomplete vào txt tìm kiếm
            }
            else if (cboTimKiem.SelectedIndex == 2)//Nếu chọn tìm theo họ tên
            {
                foreach (tblCongNhan c in dsCN)
                    txtTimKiem.AutoCompleteCustomSource.Add(c.HoTen);//add họ tên vào
                foreach (tblNhanVienHanhChinh n in dsNV)
                    txtTimKiem.AutoCompleteCustomSource.Add(n.HoTen);//như trên
            }
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (cboTimKiem.SelectedIndex == 0) //Nếu chọn tìm theo ID công nhân
            {
                IEnumerable<tblCongNhan> dsCN = cn.GetCNTheoIDKhongHoanThien(txtTimKiem.Text);
                lvwDanhSach.Items.Clear();
                LoadCNToListView(lvwDanhSach, dsCN);
            }
            else if (cboTimKiem.SelectedIndex == 1)//Nếu chọn tìm theo ID nhân viên
            {
                IEnumerable<tblNhanVienHanhChinh> dsNV = nv.GetNVTheoIDKhongHoanChinh(txtTimKiem.Text);
                lvwDanhSach.Items.Clear();
                LoadNVToListView(lvwDanhSach, dsNV);
            }
            else if (cboTimKiem.SelectedIndex == 2)//Nếu chọn tìm theo họ tên
            {
                IEnumerable<tblCongNhan> dsCN = cn.GetCNTheoTen(txtTimKiem.Text);
                IEnumerable<tblNhanVienHanhChinh> dsNV = nv.GetNVTheoTen(txtTimKiem.Text);
                lvwDanhSach.Items.Clear();
                LoadCNToListView(lvwDanhSach, dsCN);
                LoadNVToListView(lvwDanhSach, dsNV);
            }
        }

        private void cboTimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            XuLyHoTroAutocomplete();
        }
        // Tạo cột cho lvw
        public void CreateColumnsLuongCN(ListView lvw)
        {
            lvw.Columns.Clear();
            lvw.View = View.Details;//cài đặt xem kiểu detail
            lvw.GridLines = true; //vẽ đường kẻ, chắc vậy
            lvw.FullRowSelect = true;//cho phép chọn full dòng
            lvw.Columns.Add("Hệ số ca", 180);//line này với line dưới = tạo cột
            lvw.Columns.Add("Số lượng", 280);
        }

        private void btnLogOutNV_Click(object sender, EventArgs e)
        {
            this.Close();//đăng xuất, đóng app
        }

        private void btnLogOutCN_Click(object sender, EventArgs e)
        {
            this.Close();//đăng xuất, đóng app
        }

        private void txtHoTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 65) || (e.KeyChar > 90)) && ((e.KeyChar < 97) || (e.KeyChar > 122)) && !(e.KeyChar == 8) && !(e.KeyChar == 127))
                e.Handled = true;
        }
        private void txtNgaySinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48) || (e.KeyChar > 57)) && !(e.KeyChar == 8) && !(e.KeyChar == 45) && !(e.KeyChar == 127))
                e.Handled = true;
        }
    }
}