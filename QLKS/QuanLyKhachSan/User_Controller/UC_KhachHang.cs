using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    

    public partial class UC_KhachHang : UserControl
    {
        Chucnag cn = new Chucnag();
        String query;
        int maKhachDangChon = -1;
        public UC_KhachHang()
        {
            InitializeComponent();
        }
        public void setComboBox(String query, ComboBox cb)
        {
            cb.Items.Clear();
            SqlDataReader sdr = cn.getForCombo(query);
            while (sdr.Read())
            {
                cb.Items.Add(sdr[0].ToString());
            }
            sdr.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void UC_KhachHang_Load(object sender, EventArgs e)
        {

        }
        private void txtLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSoPhong.Items.Clear();
            query = "select SoPhong from Phong where LoaiGiuong='" + txtLoaiGiuong.Text + "' and LoaiPhong='" + txtLoaiPhong.Text + "' and TrangThaiDat='NO'";
            setComboBox(query, txtSoPhong);
        }
        private void txtLoaiGiuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSoPhong.Items.Clear();
            txtGiaTien.Clear();

            if (txtLoaiPhong.SelectedIndex == -1) return;

            query = "select SoPhong from Phong where LoaiPhong=N'" + txtLoaiPhong.Text +
                    "' and LoaiGiuong=N'" + txtLoaiGiuong.Text +
                    "' and TrangThaiDat='NO'";
            setComboBox(query, txtSoPhong);
        }


        int rid;
        private void txtSoPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            query = "select GiaPhong,MaPhong from Phong where SoPhong=N'" + txtSoPhong.Text + "'";
            DataSet ds = cn.getData(query);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                txtGiaTien.Text = ds.Tables[0].Rows[0][0].ToString();
                rid = int.Parse(ds.Tables[0].Rows[0][1].ToString());
            }
            else
            {
                txtGiaTien.Clear();
                MessageBox.Show("Không tìm thấy phòng phù hợp!");
            }

        }

        private void btnKhachhang_Click(object sender, EventArgs e)
        {
            if (txtHovaTen.Text == "")
            {
                MessageBox.Show("Vui lòng nhập họ và tên");
                txtHovaTen.Focus();
                return;
            }


            if (txtSdt.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số điện thoại");
                txtSdt.Focus();
                return;
            }

            if (!txtSdt.Text.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại chỉ được chứa chữ số");
                txtSdt.Focus();
                return;
            }

            if (!txtSdt.Text.StartsWith("0"))
            {
                MessageBox.Show("Số điện thoại phải bắt đầu bằng số 0");
                txtSdt.Focus();
                return;
            }

            if (txtSdt.Text.Length != 10)
            {
                MessageBox.Show("Số điện thoại phải đủ 10 số");
                txtSdt.Focus();
                return;
            }
            query = "select count(*) from KhachHang where DienThoai=" + txtSdt.Text;
            if (Convert.ToInt32(cn.getData(query).Tables[0].Rows[0][0]) > 0)
            {
                MessageBox.Show("Số điện thoại đã tồn tại");
                txtSdt.Focus();
                return;
            }


            if (txtMaDinhDanh.Text == "")
            {
                MessageBox.Show("Vui lòng nhập CCCD");
                txtMaDinhDanh.Focus();
                return;
            }

            if (!txtMaDinhDanh.Text.All(char.IsDigit))
            {
                MessageBox.Show("CCCD chỉ được chứa chữ số");
                txtMaDinhDanh.Focus();
                return;
            }

            if (txtMaDinhDanh.Text.Length != 12)
            {
                MessageBox.Show("CCCD phải gồm đúng 12 chữ số");
                txtMaDinhDanh.Focus();
                return;
            }
            query = "select count(*) from KhachHang where GiayToTuyThan='" + txtMaDinhDanh.Text + "'";
            if (Convert.ToInt32(cn.getData(query).Tables[0].Rows[0][0]) > 0)
            {
                MessageBox.Show("CCCD đã tồn tại");
                txtMaDinhDanh.Focus();
                return;
            }


            if (txtQuocTich.Text == "")
            {
                MessageBox.Show("Vui lòng nhập quốc tịch");
                txtQuocTich.Focus();
                return;
            }

            if (txtGioitinh.Text == "")
            {
                MessageBox.Show("Vui lòng chọn giới tính");
                txtGioitinh.Focus();
                return;
            }

            if (txtDiachi.Text == "")
            {
                MessageBox.Show("Vui lòng nhập địa chỉ");
                txtDiachi.Focus();
                return;
            }

            if (txtGiaTien.Text == "")
            {
                MessageBox.Show("Vui lòng chọn phòng");
                return;
            }


            String ht = txtHovaTen.Text;
            Int64 sdt = Int64.Parse(txtSdt.Text);
            String qt = txtQuocTich.Text;
            String mdd = txtMaDinhDanh.Text;
            String gt = txtGioitinh.Text;
            DateTime ns = DateTime.Parse(txtNgaysinh.Text);
            String dc = txtDiachi.Text;
            DateTime ndk = DateTime.Parse(txtNgayDangKi.Text);

            query = "insert into KhachHang(TenKhachHang,DienThoai,QuocTich,GioiTinh,NgaySinh,GiayToTuyThan,DiaChi,NgayNhanPhong,MaPhong) " +
                    "values(N'" + ht + "'," + sdt + ",N'" + qt + "',N'" + gt + "',N'" + ns + "',N'" + mdd + "',N'" + dc + "','" + ndk + "'," + rid + ");" +
                    "update Phong set TrangThaiDat='YES' where SoPhong='" + txtSoPhong.Text + "'";

            cn.setData(query, "Đăng ký khách hàng thành công - Phòng " + txtSoPhong.Text);
            clearAll();
        }

        public void clearAll()
        {
            txtHovaTen.Clear();
            txtSdt.Clear();
            txtQuocTich.Clear();
            txtMaDinhDanh.Clear();
            txtGioitinh.SelectedIndex = -1;
            txtNgaysinh.ResetText();
            txtDiachi.Clear();
            txtNgayDangKi.ResetText();
            txtLoaiGiuong.SelectedIndex = -1;
            txtLoaiPhong.SelectedIndex = -1;
            txtSoPhong.Items.Clear();
            txtGiaTien.Clear();
        }

        private void UC_KhachHang_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        private void txtSdt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtDiachi_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = guna2DataGridView1.Rows[e.RowIndex];

            // LƯU MÃ KHÁCH
            maKhachDangChon = Convert.ToInt32(row.Cells["MaKhachHang"].Value);

            txtHovaTen.Text = row.Cells["TenKhachHang"].Value.ToString();
            txtSdt.Text = row.Cells["DienThoai"].Value.ToString();
            txtMaDinhDanh.Text = row.Cells["GiayToTuyThan"].Value.ToString();
            txtQuocTich.Text = row.Cells["QuocTich"].Value.ToString();
            txtGioitinh.Text = row.Cells["GioiTinh"].Value.ToString();
            txtDiachi.Text = row.Cells["DiaChi"].Value.ToString();
            txtNgaysinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);

            // KHÓA NÚT THÊM MỚI
            btnKhachhang.Enabled = false;
        }



        private void btnTk_Click(object sender, EventArgs e)
        {
            string key = "";

            if (!string.IsNullOrWhiteSpace(txtMaDinhDanh.Text))
                key = txtMaDinhDanh.Text.Trim();
            else if (!string.IsNullOrWhiteSpace(txtSdt.Text))
                key = txtSdt.Text.Trim();
            else if (!string.IsNullOrWhiteSpace(txtHovaTen.Text))
                key = txtHovaTen.Text.Trim();
            else
            {
                MessageBox.Show("Nhập TÊN / SĐT / CCCD để tìm");
                return;
            }

            query = @"
        SELECT 
            MaKhachHang,
            TenKhachHang,
            DienThoai,
            QuocTich,
            GioiTinh,
            NgaySinh,
            GiayToTuyThan,
            DiaChi
        FROM KhachHang
        WHERE TenKhachHang LIKE N'%" + key + @"%'
           OR DienThoai LIKE '%" + key + @"%'
           OR GiayToTuyThan LIKE '%" + key + @"%'";

            DataSet ds = cn.getData(query);

            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy khách hàng");
                guna2DataGridView1.DataSource = null;
                return;
            }

            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void btncn_Click(object sender, EventArgs e)
        {
            if (maKhachDangChon == -1)
            {
                MessageBox.Show("Vui lòng chọn khách hàng từ danh sách");
                return;
            }

            if (txtSoPhong.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn phòng");
                return;
            }

            DateTime ngayNhan = DateTime.Parse(txtNgayDangKi.Text);

            query = @"
        INSERT INTO KhachHang
        (TenKhachHang, DienThoai, QuocTich, GioiTinh, NgaySinh, GiayToTuyThan, DiaChi, NgayNhanPhong, MaPhong)
        SELECT 
            TenKhachHang, DienThoai, QuocTich, GioiTinh, NgaySinh, GiayToTuyThan, DiaChi,
            '" + ngayNhan + @"', " + rid + @"
        FROM KhachHang
        WHERE MaKhachHang = " + maKhachDangChon + @";

        UPDATE Phong
        SET TrangThaiDat = 'YES'
        WHERE SoPhong = N'" + txtSoPhong.Text + "'";

            cn.setData(query, "Thuê lại phòng thành công");

            // reset
            maKhachDangChon = -1;
            btnKhachhang.Enabled = true;
            clearAll();
        }

    }
}
