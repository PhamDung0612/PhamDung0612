using QuanLyKhachSan.User_Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class TrangChu : Form
    {
        public TrangChu()
        {
            InitializeComponent();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            pndichuyen.Left = btnchitietkh.Left + 85;
            uC_BaoCao1.Visible = true;
            uC_BaoCao1.BringToFront();
        }

        private void btnthemphong_Click(object sender, EventArgs e)
        {
            pndichuyen.Left=btnthemphong.Left+ 85;
            uC_add1.Visible = true;
            uC_add1.BringToFront();
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void TrangChu_load(object sender, EventArgs e)
        {
            uC_add1.Visible = false;
            uC_KhachHang1.Visible = false;
            uC_Checkout1.Visible = false;
            uC_Nhanvien1.Visible = false;
            uC_BaoCao1.Visible = false;
            btnthemphong.PerformClick();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }



        private void btnthanhtoan_Click(object sender, EventArgs e)
        {
            pndichuyen.Left = btnthanhtoan.Left + 85;
            uC_Checkout1.Visible = true;
            uC_Checkout1.BringToFront();
        }

        private void btndkikhachhang_Click(object sender, EventArgs e)
        {
            pndichuyen.Left = btndkikhachhang.Left + 85;
            uC_KhachHang1.Visible = true;
            uC_KhachHang1.BringToFront();

        }

        private void btnnhanvien_Click(object sender, EventArgs e)
        {
            pndichuyen.Left = btnnhanvien.Left + 85;
            uC_Nhanvien1.Visible = true;
            uC_Nhanvien1.BringToFront();
        }
    }
}
