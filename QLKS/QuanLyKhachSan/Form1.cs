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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();// Thoát khỏi ứng dụng khi nút "Thoát" được nhấn

        }

        private void btndangnhap_Click(object sender, EventArgs e)
        {
            if(txttendn.Text=="Phamdung"&& txtmatkhau.Text == "12345")
            {
                lbError.Visible = false;
                TrangChu tc=new TrangChu();
                this.Hide();
                tc.Show();

            }
            else
            {
                lbError.Visible = true;
                txtmatkhau.Clear();
            }
        }

        private void txtdnhap_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
