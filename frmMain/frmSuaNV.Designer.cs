namespace frmMain
{
    partial class frmSuaNV
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
            this.txtNgayBDLam = new System.Windows.Forms.TextBox();
            this.txtNgaySinh = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHSLuong = new System.Windows.Forms.TextBox();
            this.txtPhuCap = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.lblID = new System.Windows.Forms.Label();
            this.lblSoNgayLam = new System.Windows.Forms.Label();
            this.lblSoGioNgoai = new System.Windows.Forms.Label();
            this.lblTongLuong = new System.Windows.Forms.Label();
            this.radNu = new System.Windows.Forms.RadioButton();
            this.radNam = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.cboIDHD = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtNgayBDLam
            // 
            this.txtNgayBDLam.Enabled = false;
            this.txtNgayBDLam.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNgayBDLam.Location = new System.Drawing.Point(173, 220);
            this.txtNgayBDLam.Name = "txtNgayBDLam";
            this.txtNgayBDLam.Size = new System.Drawing.Size(215, 29);
            this.txtNgayBDLam.TabIndex = 4;
            // 
            // txtNgaySinh
            // 
            this.txtNgaySinh.Enabled = false;
            this.txtNgaySinh.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNgaySinh.Location = new System.Drawing.Point(173, 167);
            this.txtNgaySinh.Name = "txtNgaySinh";
            this.txtNgaySinh.Size = new System.Drawing.Size(215, 29);
            this.txtNgaySinh.TabIndex = 3;
            this.txtNgaySinh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNgaySinh_KeyPress);
            // 
            // txtHoTen
            // 
            this.txtHoTen.Enabled = false;
            this.txtHoTen.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoTen.Location = new System.Drawing.Point(173, 114);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(215, 29);
            this.txtHoTen.TabIndex = 0;
            this.txtHoTen.Text = "1";
            this.txtHoTen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHoTen_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 222);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 22);
            this.label5.TabIndex = 18;
            this.label5.Text = "Ngày bắt đầu làm:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 22);
            this.label4.TabIndex = 17;
            this.label4.Text = "Ngày sinh:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(402, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 22);
            this.label3.TabIndex = 16;
            this.label3.Text = "Giới tính:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 22);
            this.label2.TabIndex = 15;
            this.label2.Text = "Họ tên:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 22);
            this.label1.TabIndex = 14;
            this.label1.Text = "ID:";
            // 
            // txtHSLuong
            // 
            this.txtHSLuong.Enabled = false;
            this.txtHSLuong.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHSLuong.Location = new System.Drawing.Point(530, 274);
            this.txtHSLuong.Name = "txtHSLuong";
            this.txtHSLuong.Size = new System.Drawing.Size(202, 29);
            this.txtHSLuong.TabIndex = 5;
            this.txtHSLuong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHSLuong_KeyPress);
            // 
            // txtPhuCap
            // 
            this.txtPhuCap.Enabled = false;
            this.txtPhuCap.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhuCap.Location = new System.Drawing.Point(530, 219);
            this.txtPhuCap.Name = "txtPhuCap";
            this.txtPhuCap.Size = new System.Drawing.Size(202, 29);
            this.txtPhuCap.TabIndex = 6;
            this.txtPhuCap.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhuCap_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(402, 222);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 22);
            this.label11.TabIndex = 25;
            this.label11.Text = "Phụ cấp:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(402, 277);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(120, 22);
            this.label12.TabIndex = 24;
            this.label12.Text = "Hệ số lương:";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(897, 44);
            this.label6.TabIndex = 28;
            this.label6.Text = "CHI TIẾT NHÂN VIÊN";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(13, 368);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 22);
            this.label7.TabIndex = 31;
            this.label7.Text = "Tổng lương:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(13, 324);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 22);
            this.label9.TabIndex = 30;
            this.label9.Text = "Số giờ ngoài:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(13, 277);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 22);
            this.label10.TabIndex = 29;
            this.label10.Text = "Số ngày làm:";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(756, 83);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(129, 52);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Enabled = false;
            this.btnHuy.Location = new System.Drawing.Point(756, 231);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(129, 52);
            this.btnHuy.TabIndex = 10;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(756, 157);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(129, 52);
            this.btnSua.TabIndex = 9;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // lblID
            // 
            this.lblID.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(178, 61);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(113, 29);
            this.lblID.TabIndex = 38;
            this.lblID.Text = "ID:";
            // 
            // lblSoNgayLam
            // 
            this.lblSoNgayLam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSoNgayLam.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoNgayLam.Location = new System.Drawing.Point(173, 276);
            this.lblSoNgayLam.Name = "lblSoNgayLam";
            this.lblSoNgayLam.Size = new System.Drawing.Size(215, 29);
            this.lblSoNgayLam.TabIndex = 39;
            this.lblSoNgayLam.Text = "dd-MM-yyyy";
            // 
            // lblSoGioNgoai
            // 
            this.lblSoGioNgoai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSoGioNgoai.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoGioNgoai.Location = new System.Drawing.Point(173, 324);
            this.lblSoGioNgoai.Name = "lblSoGioNgoai";
            this.lblSoGioNgoai.Size = new System.Drawing.Size(215, 29);
            this.lblSoGioNgoai.TabIndex = 40;
            this.lblSoGioNgoai.Text = "ngay";
            // 
            // lblTongLuong
            // 
            this.lblTongLuong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTongLuong.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongLuong.Location = new System.Drawing.Point(173, 367);
            this.lblTongLuong.Name = "lblTongLuong";
            this.lblTongLuong.Size = new System.Drawing.Size(215, 29);
            this.lblTongLuong.TabIndex = 41;
            this.lblTongLuong.Text = "vnđ";
            // 
            // radNu
            // 
            this.radNu.AutoSize = true;
            this.radNu.Enabled = false;
            this.radNu.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radNu.Location = new System.Drawing.Point(624, 115);
            this.radNu.Name = "radNu";
            this.radNu.Size = new System.Drawing.Size(54, 26);
            this.radNu.TabIndex = 2;
            this.radNu.TabStop = true;
            this.radNu.Text = "Nữ";
            this.radNu.UseVisualStyleBackColor = true;
            // 
            // radNam
            // 
            this.radNam.AutoSize = true;
            this.radNam.Enabled = false;
            this.radNam.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radNam.Location = new System.Drawing.Point(530, 115);
            this.radNam.Name = "radNam";
            this.radNam.Size = new System.Drawing.Size(67, 26);
            this.radNam.TabIndex = 1;
            this.radNam.TabStop = true;
            this.radNam.Text = "Nam";
            this.radNam.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(402, 170);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 22);
            this.label8.TabIndex = 69;
            this.label8.Text = "ID Hợp đồng:";
            // 
            // cboIDHD
            // 
            this.cboIDHD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIDHD.Enabled = false;
            this.cboIDHD.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboIDHD.FormattingEnabled = true;
            this.cboIDHD.Location = new System.Drawing.Point(530, 167);
            this.cboIDHD.Name = "cboIDHD";
            this.cboIDHD.Size = new System.Drawing.Size(202, 30);
            this.cboIDHD.TabIndex = 7;
            // 
            // frmSuaNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(897, 411);
            this.Controls.Add(this.cboIDHD);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.radNu);
            this.Controls.Add(this.radNam);
            this.Controls.Add(this.lblTongLuong);
            this.Controls.Add(this.lblSoGioNgoai);
            this.Controls.Add(this.lblSoNgayLam);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtHSLuong);
            this.Controls.Add(this.txtPhuCap);
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
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSuaNV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết nhân viên";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSuaNV_FormClosing);
            this.Load += new System.EventHandler(this.frmSuaNV_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtNgayBDLam;
        private System.Windows.Forms.TextBox txtNgaySinh;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHSLuong;
        private System.Windows.Forms.TextBox txtPhuCap;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblSoNgayLam;
        private System.Windows.Forms.Label lblSoGioNgoai;
        private System.Windows.Forms.Label lblTongLuong;
        private System.Windows.Forms.RadioButton radNu;
        private System.Windows.Forms.RadioButton radNam;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboIDHD;
    }
}