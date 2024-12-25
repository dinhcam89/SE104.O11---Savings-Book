using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;
using System.Drawing.Text;
namespace DAO
{
    public class PhieuGoiTienDAO
    {
        private string connectionString = @"Server=MSI\SQLEXPRESS;Database=saving_books_management;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True";
        public List<PhieuGoiTien> GetAllPhieuGoiTienWithKhachHang()
        {
            List<PhieuGoiTien> result = new List<PhieuGoiTien>();

            string query = @"
            SELECT 
                pg.SoTaiKhoanTienGoi,
                pg.SoTaiKhoanThanhToan,
                pg.MaLoaiTietKiem,
                pg.LaiSuatApDung,
                pg.LaiSuatPhatSinh,
                pg.NgayGoi,
                pg.NgayDaoHanKeTiep,
                pg.TongTienGoc,
                pg.TongTienLaiPhatSinh,
                pg.HinhThucGiaHan,
                kh.TenKhachHang
            FROM    
                PhieuGoiTien pg
            JOIN 
                KhachHang kh ON pg.SoTaiKhoanThanhToan = kh.SoTaiKhoanThanhToan";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var phieuGoiTien = new PhieuGoiTien
                    {
                        SoTaiKhoanTienGoi = reader["SoTaiKhoanTienGoi"].ToString(),
                        SoTaiKhoanThanhToan = reader["SoTaiKhoanThanhToan"].ToString(),
                        TenKhachHang = reader["TenKhachHang"].ToString(), // Gán tên khách hàng
                        MaLoaiTietKiem = reader["MaLoaiTietKiem"].ToString(),
                        LaiSuatApDung = Convert.ToSingle(reader["LaiSuatApDung"]),
                        LaiSuatPhatSinh = Convert.ToSingle(reader["LaiSuatPhatSinh"]),
                        NgayGoi = Convert.ToDateTime(reader["NgayGoi"]),
                        NgayDaoHanKeTiep = Convert.ToDateTime(reader["NgayDaoHanKeTiep"]),
                        TongTienGoc = Convert.ToSingle(reader["TongTienGoc"]),
                        TongTienLaiPhatSinh = Convert.ToSingle(reader["TongTienLaiPhatSinh"]),
                        HinhThucGiaHan = Convert.ToInt32(reader["HinhThucGiaHan"])
                    };

                    result.Add(phieuGoiTien);
                }
            }

            return result;
        }

        public bool ThemPhieuGoiTien(PhieuGoiTien phieu)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                phieu.SoTaiKhoanTienGoi = GenerateUniqueSoTaiKhoan(conn, "GoiTien");

                string query = @"INSERT INTO PhieuGoiTien 
                         (SoTaiKhoanTienGoi, SoTaiKhoanThanhToan, MaLoaiTietKiem, LaiSuatApDung, LaiSuatPhatSinh, NgayGoi, NgayDaoHanKeTiep, TongTienGoc, TongTienLaiPhatSinh, HinhThucGiaHan) 
                         VALUES 
                         (@SoTaiKhoanTienGoi, @SoTaiKhoanThanhToan, @MaLoaiTietKiem, @LaiSuatApDung, @LaiSuatPhatSinh, @NgayGoi, @NgayDaoHanKeTiep, @TongTienGoc, @TongTienLaiPhatSinh, @HinhThucGiaHan)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SoTaiKhoanTienGoi", phieu.SoTaiKhoanTienGoi); // Đảm bảo giá trị không NULL
                cmd.Parameters.AddWithValue("@SoTaiKhoanThanhToan", phieu.SoTaiKhoanThanhToan);
                cmd.Parameters.AddWithValue("@MaLoaiTietKiem", phieu.MaLoaiTietKiem);
                cmd.Parameters.AddWithValue("@LaiSuatApDung", phieu.LaiSuatApDung);
                cmd.Parameters.AddWithValue("@LaiSuatPhatSinh", phieu.LaiSuatPhatSinh);
                cmd.Parameters.AddWithValue("@NgayGoi", phieu.NgayGoi);
                cmd.Parameters.AddWithValue("@NgayDaoHanKeTiep", phieu.NgayDaoHanKeTiep);
                cmd.Parameters.AddWithValue("@TongTienGoc", phieu.TongTienGoc);
                cmd.Parameters.AddWithValue("@TongTienLaiPhatSinh", phieu.TongTienLaiPhatSinh);
                cmd.Parameters.AddWithValue("@HinhThucGiaHan", phieu.HinhThucGiaHan);

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
        private string GenerateUniqueSoTaiKhoan(SqlConnection conn, string loaiTaiKhoan)
        {
            Random rand = new Random();
            string soTaiKhoan;
            string prefix;

            // Xác định tiền tố dựa trên loại tài khoản
            if (loaiTaiKhoan == "ThanhToan")
            {
                prefix = "KH"; // Tiền tố cho tài khoản thanh toán
            }
            else if (loaiTaiKhoan == "GoiTien")
            {
                prefix = "PGT"; // Tiền tố cho tài khoản gửi tiền
            }
            else
            {
                throw new Exception("Loại tài khoản không hợp lệ!");
            }

            while (true)
            {
                if (loaiTaiKhoan == "ThanhToan")
                {
                    soTaiKhoan = prefix + rand.Next(10000000, 99999999).ToString(); // Sinh 8 chữ số
                }
                else
                {
                    soTaiKhoan = prefix + rand.Next(1000000, 9999999).ToString(); // Sinh 7 chữ số
                }

                string query = "SELECT COUNT(*) FROM PhieuGoiTien WHERE SoTaiKhoanTienGoi = @SoTaiKhoan";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SoTaiKhoan", soTaiKhoan);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count == 0) break; // Nếu không trùng lặp, thoát khỏi vòng lặp
            }

            return soTaiKhoan;
        }

        public List<PhieuGoiTien> SearchPhieuGoiTien(string searchText)
        {
            var danhSach = new List<PhieuGoiTien>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT 
                pg.SoTaiKhoanTienGoi, pg.SoTaiKhoanThanhToan, pg.MaLoaiTietKiem, 
                pg.LaiSuatApDung, pg.LaiSuatPhatSinh, pg.NgayGoi, 
                pg.NgayDaoHanKeTiep, pg.TongTienGoc, pg.TongTienLaiPhatSinh, 
                pg.HinhThucGiaHan, kh.TenKhachHang
            FROM 
                PhieuGoiTien pg
            JOIN 
                KhachHang kh ON pg.SoTaiKhoanThanhToan = kh.SoTaiKhoanThanhToan
            WHERE 
                pg.SoTaiKhoanTienGoi LIKE @SearchText
                OR pg.SoTaiKhoanThanhToan LIKE @SearchText
                OR kh.TenKhachHang LIKE @SearchText";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SearchText", $"%{searchText}%");

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    danhSach.Add(new PhieuGoiTien
                    {
                        SoTaiKhoanTienGoi = reader.GetString(0),
                        SoTaiKhoanThanhToan = reader.GetString(1),
                        MaLoaiTietKiem = reader.GetString(2),
                        LaiSuatApDung = (float)reader.GetDouble(3),
                        LaiSuatPhatSinh = (float)reader.GetDouble(4),
                        NgayGoi = reader.GetDateTime(5),
                        NgayDaoHanKeTiep = reader.GetDateTime(6),
                        TongTienGoc = (float)reader.GetDouble(7),
                        TongTienLaiPhatSinh = (float)reader.GetDouble(8),
                        HinhThucGiaHan = reader.GetInt32(9),
                        TenKhachHang = reader.GetString(10)
                    });
                }
            }

            return danhSach;
        }

    }
}

