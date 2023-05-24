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
    public partial class frmThemNV : Form
    {
        clsHopDong hd = new clsHopDong();
        clsNhanVienHC nv = new clsNhanVienHC();
        clsAccount acc = new clsAccount();
        clsLuongHC lhc = new clsLuongHC();
        public frmThemNV()
        {
            InitializeComponent();
        }
        //sự kiện load form
        private void frmThemNV_Load(object sender, EventArgs e)
        {
            CreateItemForCboIDHD();
            cboIDHD.SelectedIndex = 0;
        }
        //Tạo item cho cbo id hợp đồng
        void CreateItemForCboIDHD()
        {
            IEnumerable<tblHopDong> dsHD = hd.GetAllHD();
            foreach (tblHopDong h in dsHD)
                cboIDHD.Items.Add(h.IDHopDong);
        }
        //Tạo item chứa thông tin nhân viên
        tblNhanVienHanhChinh TaoNhanVien()
        {
            tblNhanVienHanhChinh n = new tblNhanVienHanhChinh();
            n.IDNV = txtID.Text.ToUpper();
            n.HoTen = txtHoTen.Text;
            n.NgayBatDau = Convert.ToDateTime(txtNgayBDLam.Text).Date;// .Date : chỉ lấy ngày tháng năm, k lấy time
            n.NgaySinh = Convert.ToDateTime(txtNgaySinh.Text).Date;
            if (radNam.Checked == true)
                n.GioiTinh = "Nam";
            else
                n.GioiTinh = "Nữ";
            n.HeSoLuong = Convert.ToDecimal(txtHSLuong.Text);
            n.PhuCap = Convert.ToDecimal(txtPhuCap.Text);
            n.IDHopDong = (cboIDHD.SelectedItem).ToString();
            return n;
        }
        tblAccountNV TaoAccNV()
        {
            tblAccountNV n = new tblAccountNV();
            n.IDNV = txtID.Text.ToUpper();
            n.PassNV = "123456ab";
            n.STT = txtID.Text.Substring(txtID.Text.Length - 2, 2);
            return n;
        }
        tblLuongHC TaoLuongHC()
        {
            tblLuongHC n = new tblLuongHC();
            n.IDNV = txtID.Text.ToUpper();
            n.SoGioNgoai = 0;
            n.SoNgayLam = 0;
            n.STT = txtID.Text.Substring(txtID.Text.Length - 2, 2);
            return n;
        }
        //Lưu sửa vào database
        private void btnOK_Click(object sender, EventArgs e)
        {
            if(txtID.Text != "")
            {
                if (clsCheck.IDNVCheck(txtID.Text) == false)
                {
                    MessageBox.Show("ID phải có dạng NVxxx !\nx là một chữ số [0-9]!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtID.Focus();
                }
                else if (clsCheck.DOBCheck(txtNgaySinh.Text) == false)
                {
                    MessageBox.Show("Ngày sinh không đúng định dạng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNgaySinh.Focus();
                }
                else if (clsCheck.DOBCheck(txtNgayBDLam.Text) == false)
                {
                    MessageBox.Show("Ngày bắt đầu làm không đúng định dạng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNgayBDLam.Focus();
                }
                else if (txtHSLuong.Text == "")
                {
                    MessageBox.Show("Hệ số lương không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtHSLuong.Focus();
                }
                else if (txtPhuCap.Text == "")
                {
                    MessageBox.Show("Phụ cấp không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPhuCap.Focus();
                }
                else
                {
                    DialogResult r;
                    r = MessageBox.Show("Thêm nhân viên?", "Thông báo",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        btnOK.Enabled = false;
                        tblNhanVienHanhChinh n = TaoNhanVien();//tạo item chứa thông tin nhân viên trên textbox
                        tblLuongHC l = TaoLuongHC();
                        tblAccountNV a = TaoAccNV();
                        nv.insertNhanVien(n);//Lưu vào database
                        lhc.insertLuongNhanVien(l);
                        acc.insertAccNhanVien(a);
                        this.Close();//đóng form
                    }
                }
            }
            else
            {
                DialogResult r;
                r = MessageBox.Show("Mã trống", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtID.Focus();
            }
        }
        //Không lưu và thoát
        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnHuy.Enabled = false;
            DialogResult r;
            r = MessageBox.Show("Không lưu và thoát?", "Thông báo",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
                this.Close();
        }
        //lập tức báo trùng mã nếu nhập trùng
        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if (nv.CheckIfExistNV(txtID.Text) != null)
            {
                DialogResult r;
                r = MessageBox.Show("Trùng mã", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtID.Text = "";
                txtID.Focus();
            }
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

        private void txtNgayBDLam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48) || (e.KeyChar > 57)) && !(e.KeyChar == 8) && !(e.KeyChar == 45) && !(e.KeyChar == 127))
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

        private void frmThemNV_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((btnHuy.Enabled != false)&&(btnOK.Enabled!=false))
            {
                DialogResult r;
                r = MessageBox.Show("Bạn có chắc thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.No)
                {
                    e.Cancel = true;
                    btnHuy.Enabled = true;
                    btnOK.Enabled = true;
                }
            }
        }
    }
}
