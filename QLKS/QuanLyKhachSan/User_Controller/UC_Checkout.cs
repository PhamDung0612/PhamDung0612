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
        public static UC_Checkout Instance;

        DateTime ngayNhanPhong;
        long giaPhong = 0;
        long tongTien = 0;        // tiền gốc
        long soTienPhaiTra = 0;   // tiền sau khuyến mãi
        int id = -1;
        public UC_Checkout()
        {
            InitializeComponent();
            Instance = this;
            LoadKhuyenMai();

            txtNgayThanhToan.ValueChanged += txtNgayThanhToan_ValueChanged;

            cbKhuyenMai.SelectedIndexChanged += cbKhuyenMai_SelectedIndexChanged;
            txtNgayThanhToan.Value = DateTime.Now;
        }
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (this.Visible)
            {
                LoadData();
                clearAll();
            }
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
        private void LoadKhuyenMai()
        {
            cbKhuyenMai.Items.Clear();
            cbKhuyenMai.Items.Add("Không áp dụng");
            cbKhuyenMai.Items.Add("Giảm 10%");
            cbKhuyenMai.Items.Add("Giảm 20%");
            cbKhuyenMai.Items.Add("Giảm 30%");
            cbKhuyenMai.Items.Add("Giảm 50.000");
            cbKhuyenMai.Items.Add("Giảm 100.000");
            cbKhuyenMai.SelectedIndex = 0;
        }


        private void TinhTien()
        {
            if (giaPhong <= 0 || ngayNhanPhong == DateTime.MinValue) return;

            DateTime ngayThanhToan = txtNgayThanhToan.Value.Date;
            int soNgay = (ngayThanhToan - ngayNhanPhong.Date).Days;
            if (soNgay <= 0) soNgay = 1;

            tongTien = soNgay * giaPhong;

            // nếu chưa chọn khuyến mãi thì tiền = tiền gốc
            if (cbKhuyenMai.SelectedIndex <= 0)
                soTienPhaiTra = tongTien;

            txtTinhtien.Text = soTienPhaiTra.ToString("N0");

            // áp dụng lại khuyến mãi (nếu có)
            cbKhuyenMai_SelectedIndexChanged(null, null);
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
                if (UC_BaoCao.Instance != null)
                {
                    UC_BaoCao.Instance.ReloadBaoCao();
                }
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

        private void cbKhuyenMai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tongTien <= 0) return;

            soTienPhaiTra = tongTien;

            switch (cbKhuyenMai.Text)
            {
                case "Giảm 10%":
                    soTienPhaiTra = tongTien * 90 / 100;
                    break;
                case "Giảm 20%":
                    soTienPhaiTra = tongTien * 80 / 100;
                    break;
                case "Giảm 30%":
                    soTienPhaiTra = tongTien * 70 / 100;
                    break;
                case "Giảm 50.000":
                    soTienPhaiTra = tongTien - 50000;
                    break;
                case "Giảm 100.000":
                    soTienPhaiTra = tongTien - 100000;
                    break;
                default:
                    soTienPhaiTra = tongTien;
                    break;
            }

            if (soTienPhaiTra < 0)
                soTienPhaiTra = 0;

            txtTinhtien.Text = soTienPhaiTra.ToString("N0");
        }
    }
}
