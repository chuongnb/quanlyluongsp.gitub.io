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
    public partial class frmDoiMK : Form
    {
        public string _messageAccount;
        public string MessageAccount
        {
            get { return _messageAccount; }
            set { _messageAccount = value; }
        }

        clsAccount acc = new clsAccount();

        public frmDoiMK()
        {
            InitializeComponent();
        }

        bool CheckOldPass(string strID)
        {
            bool c = false;
            if (strID.Substring(0,2).Equals("CN"))
            {
                string _oldPass = acc.GetAccountCN(strID).PassCN;
                if (txtOldPass.Text.Equals(_oldPass))
                    c = true;
            }
            else
            {
                string _oldPass = acc.GetAccountNV(strID).PassNV;
                if (txtOldPass.Text.Equals(_oldPass))
                    c = true;
            }
            return c;
        }

        bool CheckNewPass(string strID)
        {
            bool c = false;
            if (txtNewPass.Text.Equals(txtReplaceNewPass.Text))
                c = true;
            return c;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkHienPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHienPass.Checked)
            {
                txtNewPass.UseSystemPasswordChar = false;
                txtOldPass.UseSystemPasswordChar = false;
                txtReplaceNewPass.UseSystemPasswordChar = false;
            }
            else
            {
                txtNewPass.UseSystemPasswordChar = true;
                txtOldPass.UseSystemPasswordChar = true;
                txtReplaceNewPass.UseSystemPasswordChar = true;
            }
        }

        private void frmDoiMK_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnDoiMK.Enabled == true)
            {
                DialogResult r;
                r = MessageBox.Show("Không đổi mật khẩu và thoát?", "Thông báo",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.No)
                    e.Cancel = true;
            }
        }
        tblAccountCN TaoAccCN(string strID)
        {
            tblAccountCN _aCN = acc.GetAccountCN(strID);
            _aCN.STT = _aCN.STT;
            _aCN.IDCN = _aCN.IDCN;
            _aCN.PassCN = txtNewPass.Text;
            return _aCN;
        }
        tblAccountNV TaoAccNV(string strID)
        {
            tblAccountNV _aNV = acc.GetAccountNV(strID);
            _aNV.STT = _aNV.STT;
            _aNV.IDNV = _aNV.IDNV;
            _aNV.PassNV = txtNewPass.Text;
            return _aNV;
        }
        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            string ID = _messageAccount;
            if (CheckOldPass(ID) && (CheckNewPass(ID) && txtOldPass.Text != "" && txtNewPass.Text != ""))
            {
                DialogResult r;
                r = MessageBox.Show("Đổi mật khẩu?", "Thông báo",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.No)
                    btnDoiMK.Enabled = true;
                else
                {
                    if (ID.Substring(0, 2).Equals("CN"))
                    {
                        tblAccountCN aCN = TaoAccCN(ID);
                        acc.SuaAccCN(aCN);
                        btnDoiMK.Enabled = false;
                        this.Close();
                    }
                    else
                    {
                        tblAccountNV aNV = TaoAccNV(ID);
                        acc.SuaAccNV(aNV);
                        btnDoiMK.Enabled = false;
                        this.Close();
                    }
                }               
            }
            else if (txtOldPass.Text == "")
            {
                MessageBox.Show("Chưa nhập mật khẩu hiện tại!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOldPass.Focus();
            }
            else if (txtNewPass.Text == "")
            {
                MessageBox.Show("Chưa nhập mật khẩu mới!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPass.Focus();
            }
            else if (CheckOldPass(ID) == false)
            {
                MessageBox.Show("Mật khẩu hiện tại sai!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOldPass.Focus();
            }
            else if (CheckNewPass(ID) == false)
            {
                MessageBox.Show("Xác nhận mật khẩu mới sai!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtReplaceNewPass.Focus();
            }
        }
    }
}
