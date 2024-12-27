using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DAO
{
    public class KhachHangDAO
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString;

        public List<KhachHang> GetAllKhachHangWithPhieuGoiTienCount()
        {
            var danhSach = new List<KhachHang>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                SELECT 
                    Kh.SoTaiKhoanThanhToan, 
                    Kh.TenKhachHang, 
                    Kh.CCCD, 
                    Kh.SoDienThoai, 
                    Kh.NgaySinh, 
                    Kh.DiaChi, 
                    Kh.SoDuHienCo,
                    COUNT(PGT.SoTaiKhoanTienGoi) AS TongSoPhieuGoiTien
                FROM 
                    KhachHang Kh
                LEFT JOIN 
                    PhieuGoiTien PGT ON Kh.SoTaiKhoanThanhToan = PGT.SoTaiKhoanThanhToan
                GROUP BY 
                    Kh.SoTaiKhoanThanhToan, 
                    Kh.TenKhachHang, 
                    Kh.CCCD, 
                    Kh.SoDienThoai, 
                    Kh.NgaySinh, 
                    Kh.DiaChi, 
                    Kh.SoDuHienCo";

                SqlCommand cmd = new SqlCommand(query, conn);
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
                        SoDuHienCo = (float)reader.GetDouble(6),
                        TongSoPhieuGoiTien = reader.GetInt32(7) // Thêm thông tin tổng số phiếu gửi tiền
                    });
                }
            }

            return danhSach;
        }
        public KhachHang? LayKhachHangTheoSoTaiKhoan(string soTaiKhoan)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM KhachHang WHERE SoTaiKhoanThanhToan = @SoTaiKhoanThanhToan";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@SoTaiKhoanThanhToan", soTaiKhoan);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return new KhachHang
                        {
                            TenKhachHang = reader["TenKhachHang"].ToString() ?? string.Empty,
                            SoTaiKhoanThanhToan = reader["SoTaiKhoanThanhToan"].ToString() ?? string.Empty,
                            SoDienThoai = reader["SoDienThoai"].ToString() ?? string.Empty,
                            CCCD = reader["CCCD"].ToString() ?? string.Empty,
                            NgaySinh = reader["NgaySinh"].ToString() != string.Empty ? DateTime.Parse(reader["NgaySinh"].ToString()) : DateTime.MinValue,
                            DiaChi = reader["DiaChi"].ToString() ?? string.Empty,
                            SoDuHienCo = float.Parse(reader["SoDuHienCo"].ToString() ?? "0")
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi truy vấn thông tin khách hàng: " + ex.Message);
            }
            return null;
        }
        public bool ThemKhachHang(KhachHang khachHang)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Tự động sinh số tài khoản thanh toán
                    khachHang.SoTaiKhoanThanhToan = GenerateUniqueSoTaiKhoan(conn, "ThanhToan");

                    string query = @"INSERT INTO KhachHang 
                                     (SoTaiKhoanThanhToan, TenKhachHang, SoDienThoai, CCCD, DiaChi, NgaySinh, SoDuHienCo) 
                                     VALUES 
                                     (@SoTaiKhoanThanhToan, @TenKhachHang, @SoDienThoai, @CCCD, @DiaChi, @NgaySinh, @SoDuHienCo)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@SoTaiKhoanThanhToan", khachHang.SoTaiKhoanThanhToan);
                    cmd.Parameters.AddWithValue("@TenKhachHang", khachHang.TenKhachHang);
                    cmd.Parameters.AddWithValue("@SoDienThoai", khachHang.SoDienThoai);
                    cmd.Parameters.AddWithValue("@CCCD", khachHang.CCCD);
                    cmd.Parameters.AddWithValue("@DiaChi", khachHang.DiaChi);
                    cmd.Parameters.AddWithValue("@NgaySinh", khachHang.NgaySinh);
                    cmd.Parameters.AddWithValue("@SoDuHienCo", khachHang.SoDuHienCo);


                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm khách hàng: " + ex.Message);
            }
        }
        private string GenerateUniqueSoTaiKhoan(SqlConnection conn, string loaiTaiKhoan)
        {
            Random rand = new Random();
            string soTaiKhoan;
            string prefix; // Phần đầu của số tài khoản

            // Xác định tiền tố dựa trên loại tài khoản
            if (loaiTaiKhoan == "ThanhToan")
            {
                prefix = "KH"; // Số tài khoản thanh toán
            }
            else if (loaiTaiKhoan == "GoiTien")
            {
                prefix = "PGT"; // Số tài khoản gửi tiền
            }
            else
            {
                throw new Exception("Loại tài khoản không hợp lệ!");
            }

            while (true)
            {
                if (loaiTaiKhoan == "ThanhToan")
                {
                    // Sinh số ngẫu nhiên có 8 chữ số
                    soTaiKhoan = prefix + rand.Next(10000000, 99999999).ToString();
                }
                else
                {
                    // Sinh số ngẫu nhiên có 7 chữ số
                    soTaiKhoan = prefix + rand.Next(1000000, 9999999).ToString();
                }

                string query = "SELECT COUNT(*) FROM KhachHang WHERE SoTaiKhoanThanhToan = @SoTaiKhoanThanhToan";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SoTaiKhoanThanhToan", soTaiKhoan);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count == 0) break; // Nếu không trùng lặp, thoát khỏi vòng lặp
            }

            return soTaiKhoan;
        }
        public bool CapNhatKhachHang(KhachHang khachHang)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"UPDATE KhachHang 
                                     SET TenKhachHang = @TenKhachHang, 
                                         SoDienThoai = @SoDienThoai, 
                                         CCCD = @CCCD, 
                                         DiaChi = @DiaChi, 
                                         NgaySinh = @NgaySinh, 
                                         SoDuHienCo = @SoDuHienCo
                                     WHERE SoTaiKhoanThanhToan = @SoTaiKhoanThanhToan";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@SoTaiKhoanThanhToan", khachHang.SoTaiKhoanThanhToan);
                    cmd.Parameters.AddWithValue("@TenKhachHang", khachHang.TenKhachHang);
                    cmd.Parameters.AddWithValue("@SoDienThoai", khachHang.SoDienThoai);
                    cmd.Parameters.AddWithValue("@CCCD", khachHang.CCCD);
                    cmd.Parameters.AddWithValue("@DiaChi", khachHang.DiaChi);
                    cmd.Parameters.AddWithValue("@NgaySinh", khachHang.NgaySinh);
                    cmd.Parameters.AddWithValue("@SoDuHienCo", khachHang.SoDuHienCo);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật thông tin khách hàng: " + ex.Message);
            }
        }
        public List<KhachHang> SearchKhachHang(string searchText)

        {

            var danhSach = new List<KhachHang>();

            using (SqlConnection conn = new SqlConnection(connectionString))

            {

                string query = @"

        SELECT 

            Kh.SoTaiKhoanThanhToan, 

            Kh.TenKhachHang, 

            Kh.CCCD, 

            Kh.SoDienThoai, 

            Kh.NgaySinh, 

            Kh.DiaChi, 

            Kh.SoDuHienCo,

            COUNT(PGT.SoTaiKhoanTienGoi) AS TongSoPhieuGoiTien

        FROM 

            KhachHang Kh

        LEFT JOIN 

            PhieuGoiTien PGT ON Kh.SoTaiKhoanThanhToan = PGT.SoTaiKhoanThanhToan

        WHERE 

            Kh.TenKhachHang LIKE @SearchText

            OR Kh.SoTaiKhoanThanhToan LIKE @SearchText

        GROUP BY 

            Kh.SoTaiKhoanThanhToan, 

            Kh.TenKhachHang, 

            Kh.CCCD, 

            Kh.SoDienThoai, 

            Kh.NgaySinh, 

            Kh.DiaChi, 

            Kh.SoDuHienCo";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");

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

                        SoDuHienCo = (float)reader.GetDouble(6),

                        TongSoPhieuGoiTien = reader.GetInt32(7) // Thêm thông tin tổng số phiếu gửi tiền

                    });

                }

            }

            return danhSach;

        }

    }
}
