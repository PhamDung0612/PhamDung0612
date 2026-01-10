using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan.User_Controller
{
    public partial class UC_Checkout : UserControl
    {
        Chucnag cn = new Chucnag();
        String query;

        DateTime ngayNhanPhong;
        long giaPhong;
        public UC_Checkout()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            query =
                "select KhachHang.MaKhachHang,KhachHang.TenKhachHang,KhachHang.DienThoai,KhachHang.QuocTich," +
                "KhachHang.GioiTinh,KhachHang.NgaySinh,KhachHang.GiayToTuyThan,KhachHang.DiaChi,KhachHang.NgayNhanPhong," +
                "Phong.SoPhong,Phong.LoaiPhong,Phong.LoaiGiuong,Phong.GiaPhong " +
                "from KhachHang inner join Phong on KhachHang.MaPhong=Phong.MaPhong " +
                "where TrangThaiTraPhong='NO'";

            DataSet ds = cn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void UC_Checkout_Load(object sender, EventArgs e)
        {
            query = "select KhachHang.MaKhachHang,KhachHang.TenKhachHang,KhachHang.DienThoai,KhachHang.QuocTich," +
                    "KhachHang.GioiTinh,KhachHang.NgaySinh,KhachHang.GiayToTuyThan,KhachHang.DiaChi,KhachHang.NgayNhanPhong," +
                    "Phong.SoPhong,Phong.LoaiPhong,Phong.LoaiGiuong,Phong.GiaPhong " +
                    "from KhachHang inner join Phong on KhachHang.MaPhong=Phong.MaPhong " +
                    "where TrangThaiTraPhong='NO'";

            DataSet ds = cn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];


            txtNgayThanhToan.ValueChanged -= txtNgayThanhToan_ValueChanged;
            txtNgayThanhToan.ValueChanged += txtNgayThanhToan_ValueChanged;

            txtNgayThanhToan.Value = DateTime.Now;
        }



        int id;


        private void TinhTien()
        {
            DateTime ngayThanhToan = txtNgayThanhToan.Value.Date;

            int soNgay = (ngayThanhToan - ngayNhanPhong.Date).Days;

            if (soNgay <= 0)
                soNgay = 1;

            long tongTien = soNgay * giaPhong;

            txtTinhtien.Text = tongTien.ToString("N0");
        }
        private void txtNgayThanhToan_ValueChanged(object sender, EventArgs e)
        {
            if (giaPhong > 0 && ngayNhanPhong != DateTime.MinValue)
            {
                TinhTien();
            }

        }



        public void clearAll()
        {
            txtTen.Clear();
            txtHovaTen.Clear();
            txtSoPhong.Clear();
            txtNgayThanhToan.ResetText();
        }

        private void UC_Checkout_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtTen_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtSoPhong_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }





        private void txtNgayThanhToan_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void UC_Checkout_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                LoadData();
            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = guna2DataGridView1.Rows[e.RowIndex];

            id = int.Parse(row.Cells[0].Value.ToString());

            txtTen.Text = row.Cells[1].Value.ToString();
            txtSoPhong.Text = row.Cells[9].Value.ToString();

            ngayNhanPhong = DateTime.Parse(row.Cells[8].Value.ToString());
            giaPhong = long.Parse(row.Cells[12].Value.ToString());

            TinhTien();
        }

        private void txtcccd_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTk_Click_1(object sender, EventArgs e)
        {

        }

        private void txtHovaTen_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTk_Click_2(object sender, EventArgs e)
        {

            string ten = txtHovaTen.Text.Trim();
            string sdt = txtsdt.Text.Trim();
            string cccd = txtcccd.Text.Trim();

            query =
                "select KhachHang.MaKhachHang, KhachHang.TenKhachHang, KhachHang.DienThoai, " +
                "KhachHang.QuocTich, KhachHang.GioiTinh, KhachHang.NgaySinh, " +
                "KhachHang.GiayToTuyThan, KhachHang.DiaChi, KhachHang.NgayNhanPhong, " +
                "Phong.SoPhong, Phong.LoaiPhong, Phong.LoaiGiuong, Phong.GiaPhong " +
                "from KhachHang inner join Phong on KhachHang.MaPhong = Phong.MaPhong " +
                "where TrangThaiTraPhong = 'NO' ";


            if (ten != "")
            {
                query += "and TenKhachHang COLLATE Vietnamese_CI_AI like N'%" + ten + "%' ";
            }


            if (sdt != "")
            {
                query += "and DienThoai like '%" + sdt + "%' ";
            }


            if (cccd != "")
            {
                query += "and GiayToTuyThan like '%" + cccd + "%' ";
            }

            DataSet ds = cn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (txtTen.Text == "")
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần thanh toán", "Lỗi");
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn không ?", "Xác nhận",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                string ntt = txtNgayThanhToan.Text;

                query =
                    "update KhachHang " +
                    "set TrangThaiTraPhong='YES', NgayTraPhong='" + ntt + "' " +
                    "where MaKhachHang=" + id + "; " +
                    "update Phong " +
                    "set TrangThaiDat='NO' " +
                    "where SoPhong='" + txtSoPhong.Text + "'";

                cn.setData(query, "Thanh toán thành công - Phòng " + txtSoPhong.Text);

                LoadData();
                clearAll();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtNgayThanhToan_ValueChanged_2(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtTinhtien_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
