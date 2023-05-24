using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frmMain
{
    public partial class frmSuaNV : Form
    {
        private string _messageN; // khai báo biến nhận item(id nhân viên)

        public frmSuaNV()
        {
            InitializeComponent();
        }
        clsLuongHC lhc = new clsLuongHC();
        clsNhanVienHC nv = new clsNhanVienHC();
        clsHopDong hd = new clsHopDong();

        //nói chung là để nhận item từ frmMainQL
        public string MessageN //lớp nhận thông tin
        {
            get { return _messageN; }
            set { _messageN = value; }
        }
        private void frmSuaNV_Load(object sender, EventArgs e)
        {
            CreateItemForCboIDHD();
            tblNhanVienHanhChinh n = nv.GetOneNV(_messageN);//Lưu thông tin nhân viên vào biến n
            NhanVienToTextbox(n);//Load thông tin nv lên textbox
            string strIDNV = _messageN;//lưu id nv vào biến strIDNV
            tblLuongHC LuongHC = lhc.GetLuongThuocNV(strIDNV); //lấy thông tin lương hành chính
            LuongHCToTextBox(LuongHC);//load thông tin lương lên text box
            TongLuong(n);//load tổng lương lên text box
        }
        //Tạo item cho cbo id hợp đồng
        void CreateItemForCboIDHD()
        {
            IEnumerable<tblHopDong> dsHD = hd.GetAllHD();
            foreach (tblHopDong h in dsHD)
                cboIDHD.Items.Add(h.IDHopDong);
        }
        //Tính tổng lương
        void TongLuong(tblNhanVienHanhChinh n)
        {
            float HS = Convert.ToInt32(n.HeSoLuong);
            float SNL = Convert.ToInt32(lblSoNgayLam.Text);
            float SGN = Convert.ToInt32(lblSoGioNgoai.Text);
            float PC = Convert.ToInt32(n.PhuCap);
            //tổng lương = hệ số : 30 x số ngày làm + số giờ làm x (hệ số : 30 : 24) x 2 + phụ cấp
            float TongLuong = HS / 30 * SNL + SGN * (HS / 30 / 24) * 2 + PC;
            lblTongLuong.Text = Math.Round(TongLuong,0).ToString("#,##0");
        }
        //Lương to textbox
        void LuongHCToTextBox(tblLuongHC _luongHC)
        {
            lblSoGioNgoai.Text = _luongHC.SoGioNgoai.ToString();
            lblSoNgayLam.Text = _luongHC.SoNgayLam.ToString();
        }

        // Enable textbox để sửa thông tin
        private void btnSua_Click(object sender, EventArgs e)
        {
            txtHoTen.Enabled = true;
            radNam.Enabled = true;
            radNu.Enabled = true;
            txtNgaySinh.Enabled = true;
           // txtNgayBDLam.Enabled = true;
            txtHSLuong.Enabled = true;
            txtPhuCap.Enabled = true;
            cboIDHD.Enabled = true;
            btnSua.Enabled = false;//khóa nút sửa
            btnHuy.Enabled = true;//mở nút hủy
        }
        //Lại là xóa right space đây :v
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

        //Load thông tin NV lên text box
        void NhanVienToTextbox(tblNhanVienHanhChinh nv)
        {
            lblID.Text = nv.IDNV;
            txtHoTen.Text = RTrim(nv.HoTen);
            if (nv.GioiTinh.Contains("Nam"))
                radNam.Checked = true;
            else
                radNu.Checked = true;
            txtNgaySinh.Text = String.Format("{0:dd-MM-yyyy}", nv.NgaySinh);//hiển thị date theo dạng ngày-tháng-năm
            txtNgayBDLam.Text = String.Format("{0:dd-MM-yyyy}", nv.NgayBatDau);
            txtHSLuong.Text = (nv.HeSoLuong).ToString("#,##0");//hiển thị tiền theo dạng dấu phẩy hàng nghìn
            txtPhuCap.Text = nv.PhuCap.ToString("#,##0");
            cboIDHD.SelectedItem = nv.IDHopDong;
        }
        //tạo item chứa thông tin nhân viên
        tblNhanVienHanhChinh TaoNhanVien()
        {
            tblNhanVienHanhChinh n = new tblNhanVienHanhChinh();
            n.IDNV = lblID.Text;
            n.HoTen = txtHoTen.Text;
            n.NgayBatDau = Convert.ToDateTime(txtNgayBDLam.Text).Date;// .Date : chỉ lấy ngày tháng năm, k lấy time
            n.NgaySinh = Convert.ToDateTime(txtNgaySinh.Text).Date;
            if (radNam.Checked == true)
                n.GioiTinh = "Nam";
            else
                n.GioiTinh = "Nữ";
            n.HeSoLuong = Convert.ToDecimal(txtHSLuong.Text);
            n.PhuCap = Convert.ToDecimal(txtPhuCap.Text);
            n.IDHopDong= (cboIDHD.SelectedItem).ToString();
            return n;
        }
        //Lưu sửa vào database
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (clsCheck.DOBCheck(txtNgaySinh.Text) == false)
            {
                MessageBox.Show("Định dạng ngày sinh không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNgaySinh.Focus();
            }
            else
            {
                btnOK.Enabled = false;
                tblNhanVienHanhChinh n = TaoNhanVien();//tạo item chứa thông tin nhân viên trên textbox
                nv.SuaNV(n);//Lưu vào database
                this.Close();//đóng form
            }
        }
        //Hoàn tác dữ liệu
        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Hủy mọi thay đổi?", "Thông báo",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                tblNhanVienHanhChinh n = nv.GetOneNV(_messageN);
                NhanVienToTextbox(n);//reset thông tin
                txtHoTen.Enabled = false;
                radNam.Enabled = false;
                radNu.Enabled = false;
                txtNgaySinh.Enabled = false;
               // txtNgayBDLam.Enabled = false;
                txtHSLuong.Enabled = false;
                txtPhuCap.Enabled = false;
                cboIDHD.Enabled = false;
                btnHuy.Enabled = false;
                btnSua.Enabled = true;
            }
        }
        //Đơn giản là close form
        private void frmSuaNV_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnSua.Enabled == true) //Xem xong ra
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
            else if (btnHuy.Enabled == true && btnOK.Enabled == true)//đang sửa muốn đóng form (dùng nút X của form)
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

        private void txtHoTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 65) || (e.KeyChar > 90)) && ((e.KeyChar < 97) || (e.KeyChar > 122)) && !(e.KeyChar == 8) && !(e.KeyChar == 127))
                e.Handled = true;
        }

        private void txtHSLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48) || (e.KeyChar > 57)) && !(e.KeyChar == 8) && !(e.KeyChar == 127))
                e.Handled = true;
        }

        private void txtPhuCap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48) || (e.KeyChar > 57)) && !(e.KeyChar == 8) && !(e.KeyChar == 127))
                e.Handled = true;
        }

        private void txtNgaySinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48) || (e.KeyChar > 57)) && !(e.KeyChar == 8) && !(e.KeyChar == 45) && !(e.KeyChar == 127))
                e.Handled = true;
        }
    }
}
