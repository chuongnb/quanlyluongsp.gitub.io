using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Diagnostics;

namespace frmMain
{
    public partial class frmSuaCN : Form
    {
        private tblCongNhan _messageC; // khai báo biến nhận item(thông tin công nhân)

        public frmSuaCN()
        {
            InitializeComponent();
        }
        //Khai báo class để xài
        clsLuongCN lcn = new clsLuongCN();
        clsCongNhan cn = new clsCongNhan();
        clsSanPham sp = new clsSanPham();
        clsAccount acc = new clsAccount();


        //nói chung là để nhận item từ frmMainQL
        public tblCongNhan MessageC //lớp nhận thông tin
        {
            get { return _messageC; }
            set { _messageC = value; }
        }

        private void frmSuaCN_Load(object sender, EventArgs e)
        {
            CreateColumns(lvwChiTietCN);
            CreateItemForCboIDSP();
            tblCongNhan c = _messageC;//tạo biến nhận item
            CongNhanToTextbox(c);//đưa thông tin item vào các text box
            string strIDCN = lblIDCN.Text;//lấy id công nhân
            IEnumerable<tblLuongCN> dsLcn = lcn.GetLCNThuocCN(strIDCN);//lấy thông tin lương thuộc id này
            LoadLuongToListView(lvwChiTietCN, dsLcn);//load lên list view cho dễ xem nhỉ
            TongLuong(c, dsLcn);
        }
        void CreateItemForCboIDSP()
        {
            IEnumerable<tblSanPham> dsSP = sp.GetAllSP();
            foreach (tblSanPham s in dsSP)
                cboIDSP.Items.Add(s.IDSanPham);
        }
        //Tính tổng lương
        void TongLuong(tblCongNhan c,IEnumerable<tblLuongCN> dsLcn)
        {
            float LCD = Convert.ToInt32(c.HeSoLuongCD);
            float TongLuong = 0;
            foreach(tblLuongCN Lcn in dsLcn)
            {
                TongLuong += (Convert.ToInt32(Lcn.HeSoCa) * Convert.ToInt32(Lcn.SoLuong));
            }
            TongLuong *= LCD;
            txtTongLuong.Text = TongLuong.ToString("#,##0");
        }
        //Load lên lvw
        void LoadLuongToListView(ListView lvw, IEnumerable<tblLuongCN> dsLcn)
        {
            lvw.Items.Clear();//dọn chỗ để load lên
            ListViewItem ItemLCN;//tạo item
            foreach (tblLuongCN Lcn in dsLcn)//load
            {
                ItemLCN = CreateItem(Lcn);//tạo item = 1 phần tử trong danh sách thông tin lương
                lvw.Items.Add(ItemLCN);//add vào list view
            }
        }
        //Tạo item cho lvw
        ListViewItem CreateItem(tblLuongCN lcn)
        {
            ListViewItem lvwItem;//tạo biến kiểu listviewitem
            lvwItem = new ListViewItem(lcn.HeSoCa.ToString());//điền thông tin cột đầu tiên
            lvwItem.SubItems.Add(lcn.SoLuong.ToString());//điền thông tin cột thứ 2
            lvwItem.Tag = lcn;//nhet vao de su dung muc dich khac (mu dich 1)
            return lvwItem;
        }
        // Tạo cột cho lvw
        public void CreateColumns(ListView lvw)
        {
            lvw.Columns.Clear();
            lvw.View = View.Details;//cài đặt xem kiểu detail
            lvw.GridLines = true; //vẽ đường kẻ, chắc vậy
            lvw.FullRowSelect = true;//cho phép chọn full dòng
            lvw.Columns.Add("Hệ số ca", 180);//line này với line dưới = tạo cột
            lvw.Columns.Add("Số lượng", 200);
        }
        //Xóa space bên phải chuỗi
        public static string RTrim(string s)
        {
            //VD:"Le Tan Dung    "
            int i = s.Length - 1;
            while (s[i] == ' ')
            {
                i--;
            }
            s = s.Substring(0, i + 1);
            return s;
        }
        //Load thông tin CN(item) lên text box
        void CongNhanToTextbox(tblCongNhan cn)
        {
            lblIDCN.Text = cn.IDCN;
            txtHoTen.Text = RTrim(cn.HoTen);
            if (cn.GioiTinh.Contains("Nam"))
                radNam.Checked = true;
            else
                radNu.Checked = true;
            txtNgaySinh.Text = String.Format("{0:dd-MM-yyyy}", cn.NgaySinh);
            txtNgayBDLam.Text = String.Format("{0:dd-MM-yyyy}", cn.NgayBatDau);
            cboCongDoan.SelectedIndex = Convert.ToInt32(cn.CongDoan) - 1;
            txtHSLuongCD.Text = cn.HeSoLuongCD.ToString();
            cboIDSP.SelectedItem = cn.IDSanPham;
        }
        // Enable textbox để sửa thông tin
        private void btnSua_Click(object sender, EventArgs e)
        {
            txtHoTen.Enabled = true;
            radNam.Enabled = true;
            radNu.Enabled = true;
            txtNgaySinh.Enabled = true;
           // txtNgayBDLam.Enabled = true;
            cboCongDoan.Enabled = true;
            cboIDSP.Enabled = true;
            btnSua.Enabled = false;
            btnHuy.Enabled = true;
        }
        //tạo item chứa thông tin công nhân
        tblCongNhan TaoCongNhan()
        {
            tblCongNhan c = new tblCongNhan();
            c.IDCN = lblIDCN.Text;
            c.HoTen = txtHoTen.Text;
            c.NgayBatDau = Convert.ToDateTime(txtNgayBDLam.Text).Date;
            c.NgaySinh = Convert.ToDateTime(txtNgaySinh.Text).Date;
            if (radNam.Checked == true)
                c.GioiTinh = "Nam";
            else
                c.GioiTinh = "Nữ";
            c.CongDoan = (cboCongDoan.SelectedIndex + 1).ToString();
            c.HeSoLuongCD = Convert.ToDecimal(txtHSLuongCD.Text);
            c.IDSanPham =(cboIDSP.SelectedItem).ToString();
            return c;
        }
        //Sự kiện nút OK
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (clsCheck.DOBCheck(txtNgaySinh.Text) == false)
            {
                MessageBox.Show("Ngày sinh không hợp lý!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNgaySinh.Focus();
            }
            else
            {
                btnOK.Enabled = false;
                tblCongNhan c = TaoCongNhan();//tạo item chứa thông tin công nhân trên textbox
                cn.SuaCN(c);//Lưu vào database                
                this.Close();//đóng form
            }
        }
        //Hủy không lưu
        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Hủy mọi thay đổi?", "Thông báo",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                tblCongNhan c = _messageC;
                CongNhanToTextbox(c);//reset thông tin
                txtHoTen.Enabled = false;
                radNam.Enabled = false;
                radNu.Enabled = false;
                txtNgaySinh.Enabled = false;
               // txtNgayBDLam.Enabled = false;
                cboCongDoan.Enabled = false;
                cboIDSP.Enabled = false;
                btnHuy.Enabled = false;
                btnSua.Enabled = true;
            }
        }
        //Lời thoại khi close form
        private void frmSuaCN_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnSua.Enabled == true) //Trường hợp không làm gì cả
            {
                DialogResult r;
                r = MessageBox.Show("Bạn có chắc muốn thoát?", "Thông báo",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.No)
                {
                    e.Cancel = true;
                    btnOK.Enabled = true;
                }
            }
            else if (btnHuy.Enabled == true && btnOK.Enabled == true)//đang sửa muốn đóng form
            {
                DialogResult r;
                r = MessageBox.Show("Mọi thay đổi sẽ không được lưu\nBạn có chắc muốn thoát?", "Thông báo",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.No)
                    e.Cancel = true;
            }
            else//Hỏi khi lưu
            {
                DialogResult r;
                r = MessageBox.Show("Lưu những thay đổi và thoát\nBạn chắc chắn?", "Thông báo",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.No)
                {
                    e.Cancel = true;
                    btnOK.Enabled = true;
                }
            }
        }

        private void cboCongDoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCongDoan.SelectedIndex == 0)
                txtHSLuongCD.Text = 170000.ToString("#,##0");
            else if (cboCongDoan.SelectedIndex == 1)
                txtHSLuongCD.Text = 180000.ToString("#,##0");
            else if (cboCongDoan.SelectedIndex == 2)
                txtHSLuongCD.Text = 160000.ToString("#,##0");
            else
                txtHSLuongCD.Text = 150000.ToString("#,##0");
        }

        private void txtHoTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 65) || (e.KeyChar > 90)) && ((e.KeyChar < 97) || (e.KeyChar > 122)) && !(e.KeyChar == 8) && !(e.KeyChar == 127))
                e.Handled = true;
        }
    }
}
