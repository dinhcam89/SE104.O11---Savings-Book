<<<<<<< HEAD
﻿namespace DAO
{
    public class Class1
    {

=======
﻿using System;
using System.Data.SqlClient;
using DTO;
namespace DAO
{
    public class KhachHangDAO
    {
        private string connectionString = @"Data Source=CL-5CD6492KYP;Initial Catalog=saving_books_managements;Integrated Security=True";

        public bool ThemKhachHang(KhachHangDTO khachHang)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Sinh số tài khoản ngẫu nhiên và đảm bảo không trùng lặp
                    int soTaiKhoanThanhToan = GenerateUniqueSoTaiKhoan(conn);
                    khachHang.SoTaiKhoanThanhToan = soTaiKhoanThanhToan;
                    if (khachHang.SoDuHienCo == 0)
                    {
                        khachHang.SoDuHienCo = 0;
                    }

                    // Câu lệnh INSERT
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
                    cmd.Parameters.AddWithValue("@NgaySinh", khachHang.NgaySinh ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SoDuHienCo", khachHang.SoDuHienCo);

                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Lỗi cơ sở dữ liệu: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi hệ thống: " + ex.Message);
            }
        }

        // Hàm sinh số tài khoản ngẫu nhiên và đảm bảo không trùng
        private int GenerateUniqueSoTaiKhoan(SqlConnection conn)
        {
            Random rand = new Random();
            int soTaiKhoan;

            while (true)
            {
                soTaiKhoan = rand.Next(100000, 1000000); // Sinh số ngẫu nhiên từ 100000 đến 999999

                // Kiểm tra xem số tài khoản đã tồn tại chưa
                string query = "SELECT COUNT(*) FROM KhachHang WHERE SoTaiKhoanThanhToan = @SoTaiKhoanThanhToan";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SoTaiKhoanThanhToan", soTaiKhoan);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count == 0) break; // Nếu không trùng, thoát khỏi vòng lặp
            }

            return soTaiKhoan;
        }
    }

    public class PhieuGoiTienDAO
    {
        private string connectionString = @"Data Source=CL-5CD6492KYP;Initial Catalog=saving_books_managements;Integrated Security=True";

        public bool ThemPhieuGoiTien(PhieuGoiTienDTO phieu)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"INSERT INTO PhieuGoiTien 
                                 (SoTaiKhoanThanhToan, MaLoaiTietKiem, LaiSuatApDung, LaiSuatPhatSinh, NgayGoi, NgayDaoHanKeTiep, TongTienGoc, TongTienLaiPhatSinh, HinhThucGiaHan) 
                                 VALUES 
                                 (@SoTaiKhoanThanhToan, @MaLoaiTietKiem, @LaiSuatApDung, @LaiSuatPhatSinh, @NgayGoi, @NgayDaoHanKeTiep, @TongTienGoc, @TongTienLaiPhatSinh, @HinhThucGiaHan)";

                SqlCommand cmd = new SqlCommand(query, conn);
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

        public LoaiTietKiemDTO GetLoaiTietKiemByMa(int maLoaiTietKiem)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM LoaiTietKiem WHERE MaLoaiTietKiem = @MaLoaiTietKiem";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaLoaiTietKiem", maLoaiTietKiem);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new LoaiTietKiemDTO
                    {
                        MaLoaiTietKiem = reader.GetInt32(0),
                        KyHan = reader.GetInt32(1),
                        LaiSuat = (float)reader.GetDouble(2),
                        SoNgayToiThieuDuocRutTien = reader.GetInt32(3),
                        QuiDinhSoTienRut = reader.GetString(4)
                    };
                }
                return null;
            }
        }

        public int GetSoTaiKhoanThanhToanByMaKhachHang(int maKhachHang)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT SoTaiKhoanThanhToan FROM KhachHang WHERE MaKhachHang = @MaKhachHang";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaKhachHang", maKhachHang);

                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
                throw new Exception("Không tìm thấy khách hàng với mã khách hàng đã cung cấp.");
            }
        }
    }
    public class LoaiTietKiemDAO
    {
        private string connectionString = @"Data Source=CL-5CD6492KYP;Initial Catalog=saving_books_managements;Integrated Security=True";

        public LoaiTietKiemDTO GetLoaiTietKiemByMa(int maLoaiTietKiem)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM LoaiTietKiem WHERE MaLoaiTietKiem = @MaLoaiTietKiem";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaLoaiTietKiem", maLoaiTietKiem);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new LoaiTietKiemDTO
                    {
                        MaLoaiTietKiem = reader.GetInt32(0),
                        KyHan = reader.GetInt32(1),
                        LaiSuat = (float)reader.GetDouble(2),
                        SoNgayToiThieuDuocRutTien = reader.GetInt32(3),
                        QuiDinhSoTienRut = reader.GetString(4)
                    };
                }
                return null;
            }
        }
>>>>>>> b9113d9 (Initial commit)
    }
}
