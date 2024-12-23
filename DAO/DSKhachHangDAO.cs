using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class DSKhachHangDAO
    {
        private string connectionString = @"Server=MSI\SQLEXPRESS;Database=saving_books_management;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True";

        // Hàm lấy danh sách tất cả khách hàng
        public List<KhachHang> GetAllCustomers()
        {
            var customers = new List<KhachHang>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT Kh.SoTaiKhoanThanhToan, Kh.TenKhachHang, Kh.NgaySinh, Kh.DiaChi, Kh.SoDienThoai, Kh.CCCD, Kh.SoDuHienCo
                    FROM KhachHang Kh";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customers.Add(new KhachHang
                        {
                            SoTaiKhoanThanhToan = reader.GetString(0),
                            TenKhachHang = reader.GetString(1),
                            CCCD = reader.GetString(2),
                            SoDienThoai = reader.GetString(3),
                            NgaySinh = reader.GetDateTime(4),
                            DiaChi = reader.GetString(5),
                            SoDuHienCo = reader.GetFloat(6)
                        });
                    }
                }
            }
            return customers;
        }

        // Hàm đếm số lượng sổ tiết kiệm của một khách hàng
        public int GetSavingsCount(string soTaiKhoanThanhToan)
        {
            int count = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM PhieuGoiTien WHERE SoTaiKhoanThanhToan = @SoTaiKhoanThanhToan";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SoTaiKhoanThanhToan", soTaiKhoanThanhToan);

                conn.Open();
                count = (int)cmd.ExecuteScalar();
            }

            return count;
        }

        // Hàm tìm kiếm khách hàng dựa trên từ khóa
        public List<KhachHang> SearchKhachHang(string searchText)
        {
            var danhSach = new List<KhachHang>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT Kh.SoTaiKhoanThanhToan, Kh.TenKhachHang, Kh.NgaySinh, Kh.DiaChi, Kh.SoDienThoai, Kh.CCCD, Kh.SoDuHienCo
                    FROM KhachHang Kh
                    WHERE Kh.TenKhachHang LIKE @SearchText
                       OR Kh.SoTaiKhoanThanhToan LIKE @SearchText
                       OR Kh.CCCD LIKE @SearchText";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SearchText", $"%{searchText}%");

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    danhSach.Add(new KhachHang
                    {
                        SoTaiKhoanThanhToan = reader.GetString(0),
                        TenKhachHang = reader.GetString(1),
                        CCCD = reader.GetString(2),
                        SoDienThoai = reader.GetString(3),
                        NgaySinh = reader.GetDateTime(4),
                        DiaChi = reader.GetString(5),
                        SoDuHienCo = reader.GetFloat(6)
                    });
                }
            }

            return danhSach;
        }
    }
}
