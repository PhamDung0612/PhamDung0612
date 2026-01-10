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
    public partial class UC_Nhanvien : UserControl
    {
        Chucnag cn = new Chucnag();
        String query;
        public UC_Nhanvien()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void UC_Nhanvien_Load(object sender, EventArgs e)
        {
            getMaxID();
            cbTkGt.SelectedIndex = -1;
        }
        //------------------
        public void getMaxID()
        {
            query = "select max(MaNhanVien) from NhanVien";
            DataSet ds = cn.getData(query);

            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                Int64 num = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                labelToSET.Text = (num + 1).ToString();

            }
        }

        private void btnDk_Click(object sender, EventArgs e)
        {
            if (txtTen.Text == "" || txtSdt.Text == "" || txtGt.Text == "" ||
        txtEmail.Text == "" || txtTnd.Text == "" || txtMk.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            string ten = txtTen.Text.Trim();
            string dt = txtSdt.Text.Trim();     // SĐT dạng chuỗi
            string gt = txtGt.Text.Trim();
            string email = txtEmail.Text.Trim();
            string tnd = txtTnd.Text.Trim();
            string mk = txtMk.Text.Trim();

            //Kiểm tra SĐT chỉ là số
            if (!dt.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại chỉ được chứa chữ số!");
                return;
            }

            //Kiểm tra SĐT đúng 10 số
            if (dt.Length != 10)
            {
                MessageBox.Show("Số điện thoại phải đúng 10 chữ số!");
                return;
            }

            //Kiểm tra Gmail có @gmail.com
            if (!email.EndsWith("@gmail.com"))
            {
                MessageBox.Show("Email phải là Gmail (vd: abc@gmail.com)!");
                return;
            }

            query = "insert into NhanVien (TenNhanVien,DienThoai,GioiTinh,Email,TenDangNhap,MatKhau) " +
                    "values(N'" + ten + "','" + dt + "',N'" + gt + "','" + email + "','" + tnd + "','" + mk + "')";
            cn.setData(query, "Đăng ký nhân viên thành công!!");

            clearAll();
            getMaxID();
        }

        public void clearAll()
        {
            txtTen.Clear();
            txtSdt.Clear();
            txtGt.SelectedIndex = -1;
            txtEmail.Clear();
            txtTnd.Clear();
            txtMk.Clear();
        }

        private void tabNv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabNv.SelectedIndex == 1)
            {
                setNv(dgvttnv);
            }
            else if (tabNv.SelectedIndex == 2)
            {
                setNv(dgvxnv);
            }
        }
        public void setNv(DataGridView dgv)
        {
            query = "Select * from NhanVien";
            DataSet ds = cn.getData(query);
            dgv.DataSource = ds.Tables[0];
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "")
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    query = "delete from NhanVien where MaNhanVien =" + txtId.Text + "";
                    cn.setData(query, "Thông tin nhân viên đã được xóa");
                    //tabNv_SelectedIndexChanged(this, null);
                   
                    // reload ngay tại tab Xóa (index 3)
                    setNv(dgvxnv);
                    dgvxnv.Refresh();
                    // nếu muốn tab Chi tiết cũng cập nhật luôn
                    setNv(dgvttnv);
                    dgvttnv.Refresh();
                     txtId.Clear();
                }
            }
        }

        private void UC_Nhanvien_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        private void dgvttnv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvttnv.Rows[e.RowIndex];
            if (row.IsNewRow) return;

            // Đổ dữ liệu sang tab sửa
            txtSuaId.Text = row.Cells["MaNhanVien"].Value.ToString();
            txtSuaTen.Text = row.Cells["TenNhanVien"].Value.ToString();
            txtSuaSdt.Text = row.Cells["DienThoai"].Value.ToString();
            cbSuaGt.Text = row.Cells["GioiTinh"].Value.ToString();
            txtSuaEmail.Text = row.Cells["Email"].Value.ToString();
            txtSuaTnd.Text = row.Cells["TenDangNhap"].Value.ToString();
            txtSuaMk.Text = row.Cells["MatKhau"].Value.ToString();

            // Chuyển sang tab sửa
            tabNv.SelectedIndex = 2; // index tab sửa
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtSuaId.Text == "")
            {
                MessageBox.Show("Chưa chọn nhân viên cần sửa!");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSuaTen.Text) ||
                string.IsNullOrWhiteSpace(txtSuaSdt.Text) ||
                string.IsNullOrWhiteSpace(cbSuaGt.Text) ||
                string.IsNullOrWhiteSpace(txtSuaEmail.Text) ||
                string.IsNullOrWhiteSpace(txtSuaTnd.Text) ||
                string.IsNullOrWhiteSpace(txtSuaMk.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            string dt = txtSuaSdt.Text.Trim();
            if (!dt.All(char.IsDigit) || dt.Length != 10)
            {
                MessageBox.Show("Số điện thoại phải đúng 10 chữ số!");
                return;
            }

            if (!txtSuaEmail.Text.Trim().EndsWith("@gmail.com"))
            {
                MessageBox.Show("Email phải là Gmail (vd: abc@gmail.com)!");
                return;
            }

            query = "update NhanVien set " +
                    "TenNhanVien = N'" + txtSuaTen.Text + "', " +
                    "DienThoai = '" + dt + "', " +
                    "GioiTinh = N'" + cbSuaGt.Text + "', " +
                    "Email = '" + txtSuaEmail.Text + "', " +
                    "TenDangNhap = '" + txtSuaTnd.Text + "', " +
                    "MatKhau = '" + txtSuaMk.Text + "' " +
                    "where MaNhanVien = " + txtSuaId.Text;

            cn.setData(query, "Cập nhật nhân viên thành công!");

            setNv(dgvttnv);
            tabNv.SelectedIndex = 1;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string ten = txtTkTen.Text.Trim();
            string sdt = txtTkSdt.Text.Trim();

            // Vì combo chỉ có Nam/Nữ
            string gt = cbTkGt.SelectedItem == null ? "" : cbTkGt.Text.Trim();

            query = "select * from NhanVien where 1=1 ";

            if (ten != "")
                query += "and TenNhanVien like N'%" + ten + "%' ";

            if (sdt != "")
                query += "and DienThoai like '%" + sdt + "%' ";

            if (gt != "")
                query += "and GioiTinh = N'" + gt + "' ";

            DataSet ds = cn.getData(query);
            dgvttnv.DataSource = ds.Tables[0];
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTkTen.Clear();
            txtTkSdt.Clear();

            // Bỏ chọn giới tính
            cbTkGt.SelectedIndex = -1;

            setNv(dgvttnv);
        }
    }
}
