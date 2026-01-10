namespace QuanLyKhachSan
{
    partial class TrangChu
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrangChu));
            this.btnthoat = new Guna.UI2.WinForms.Guna2Button();
            this.btnMinisize = new Guna.UI2.WinForms.Guna2Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnnhanvien = new Guna.UI2.WinForms.Guna2Button();
            this.btnchitietkh = new Guna.UI2.WinForms.Guna2Button();
            this.btnthanhtoan = new Guna.UI2.WinForms.Guna2Button();
            this.btndkikhachhang = new Guna.UI2.WinForms.Guna2Button();
            this.btnthemphong = new Guna.UI2.WinForms.Guna2Button();
            this.pndichuyen = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.uC_BaoCao1 = new QuanLyKhachSan.User_Controller.UC_BaoCao();
            this.uC_Nhanvien1 = new QuanLyKhachSan.User_Controller.UC_Nhanvien();
            this.uC_Checkout1 = new QuanLyKhachSan.User_Controller.UC_Checkout();
            this.uC_KhachHang1 = new QuanLyKhachSan.UC_KhachHang();
            this.uC_add1 = new QuanLyKhachSan.User_Controller.UC_add();
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse3 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse4 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnthoat
            // 
            this.btnthoat.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnthoat.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnthoat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnthoat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnthoat.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(112)))), ((int)(((byte)(255)))));
            this.btnthoat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnthoat.ForeColor = System.Drawing.Color.White;
            this.btnthoat.Image = ((System.Drawing.Image)(resources.GetObject("btnthoat.Image")));
            this.btnthoat.ImageSize = new System.Drawing.Size(35, 35);
            this.btnthoat.Location = new System.Drawing.Point(3, 12);
            this.btnthoat.Name = "btnthoat";
            this.btnthoat.Size = new System.Drawing.Size(48, 45);
            this.btnthoat.TabIndex = 0;
            this.btnthoat.Click += new System.EventHandler(this.btnthoat_Click);
            // 
            // btnMinisize
            // 
            this.btnMinisize.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMinisize.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMinisize.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMinisize.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMinisize.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(112)))), ((int)(((byte)(255)))));
            this.btnMinisize.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMinisize.ForeColor = System.Drawing.Color.White;
            this.btnMinisize.Image = ((System.Drawing.Image)(resources.GetObject("btnMinisize.Image")));
            this.btnMinisize.ImageSize = new System.Drawing.Size(35, 35);
            this.btnMinisize.Location = new System.Drawing.Point(3, 73);
            this.btnMinisize.Name = "btnMinisize";
            this.btnMinisize.Size = new System.Drawing.Size(48, 45);
            this.btnMinisize.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnnhanvien);
            this.panel1.Controls.Add(this.btnchitietkh);
            this.panel1.Controls.Add(this.btnthanhtoan);
            this.panel1.Controls.Add(this.btndkikhachhang);
            this.panel1.Controls.Add(this.btnthemphong);
            this.panel1.Location = new System.Drawing.Point(121, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1760, 130);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnnhanvien
            // 
            this.btnnhanvien.BorderRadius = 18;
            this.btnnhanvien.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnnhanvien.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnnhanvien.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnnhanvien.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnnhanvien.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnnhanvien.FillColor = System.Drawing.Color.SlateBlue;
            this.btnnhanvien.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnnhanvien.ForeColor = System.Drawing.Color.White;
            this.btnnhanvien.Location = new System.Drawing.Point(1440, 3);
            this.btnnhanvien.Name = "btnnhanvien";
            this.btnnhanvien.Size = new System.Drawing.Size(284, 116);
            this.btnnhanvien.TabIndex = 4;
            this.btnnhanvien.Text = "Nhân Viên";
            this.btnnhanvien.Click += new System.EventHandler(this.btnnhanvien_Click);
            // 
            // btnchitietkh
            // 
            this.btnchitietkh.BorderRadius = 18;
            this.btnchitietkh.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnchitietkh.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnchitietkh.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnchitietkh.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnchitietkh.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnchitietkh.FillColor = System.Drawing.Color.SlateBlue;
            this.btnchitietkh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnchitietkh.ForeColor = System.Drawing.Color.White;
            this.btnchitietkh.Location = new System.Drawing.Point(1096, 3);
            this.btnchitietkh.Name = "btnchitietkh";
            this.btnchitietkh.Size = new System.Drawing.Size(284, 116);
            this.btnchitietkh.TabIndex = 3;
            this.btnchitietkh.Text = "Chi Tiết Khách Hàng";
            this.btnchitietkh.Click += new System.EventHandler(this.guna2Button6_Click);
            // 
            // btnthanhtoan
            // 
            this.btnthanhtoan.BorderRadius = 18;
            this.btnthanhtoan.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnthanhtoan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnthanhtoan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnthanhtoan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnthanhtoan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnthanhtoan.FillColor = System.Drawing.Color.SlateBlue;
            this.btnthanhtoan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnthanhtoan.ForeColor = System.Drawing.Color.White;
            this.btnthanhtoan.Location = new System.Drawing.Point(741, 3);
            this.btnthanhtoan.Name = "btnthanhtoan";
            this.btnthanhtoan.Size = new System.Drawing.Size(284, 116);
            this.btnthanhtoan.TabIndex = 2;
            this.btnthanhtoan.Text = "Thanh Toán";
            this.btnthanhtoan.Click += new System.EventHandler(this.btnthanhtoan_Click);
            // 
            // btndkikhachhang
            // 
            this.btndkikhachhang.BorderRadius = 18;
            this.btndkikhachhang.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btndkikhachhang.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btndkikhachhang.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btndkikhachhang.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btndkikhachhang.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btndkikhachhang.FillColor = System.Drawing.Color.SlateBlue;
            this.btndkikhachhang.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndkikhachhang.ForeColor = System.Drawing.Color.White;
            this.btndkikhachhang.Location = new System.Drawing.Point(380, 3);
            this.btndkikhachhang.Name = "btndkikhachhang";
            this.btndkikhachhang.Size = new System.Drawing.Size(284, 116);
            this.btndkikhachhang.TabIndex = 1;
            this.btndkikhachhang.Text = "Quản lý khách hàng";
            this.btndkikhachhang.Click += new System.EventHandler(this.btndkikhachhang_Click);
            // 
            // btnthemphong
            // 
            this.btnthemphong.BorderRadius = 18;
            this.btnthemphong.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnthemphong.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnthemphong.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnthemphong.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnthemphong.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnthemphong.FillColor = System.Drawing.Color.SlateBlue;
            this.btnthemphong.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnthemphong.ForeColor = System.Drawing.Color.White;
            this.btnthemphong.Location = new System.Drawing.Point(27, 3);
            this.btnthemphong.Name = "btnthemphong";
            this.btnthemphong.Size = new System.Drawing.Size(284, 116);
            this.btnthemphong.TabIndex = 0;
            this.btnthemphong.Text = "Quản lý phòng";
            this.btnthemphong.Click += new System.EventHandler(this.btnthemphong_Click);
            // 
            // pndichuyen
            // 
            this.pndichuyen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.pndichuyen.Location = new System.Drawing.Point(134, 162);
            this.pndichuyen.Name = "pndichuyen";
            this.pndichuyen.Size = new System.Drawing.Size(300, 7);
            this.pndichuyen.TabIndex = 4;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.TargetControl = this;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.uC_BaoCao1);
            this.panel2.Controls.Add(this.uC_Nhanvien1);
            this.panel2.Controls.Add(this.uC_Checkout1);
            this.panel2.Controls.Add(this.uC_KhachHang1);
            this.panel2.Controls.Add(this.uC_add1);
            this.panel2.Location = new System.Drawing.Point(57, 189);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1882, 852);
            this.panel2.TabIndex = 5;
            // 
            // uC_BaoCao1
            // 
            this.uC_BaoCao1.BackColor = System.Drawing.Color.White;
            this.uC_BaoCao1.Location = new System.Drawing.Point(0, 0);
            this.uC_BaoCao1.Name = "uC_BaoCao1";
            this.uC_BaoCao1.Size = new System.Drawing.Size(1882, 852);
            this.uC_BaoCao1.TabIndex = 4;
            // 
            // uC_Nhanvien1
            // 
            this.uC_Nhanvien1.BackColor = System.Drawing.Color.White;
            this.uC_Nhanvien1.Location = new System.Drawing.Point(0, 0);
            this.uC_Nhanvien1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.uC_Nhanvien1.Name = "uC_Nhanvien1";
            this.uC_Nhanvien1.Size = new System.Drawing.Size(1882, 786);
            this.uC_Nhanvien1.TabIndex = 3;
            // 
            // uC_Checkout1
            // 
            this.uC_Checkout1.BackColor = System.Drawing.Color.White;
            this.uC_Checkout1.Location = new System.Drawing.Point(0, 0);
            this.uC_Checkout1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uC_Checkout1.Name = "uC_Checkout1";
            this.uC_Checkout1.Size = new System.Drawing.Size(1882, 786);
            this.uC_Checkout1.TabIndex = 2;
            // 
            // uC_KhachHang1
            // 
            this.uC_KhachHang1.BackColor = System.Drawing.Color.White;
            this.uC_KhachHang1.Location = new System.Drawing.Point(0, 0);
            this.uC_KhachHang1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uC_KhachHang1.Name = "uC_KhachHang1";
            this.uC_KhachHang1.Size = new System.Drawing.Size(1864, 805);
            this.uC_KhachHang1.TabIndex = 1;
            // 
            // uC_add1
            // 
            this.uC_add1.BackColor = System.Drawing.Color.White;
            this.uC_add1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uC_add1.Location = new System.Drawing.Point(0, 75);
            this.uC_add1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uC_add1.Name = "uC_add1";
            this.uC_add1.Size = new System.Drawing.Size(1882, 777);
            this.uC_add1.TabIndex = 0;
            // 
            // guna2Elipse2
            // 
            this.guna2Elipse2.TargetControl = this;
            // 
            // guna2Elipse3
            // 
            this.guna2Elipse3.BorderRadius = 30;
            this.guna2Elipse3.TargetControl = this;
            // 
            // guna2Elipse4
            // 
            this.guna2Elipse4.BorderRadius = 30;
            this.guna2Elipse4.TargetControl = this;
            // 
            // TrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(112)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1726, 882);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pndichuyen);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnMinisize);
            this.Controls.Add(this.btnthoat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TrangChu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TrangChu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TrangChu_load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnthoat;
        private Guna.UI2.WinForms.Guna2Button btnMinisize;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button btnthemphong;
        private Guna.UI2.WinForms.Guna2Button btndkikhachhang;
        private Guna.UI2.WinForms.Guna2Button btnchitietkh;
        private Guna.UI2.WinForms.Guna2Button btnthanhtoan;
        private Guna.UI2.WinForms.Guna2Button btnnhanvien;
        private Guna.UI2.WinForms.Guna2Panel pndichuyen;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.Panel panel2;
        private User_Controller.UC_add uC_add1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
        private UC_KhachHang uC_KhachHang1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse3;
        private User_Controller.UC_Checkout uC_Checkout1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse4;
        private User_Controller.UC_Nhanvien uC_Nhanvien1;
        private User_Controller.UC_BaoCao uC_BaoCao1;
    }
}