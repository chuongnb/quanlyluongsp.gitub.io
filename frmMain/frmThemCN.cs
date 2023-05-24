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
    public partial class frmThemCN : Form
    {
        clsCongNhan cn = new clsCongNhan();
        clsSanPham sp = new clsSanPham();
        clsAccount acc = new clsAccount();
        clsLuongCN lcn = new clsLuongCN();
        public frmThemCN()
        {
            InitializeComponent();
        }

        private void frmThemCN_Load(object sender, EventArgs e)
        {
            CreateItemForCboIDSP();
            cboCongDoan.SelectedIndex = 0;
            cboIDSP.SelectedIndex = 0;
        }
        //Tạo item cho cbo ID sản phẩm
        void CreateItemForCboIDSP()
        {
            IEnumerable<tblSanPham> dsSP = sp.GetAllSP();
            foreach (tblSanPham s in dsSP)
                cboIDSP.Items.Add(s.IDSanPham);
        }
        //tạo item chứa thông tin công nhân
        tblCongNhan TaoCongNhan()
        {
            tblCongNhan c = new tblCongNhan();
            c.IDCN = txtID.Text.ToUpper().Trim();
            c.HoTen = txtHoTen.Text;
            c.NgayBatDau = Convert.ToDateTime(txtNgayBDLam.Text).Date;
            c.NgaySinh = Convert.ToDateTime(txtNgaySinh.Text).Date;
            if (radNam.Checked == true)
                c.GioiTinh = "Nam";
            else
                c.GioiTinh = "Nữ";
            c.CongDoan = (cboCongDoan.SelectedIndex + 1).ToString();
            c.HeSoLuongCD = Convert.ToDecimal(txtHSLuongCD.Text);
            c.IDSanPham = (cboIDSP.SelectedItem).ToString();
            return c;
        }
        //tạo item chứa account CN
        tblAccountCN TaoAccCongNhan()
        {
            tblAccountCN a = new tblAccountCN();
            a.IDCN = txtID.Text.ToUpper().Trim();
            a.PassCN = "123456ab";
            a.STT = txtID.Text.Substring(txtID.Text.Length - 2, 2);
            return a;
        }
        //tạo item chứa lương CN
        tblLuongCN TaoLuongCongNhan()
        {
            tblLuongCN l = new tblLuongCN();
            l.IDCN = txtID.Text.ToUpper().Trim();
            l.HeSoCa = 0;
            l.SoLuong = 0;
            l.STT = txtID.Text.Substring(txtID.Text.Length - 2, 2);
            return l;
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

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if (cn.CheckIfExistCN(txtID.Text) != null)
            {
                DialogResult r;
                r = MessageBox.Show("Trùng mã", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtID.Text = "";
                txtID.Focus();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnHuy.Enabled = false;
            DialogResult r;
            r = MessageBox.Show("Không lưu và thoát?", "Thông báo",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
                this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                if (clsCheck.IDCNCheck(txtID.Text)==false)
                {
                    MessageBox.Show("ID phải có dạng CNxxx !\nx là một chữ số [0-9]", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                else
                {
                    DialogResult r;
                    r = MessageBox.Show("Thêm công nhân?", "Thông báo",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        btnOK.Enabled = false;
                        tblCongNhan c = TaoCongNhan();//tạo item chứa thông tin nhân viên trên textbox
                        tblLuongCN l = TaoLuongCongNhan();
                        tblAccountCN a = TaoAccCongNhan();
                        cn.insertCongNhan(c);//Lưu vào database
                        lcn.insertLuongCongNhan(l);
                        acc.insertAccCongNhan(a);
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

        private void frmThemCN_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((btnHuy.Enabled != false)&&(btnOK.Enabled!=false))
            {
                DialogResult r = MessageBox.Show("Bạn có chắc thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
