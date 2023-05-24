namespace frmMain
{
    partial class frmSuaCN
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
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtTongLuong = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtHSLuongCD = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtNgayBDLam = new System.Windows.Forms.TextBox();
            this.txtNgaySinh = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lvwChiTietCN = new System.Windows.Forms.ListView();
            this.btnSua = new System.Windows.Forms.Button();
            this.lblIDCN = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.radNam = new System.Windows.Forms.RadioButton();
            this.radNu = new System.Windows.Forms.RadioButton();
            this.cboCongDoan = new System.Windows.Forms.ComboBox();
            this.cboIDSP = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnHuy
            // 
            this.btnHuy.Enabled = false;
            this.btnHuy.Location = new System.Drawing.Point(737, 316);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(110, 52);
            this.btnHuy.TabIndex = 11;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(467, 316);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(110, 52);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtTongLuong
            // 
            this.txtTongLuong.Enabled = false;
            this.txtTongLuong.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongLuong.Location = new System.Drawing.Point(583, 260);
            this.txtTongLuong.Name = "txtTongLuong";
            this.txtTongLuong.Size = new System.Drawing.Size(264, 29);
            this.txtTongLuong.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(463, 263);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 22);
            this.label7.TabIndex = 54;
            this.label7.Text = "Tổng lương:";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(862, 44);
            this.label6.TabIndex = 51;
            this.label6.Text = "CHI TIẾT CÔNG NHÂN";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtHSLuongCD
            // 
            this.txtHSLuongCD.Enabled = false;
            this.txtHSLuongCD.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHSLuongCD.Location = new System.Drawing.Point(179, 339);
            this.txtHSLuongCD.Name = "txtHSLuongCD";
            this.txtHSLuongCD.Size = new System.Drawing.Size(260, 29);
            this.txtHSLuongCD.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(12, 296);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(108, 22);
            this.label11.TabIndex = 48;
            this.label11.Text = "Công đoạn:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(12, 342);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(153, 22);
            this.label12.TabIndex = 47;
            this.label12.Text = "Hệ số lương CĐ:";
            // 
            // txtNgayBDLam
            // 
            this.txtNgayBDLam.Enabled = false;
            this.txtNgayBDLam.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNgayBDLam.Location = new System.Drawing.Point(179, 248);
            this.txtNgayBDLam.Name = "txtNgayBDLam";
            this.txtNgayBDLam.Size = new System.Drawing.Size(260, 29);
            this.txtNgayBDLam.TabIndex = 4;
            // 
            // txtNgaySinh
            // 
            this.txtNgaySinh.Enabled = false;
            this.txtNgaySinh.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNgaySinh.Location = new System.Drawing.Point(179, 202);
            this.txtNgaySinh.Name = "txtNgaySinh";
            this.txtNgaySinh.Size = new System.Drawing.Size(260, 29);
            this.txtNgaySinh.TabIndex = 3;
            // 
            // txtHoTen
            // 
            this.txtHoTen.Enabled = false;
            this.txtHoTen.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoTen.Location = new System.Drawing.Point(179, 114);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(260, 29);
            this.txtHoTen.TabIndex = 0;
            this.txtHoTen.Text = "1";
            this.txtHoTen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHoTen_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 251);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 22);
            this.label5.TabIndex = 41;
            this.label5.Text = "Ngày bắt đầu làm:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 22);
            this.label4.TabIndex = 40;
            this.label4.Text = "Ngày sinh:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 22);
            this.label3.TabIndex = 39;
            this.label3.Text = "Giới tính:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 22);
            this.label2.TabIndex = 38;
            this.label2.Text = "Họ tên:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 22);
            this.label1.TabIndex = 37;
            this.label1.Text = "ID:";
            // 
            // lvwChiTietCN
            // 
            this.lvwChiTietCN.HideSelection = false;
            this.lvwChiTietCN.Location = new System.Drawing.Point(467, 70);
            this.lvwChiTietCN.Name = "lvwChiTietCN";
            this.lvwChiTietCN.Size = new System.Drawing.Size(380, 161);
            this.lvwChiTietCN.TabIndex = 60;
            this.lvwChiTietCN.UseCompatibleStateImageBehavior = false;
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(602, 316);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(110, 52);
            this.btnSua.TabIndex = 10;
            this.btnSua.Text = "Sửa thông tin";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // lblIDCN
            // 
            this.lblIDCN.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIDCN.Location = new System.Drawing.Point(179, 73);
            this.lblIDCN.Name = "lblIDCN";
            this.lblIDCN.Size = new System.Drawing.Size(113, 29);
            this.lblIDCN.TabIndex = 62;
            this.lblIDCN.Text = "ID:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 388);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 22);
            this.label8.TabIndex = 63;
            this.label8.Text = "ID sản phẩm:";
            // 
            // radNam
            // 
            this.radNam.AutoSize = true;
            this.radNam.Enabled = false;
            this.radNam.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radNam.Location = new System.Drawing.Point(179, 158);
            this.radNam.Name = "radNam";
            this.radNam.Size = new System.Drawing.Size(67, 26);
            this.radNam.TabIndex = 1;
            this.radNam.TabStop = true;
            this.radNam.Text = "Nam";
            this.radNam.UseVisualStyleBackColor = true;
            // 
            // radNu
            // 
            this.radNu.AutoSize = true;
            this.radNu.Enabled = false;
            this.radNu.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radNu.Location = new System.Drawing.Point(301, 158);
            this.radNu.Name = "radNu";
            this.radNu.Size = new System.Drawing.Size(54, 26);
            this.radNu.TabIndex = 2;
            this.radNu.TabStop = true;
            this.radNu.Text = "Nữ";
            this.radNu.UseVisualStyleBackColor = true;
            // 
            // cboCongDoan
            // 
            this.cboCongDoan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCongDoan.Enabled = false;
            this.cboCongDoan.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCongDoan.FormattingEnabled = true;
            this.cboCongDoan.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cboCongDoan.Location = new System.Drawing.Point(179, 293);
            this.cboCongDoan.Name = "cboCongDoan";
            this.cboCongDoan.Size = new System.Drawing.Size(260, 30);
            this.cboCongDoan.TabIndex = 5;
            this.cboCongDoan.SelectedIndexChanged += new System.EventHandler(this.cboCongDoan_SelectedIndexChanged);
            // 
            // cboIDSP
            // 
            this.cboIDSP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIDSP.Enabled = false;
            this.cboIDSP.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboIDSP.FormattingEnabled = true;
            this.cboIDSP.Location = new System.Drawing.Point(179, 385);
            this.cboIDSP.Name = "cboIDSP";
            this.cboIDSP.Size = new System.Drawing.Size(260, 30);
            this.cboIDSP.TabIndex = 7;
            // 
            // frmSuaCN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(862, 427);
            this.Controls.Add(this.cboIDSP);
            this.Controls.Add(this.cboCongDoan);
            this.Controls.Add(this.radNu);
            this.Controls.Add(this.radNam);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblIDCN);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.lvwChiTietCN);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtTongLuong);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtHSLuongCD);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtNgayBDLam);
            this.Controls.Add(this.txtNgaySinh);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSuaCN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết công nhân";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSuaCN_FormClosing);
            this.Load += new System.EventHandler(this.frmSuaCN_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtTongLuong;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtHSLuongCD;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtNgayBDLam;
        private System.Windows.Forms.TextBox txtNgaySinh;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvwChiTietCN;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Label lblIDCN;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton radNam;
        private System.Windows.Forms.RadioButton radNu;
        private System.Windows.Forms.ComboBox cboCongDoan;
        private System.Windows.Forms.ComboBox cboIDSP;
    }
}