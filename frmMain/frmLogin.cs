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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        //khai báo các class để dùng
        clsAccount acc = new clsAccount();
        clsCongNhan cn = new clsCongNhan();
        clsNhanVienHC nv = new clsNhanVienHC();
        //Đăng nhập
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string ID = txtUserID.Text.ToUpper();// biến id lưu dữ liệu nhập vào từ txtID viết in hoa
            if (ID.Substring(0, 2).Equals("CN"))// nếu biến id chứa 2 ký tự đầu là CN
            {
                if (cn.CheckIfExistCN(ID) != null)//nếu tồn tại ID trong CSDL
                {
                    tblAccountCN acn = acc.GetAccountCN(ID.Trim());//lấy thông tin account theo id
                    if (acn.PassCN.Trim().Equals(txtPass.Text))//nếu pass đúng với thông tin account
                    {
                        frmMainQL frm = new frmMainQL();//tạo formMain mới
                        frm.MessageAccount = acn.IDCN;//gửi Id đăng nhập sang formMain
                        this.Hide();//ẩn form đăng nhập
                        frm.ShowDialog();//mở form Main vừa tạo
                        Application.Exit();//đóng form đăng nhập
                    }
                    else
                        //nếu pass sai thông báo
                        MessageBox.Show("Pass sai!", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else // nếu không tìm thấy id thông báo
                    MessageBox.Show("ID không tồn tại!", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //nếu  biến id chứa 2 ký tự đầu là NV hoặc QL (nhân viên hoặc quản lý đăng nhập)
            else if (ID.Substring(0, 2).Equals("NV")|| ID.Substring(0, 2).Equals("QL"))
            {
                if (nv.CheckIfExistNV(ID) != null)//nếu tồn tại id trong csdl
                {
                    tblAccountNV anv = acc.GetAccountNV(ID.Trim());//lấy thông tin đăng nhập theo id
                    if (anv.PassNV.Trim().Equals(txtPass.Text))//nếu pass đúng
                    {
                        frmMainQL frm = new frmMainQL();//tạo form main mới
                        frm.MessageAccount = anv.IDNV;//gửi id đăng nhập sang form main vừa tạo
                        this.Hide();//ẩn form đăng nhập
                        frm.ShowDialog();//mở form main
                                         //if (frm.ShowDialog() == DialogResult.OK)
                                         //frm.ShowDialog();
                                         //Application.Exit();//đóng form đăng nhập
                        this.Show();
                        txtPass.Text = "";
                        txtUserID.Text = "";
                        chkHienPass.Checked = false;
                        txtUserID.Focus();
                    }
                    else//nếu pas sai thông báo
                        MessageBox.Show("Pass sai!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else//nếu không tìm thấy id trong csdl thông báo
                    MessageBox.Show("ID không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else//nếu nhập id có dạng không bắt đầu bằng CN,NV hoặc QL thông báo
                MessageBox.Show("ID không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = true;//dùng system password char cho text box pass(ẩn pass)
        }
        private void chkHienPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHienPass.Checked)//nếu chọn hiện pass
                txtPass.UseSystemPasswordChar = false;//không dùng password char
            else//nếu bỏ chọn hiện pass
                txtPass.UseSystemPasswordChar = true;//dùng password char
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
