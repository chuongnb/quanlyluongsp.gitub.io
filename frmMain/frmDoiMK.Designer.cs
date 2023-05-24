namespace frmMain
{
    partial class frmDoiMK
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDoiMK));
            this.label3 = new System.Windows.Forms.Label();
            this.txtOldPass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtReplaceNewPass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDoiMK = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.chkHienPass = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(516, 55);
            this.label3.TabIndex = 3;
            this.label3.Text = "ĐỔI MẬT KHẨU";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtOldPass
            // 
            this.txtOldPass.Location = new System.Drawing.Point(226, 91);
            this.txtOldPass.Name = "txtOldPass";
            this.txtOldPass.Size = new System.Drawing.Size(258, 29);
            this.txtOldPass.TabIndex = 0;
            this.txtOldPass.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 22);
            this.label2.TabIndex = 5;
            this.label2.Text = "Mật khẩu hiện tại:";
            // 
            // txtNewPass
            // 
            this.txtNewPass.Location = new System.Drawing.Point(226, 136);
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.Size = new System.Drawing.Size(258, 29);
            this.txtNewPass.TabIndex = 1;
            this.txtNewPass.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 22);
            this.label1.TabIndex = 7;
            this.label1.Text = "Mật khẩu mới:";
            // 
            // txtReplaceNewPass
            // 
            this.txtReplaceNewPass.Location = new System.Drawing.Point(226, 182);
            this.txtReplaceNewPass.Name = "txtReplaceNewPass";
            this.txtReplaceNewPass.Size = new System.Drawing.Size(258, 29);
            this.txtReplaceNewPass.TabIndex = 2;
            this.txtReplaceNewPass.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 22);
            this.label4.TabIndex = 9;
            this.label4.Text = "Xác nhận mật khẩu:";
            // 
            // btnDoiMK
            // 
            this.btnDoiMK.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoiMK.Location = new System.Drawing.Point(93, 267);
            this.btnDoiMK.Name = "btnDoiMK";
            this.btnDoiMK.Size = new System.Drawing.Size(125, 42);
            this.btnDoiMK.TabIndex = 4;
            this.btnDoiMK.Text = "Đổi mật khẩu";
            this.btnDoiMK.UseVisualStyleBackColor = true;
            this.btnDoiMK.Click += new System.EventHandler(this.btnDoiMK_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Location = new System.Drawing.Point(295, 267);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(125, 42);
            this.btnHuy.TabIndex = 5;
            this.btnHuy.Text = "&Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // chkHienPass
            // 
            this.chkHienPass.AutoSize = true;
            this.chkHienPass.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHienPass.Location = new System.Drawing.Point(226, 217);
            this.chkHienPass.Name = "chkHienPass";
            this.chkHienPass.Size = new System.Drawing.Size(136, 20);
            this.chkHienPass.TabIndex = 3;
            this.chkHienPass.Text = "Hiển thị mật khẩu";
            this.chkHienPass.UseVisualStyleBackColor = true;
            this.chkHienPass.CheckedChanged += new System.EventHandler(this.chkHienPass_CheckedChanged);
            // 
            // frmDoiMK
            // 
            this.AcceptButton = this.btnDoiMK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 330);
            this.Controls.Add(this.chkHienPass);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnDoiMK);
            this.Controls.Add(this.txtReplaceNewPass);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNewPass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtOldPass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "frmDoiMK";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đổi mật khẩu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDoiMK_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOldPass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNewPass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtReplaceNewPass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDoiMK;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.CheckBox chkHienPass;
    }
}