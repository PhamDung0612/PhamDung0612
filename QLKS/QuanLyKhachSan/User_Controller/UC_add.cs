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
    public partial class UC_add : UserControl
    {
        Chucnag cn = new Chucnag();
        String query;
        int MaPhong = -1;
        public UC_add()
        {
            InitializeComponent();
        }
        void LoadPhong()
        {
            query = "select * from Phong";
            DataSet ds = cn.getData(query);
            DataGridView1.DataSource = ds.Tables[0];
        }

        private void UC_add_Load(object sender, EventArgs e)
        {
            LoadPhong();
        }
        bool KiemTraTrungSoPhong(string soPhong, int maPhong)
        {
            string sql =
                "select count(*) from Phong " +
                "where SoPhong = '" + soPhong + "' " +
                "and (" + maPhong + " = -1 or MaPhong <> " + maPhong + ")";

            DataSet ds = cn.getData(sql);
            return Convert.ToInt32(ds.Tables[0].Rows[0][0]) > 0;
        }


        private void btnThemPhong_Click(object sender, EventArgs e)
        {
            if (txtSoPhong.Text != "" && txtLoaiPhong.Text != "" &&
         txtLoaiGiuong.Text != "" && txtGiaTien.Text != "")
            {
                string soPhong = txtSoPhong.Text.Trim();

                if (KiemTraTrungSoPhong(soPhong, -1))
                {
                    MessageBox.Show("Số phòng đã tồn tại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string loaiPhong = txtLoaiPhong.Text;
                string loaiGiuong = txtLoaiGiuong.Text;
                long giaTien = long.Parse(txtGiaTien.Text);

                query = "insert into Phong(SoPhong,LoaiPhong,LoaiGiuong,GiaPhong) " +
                        "values('" + soPhong + "','" + loaiPhong + "','" +
                        loaiGiuong + "'," + giaTien + ")";

                cn.setData(query, "Thêm phòng thành công");

                LoadPhong();
                clearAll();
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void clearAll()
        {
            txtSoPhong.Clear();
            txtLoaiPhong.SelectedIndex = -1;
            txtLoaiGiuong.SelectedIndex = -1;
            txtGiaTien.Clear();
            MaPhong = -1;
        }

        private void UC_add_Leave(object sender, EventArgs e)
        {
            clearAll();

        }

        private void UC_add_Enter(object sender, EventArgs e)
        {
            UC_add_Load(this, null);
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = DataGridView1.Rows[e.RowIndex];

            // LẤY MÃ PHÒNG
            MaPhong = Convert.ToInt32(row.Cells["MaPhong"].Value);

            // ĐỔ DỮ LIỆU LÊN FORM
            txtSoPhong.Text = row.Cells["SoPhong"].Value.ToString();
            txtLoaiPhong.Text = row.Cells["LoaiPhong"].Value.ToString();
            txtLoaiGiuong.Text = row.Cells["LoaiGiuong"].Value.ToString();
            txtGiaTien.Text = row.Cells["GiaPhong"].Value.ToString();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (MaPhong == -1)
            {
                MessageBox.Show("Vui lòng chọn phòng cần sửa");
                return;
            }

            string soPhong = txtSoPhong.Text.Trim();

            // ===== CHECK TRÙNG =====
            if (KiemTraTrungSoPhong(soPhong, MaPhong))
            {
                MessageBox.Show("Số phòng đã tồn tại!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string loaiPhong = txtLoaiPhong.Text;
            string loaiGiuong = txtLoaiGiuong.Text;
            long giaTien = long.Parse(txtGiaTien.Text);

            query =
                "update Phong set " +
                "SoPhong='" + soPhong + "', " +
                "LoaiPhong='" + loaiPhong + "', " +
                "LoaiGiuong='" + loaiGiuong + "', " +
                "GiaPhong=" + giaTien +
                " where MaPhong=" + MaPhong;

            cn.setData(query, "Cập nhật phòng thành công");

            LoadPhong();
            clearAll();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (MaPhong == -1)
            {
                MessageBox.Show("Vui lòng chọn phòng cần xoá");
                return;
            }

            // kiểm tra trạng thái phòng
            query = "select TrangThaiDat from Phong where MaPhong=" + MaPhong;
            DataSet ds = cn.getData(query);

            string trangThai = ds.Tables[0].Rows[0]["TrangThaiDat"].ToString();

            if (trangThai == "YES")
            {
                MessageBox.Show("Không thể xoá phòng đang được thuê!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xoá phòng này?",
                "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                == DialogResult.OK)
            {
                query = "delete from Phong where MaPhong=" + MaPhong;
                cn.setData(query, "Xoá phòng thành công");

                UC_add_Load(this, null);
                clearAll();
            }
        }

        private void bntk_Click(object sender, EventArgs e)
        {
            string soPhong = txtSoPhong.Text.Trim();
            string loaiPhong = txtLoaiPhong.Text.Trim();
            string loaiGiuong = txtLoaiGiuong.Text.Trim();

            query = "select * from Phong where 1=1 ";

            if (soPhong != "")
            {
                query += "and SoPhong like '%" + soPhong + "%' ";
            }

            if (loaiPhong != "" && loaiPhong != "Tất cả")
            {
                query += "and LoaiPhong = N'" + loaiPhong + "' ";
            }

            if (loaiGiuong != "" && loaiGiuong != "Tất cả")
            {
                query += "and LoaiGiuong = N'" + loaiGiuong + "' ";
            }

            DataSet ds = cn.getData(query);
            DataGridView1.DataSource = ds.Tables[0];
        }
    }
}
