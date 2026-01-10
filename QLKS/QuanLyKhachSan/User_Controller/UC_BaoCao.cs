using Guna.UI2.WinForms;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyKhachSan.User_Controller
{
    public partial class UC_BaoCao : UserControl
    {
        Chucnag cn = new Chucnag();

        public UC_BaoCao()
        {
            InitializeComponent();
            Load += UC_BaoCao_Load;
        }

        private void UC_BaoCao_Load(object sender, EventArgs e)
        {
            // Không chạy SQL khi mở Designer
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            LoadBaoCaoDoanhThu();
            LoadBaoCaoKhachHang();
            LoadBaoCaoLoaiPhong();
        }

        // ================= THỐNG KÊ DOANH THU (GIỐNG CHECKOUT) =================
        void LoadBaoCaoDoanhThu()
        {
            // ===== SQL DÙNG SUBQUERY (AN TOÀN GROUP BY) =====
            string sql = @"
                SELECT
                    NgayThanhToan,
                    SUM(
                        CASE 
                            WHEN SoNgay <= 0 THEN GiaPhong
                            ELSE SoNgay * GiaPhong
                        END
                    ) AS DoanhThu
                FROM
                (
                    SELECT
                        TRY_CONVERT(date, k.NgayTraPhong, 101) AS NgayThanhToan,
                        DATEDIFF(
                            DAY,
                            TRY_CONVERT(date, k.NgayNhanPhong, 101),
                            TRY_CONVERT(date, k.NgayTraPhong, 101)
                        ) AS SoNgay,
                        p.GiaPhong
                    FROM KhachHang k
                    JOIN Phong p ON k.MaPhong = p.MaPhong
                    WHERE 
                        k.TrangThaiTraPhong = 'YES'
                        AND TRY_CONVERT(date, k.NgayNhanPhong, 101) IS NOT NULL
                        AND TRY_CONVERT(date, k.NgayTraPhong, 101) IS NOT NULL
                ) AS T
                GROUP BY NgayThanhToan
                ORDER BY DoanhThu DESC";

            DataSet ds = cn.getData(sql);
            DataTable raw = ds.Tables[0];

            // ===== TẠO DATATABLE HIỂN THỊ (NGÀY = STRING) =====
            DataTable table = new DataTable();
            table.Columns.Add("Ngày Thanh Toán", typeof(string));
            table.Columns.Add("Doanh Thu", typeof(decimal));

            decimal tong = 0;

            foreach (DataRow r in raw.Rows)
            {
                string ngay = Convert
                    .ToDateTime(r["NgayThanhToan"])
                    .ToString("dd/MM/yyyy");

                decimal doanhThu = r["DoanhThu"] != DBNull.Value
                    ? Convert.ToDecimal(r["DoanhThu"])
                    : 0;

                table.Rows.Add(ngay, doanhThu);
                tong += doanhThu;
            }

            // ===== THÊM DÒNG TỔNG =====
            table.Rows.Add("TỔNG", tong);

            // ===== ĐỔ RA GRID =====
            dgvDoanhThu.DataSource = table;

            // ===== GIAO DIỆN =====
            dgvDoanhThu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDoanhThu.Columns["Doanh Thu"].DefaultCellStyle.Format = "N0";
            dgvDoanhThu.ReadOnly = true;
            dgvDoanhThu.AllowUserToAddRows = false;

            // ===== TÔ ĐẬM DÒNG TỔNG =====
            dgvDoanhThu.Rows[dgvDoanhThu.Rows.Count - 1]
                .DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        }

        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UC_BaoCao_Load_1(object sender, EventArgs e)
        {

        }
        void LoadBaoCaoKhachHang()
        {
            string sql = @"
        SELECT
            k.TenKhachHang      AS [Tên Khách Hàng],
            k.DienThoai         AS [Điện Thoại],
            k.QuocTich          AS [Quốc Tịch],
            k.GioiTinh          AS [Giới Tính],
            COUNT(*)            AS [Số Lần Thuê]
        FROM KhachHang k
        GROUP BY 
            k.TenKhachHang,
            k.DienThoai,
            k.QuocTich,
            k.GioiTinh
        ORDER BY [Số Lần Thuê] DESC";

            DataSet ds = cn.getData(sql);
            dgvKhachHang.DataSource = ds.Tables[0];

            dgvKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKhachHang.ReadOnly = true;
            dgvKhachHang.AllowUserToAddRows = false;
        }
        void LoadBaoCaoLoaiPhong()
        {
            string sql = @"
        SELECT
            p.LoaiPhong      AS [Loại Phòng],
            p.LoaiGiuong     AS [Loại Giường],
            COUNT(*)         AS [Số Lần Thuê]
        FROM KhachHang k
        JOIN Phong p ON k.MaPhong = p.MaPhong
        GROUP BY 
            p.LoaiPhong,
            p.LoaiGiuong
        ORDER BY [Số Lần Thuê] DESC";

            DataSet ds = cn.getData(sql);
            dgvLoaiPhong.DataSource = ds.Tables[0];

            dgvLoaiPhong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLoaiPhong.ReadOnly = true;
            dgvLoaiPhong.AllowUserToAddRows = false;
        }
        void ExportBaoCaoExcel()
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet sheet = workbook.ActiveSheet;

            excelApp.Visible = true;

            int row = 1;

            // ===== TIÊU ĐỀ LỚN =====
            sheet.Cells[row, 1] = "BÁO CÁO THỐNG KÊ KHÁCH SẠN";
            sheet.Range["A1", "F1"].Merge();
            sheet.Range["A1"].Font.Size = 16;
            sheet.Range["A1"].Font.Bold = true;
            sheet.Range["A1"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            row += 2;

            // ================= I. DOANH THU =================
            sheet.Cells[row, 1] = "I. DOANH THU";
            sheet.Cells[row, 1].Font.Bold = true;
            row++;

            row = WriteDataGridViewToExcel(sheet, dgvDoanhThu, row);
            row += 2;

            // ================= II. KHÁCH HÀNG =================
            sheet.Cells[row, 1] = "II. KHÁCH HÀNG";
            sheet.Cells[row, 1].Font.Bold = true;
            row++;

            row = WriteDataGridViewToExcel(sheet, dgvKhachHang, row);
            row += 2;

            // ================= III. LOẠI PHÒNG =================
            sheet.Cells[row, 1] = "III. LOẠI PHÒNG";
            sheet.Cells[row, 1].Font.Bold = true;
            row++;

            row = WriteDataGridViewToExcel(sheet, dgvLoaiPhong, row);

            sheet.Columns.AutoFit();

            

        }
        int WriteDataGridViewToExcel(Excel.Worksheet sheet, DataGridView dgv, int startRow)
        {
            int colCount = dgv.Columns.Count;

            // Header
            for (int i = 0; i < colCount; i++)
            {
                sheet.Cells[startRow, i + 1] = dgv.Columns[i].HeaderText;
                sheet.Cells[startRow, i + 1].Font.Bold = true;
            }

            // Data
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    sheet.Cells[startRow + i + 1, j + 1] =
                        dgv.Rows[i].Cells[j].Value?.ToString();
                }
            }

            return startRow + dgv.Rows.Count + 1;
        }


        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            ExportBaoCaoExcel();
        }
    }
}
