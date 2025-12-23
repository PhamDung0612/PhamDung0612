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
            query = "select KhachHang.MaKhachHang,KhachHang.TenKhachHang,KhachHang.DienThoai,KhachHang.QuocTich,KhachHang.GioiTinh,KhachHang.NgaySinh,KhachHang.GiayToTuyThan,KhachHang.DiaChi,KhachHang.NgayNhanPhong," +
                "Phong.SoPhong,Phong.LoaiPhong,Phong.LoaiGiuong,Phong.GiaPhong from KhachHang inner join Phong on KhachHang.MaPhong=Phong.MaPhong where TrangThaiTraPhong='NO'";
            DataSet ds = cn.getData(query);
            guna2DataGridView1.AutoGenerateColumns = true;
            guna2DataGridView1.DataSource = ds.Tables[0];


        }

        private void txtHovaTen_TextChanged(object sender, EventArgs e)
        {
            query = "select KhachHang.MaKhachHang,KhachHang.TenKhachHang,KhachHang.DienThoai,KhachHang.QuocTich,KhachHang.GioiTinh,KhachHang.NgaySinh,KhachHang.GiayToTuyThan,KhachHang.DiaChi,KhachHang.NgayNhanPhong," +
                "Phong.SoPhong,Phong.LoaiPhong,Phong.LoaiGiuong,Phong.GiaPhong from KhachHang inner join Phong on KhachHang.MaPhong=Phong.MaPhong where TrangThaiTraPhong='NO' and TenKhachHang COLLATE Vietnamese_CI_AI  like N'%" + txtHovaTen.Text + "%'";
            DataSet ds = cn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }
        int id;
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; 
            if (e.ColumnIndex < 0) return;
            if (guna2DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
 
                id = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtTen.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtSoPhong.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            }
        }

        private void btnThoanhToan_Click(object sender, EventArgs e)
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

                UC_Checkout_Load(this, null);
                clearAll();
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
    }
}
