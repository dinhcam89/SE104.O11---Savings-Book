using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class GuiThemTienDAO
    {
        private string connectionString = "Data Source=CONALNGUYEN\\NGUYENCHAU;Initial Catalog=saving_books_management;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        public DateTime GetNgayDaoHanKeTiep(string soTaiKhoanTienGoi)
        {
            string query = "SELECT NgayDaoHanKeTiep FROM PhieuGoiTien WHERE SoTaiKhoanTienGoi = @SoTaiKhoanTienGoi";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SoTaiKhoanTienGoi", soTaiKhoanTienGoi);
                conn.Open();

                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToDateTime(result) : DateTime.MinValue;
            }
        }

        public bool UpdateTongTienGoc(string soTaiKhoanTienGoi, float soTienGuiThem)
        {
            string query = "UPDATE PhieuGoiTien " +
                           "SET TongTienGoc = TongTienGoc + @SoTienGuiThem " +
                           "WHERE SoTaiKhoanTienGoi = @SoTaiKhoanTienGoi";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SoTaiKhoanTienGoi", soTaiKhoanTienGoi);
                cmd.Parameters.AddWithValue("@SoTienGuiThem", soTienGuiThem);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool InsertChiTietGuiTien(ChiTietGuiTien chiTietGoiTien)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Lấy mã lớn nhất hiện tại
                string getMaxIdQuery = @"
                SELECT ISNULL(MAX(CAST(SUBSTRING(MaChiTietGoiTien, 4, LEN(MaChiTietGoiTien)) AS INT)), 0) + 1 
                FROM ChiTietGoiTien";
                SqlCommand getMaxIdCmd = new SqlCommand(getMaxIdQuery, conn);
                int newIdNumber = Convert.ToInt32(getMaxIdCmd.ExecuteScalar());

                // Tạo mã mới với tiền tố "CRT"
                string newMaChiTietGoiTien = $"CGT{newIdNumber:D7}";

                // Chèn dữ liệu mới
                string insertQuery = @"
                INSERT INTO ChiTietGoiTien (MaChiTietGoiTien, SoTaiKhoanTienGoi, NgayGoi, SoTienGoi) 
                VALUES (@MaChiTietGoiTien, @SoTaiKhoanTienGoi, @NgayGoi, @SoTienGoi)";
                SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                insertCmd.Parameters.AddWithValue("@MaChiTietGoiTien", newMaChiTietGoiTien);
                insertCmd.Parameters.AddWithValue("@SoTaiKhoanTienGoi", chiTietGoiTien.SoTaiKhoanGuiTien);
                insertCmd.Parameters.AddWithValue("@NgayGoi", chiTietGoiTien.NgayGui);
                insertCmd.Parameters.AddWithValue("@SoTienGoi", chiTietGoiTien.SoTienGui);

                return insertCmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
