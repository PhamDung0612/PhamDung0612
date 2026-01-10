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
        public UC_add()
        {
            InitializeComponent();
        }

        private void UC_add_Load(object sender, EventArgs e)
        {
            query = "select * from Phong";
            DataSet ds = cn.getData(query);
            DataGridView1.DataSource = ds.Tables[0];
        }

        private void btnThemPhong_Click(object sender, EventArgs e)
        {
            if (txtSoPhong.Text != "" && txtLoaiPhong.Text != "" && txtLoaiGiuong.Text != "" && txtGiaTien.Text != "")
            {
                String soPhong = txtSoPhong.Text;
                String loaiPhong = txtLoaiPhong.Text;
                String loaiGiuong = txtLoaiGiuong.Text;
                Int64 giaTien = Int64.Parse(txtGiaTien.Text);


                query = "insert into Phong(SoPhong,LoaiPhong,LoaiGiuong,GiaPhong) values('" + soPhong + "','" + loaiPhong + "','" + loaiGiuong + "'," + giaTien + ")";
                cn.setData(query, "Thêm phòng thành công");

                UC_add_Load(this, null);
                clearAll();

            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void clearAll()
        {
            txtSoPhong.Clear();
            txtLoaiPhong.SelectedIndex = -1;
            txtLoaiGiuong.SelectedIndex = -1;
            txtGiaTien.Clear();
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

        }
    }
}
