using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using DTO;
using System.Configuration;

namespace DAO
{
    public class HienThiChiTietGuiTienDAO
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString;
        public List<ChiTietGuiTien> GetAll()
        {
            List<ChiTietGuiTien> list = new List<ChiTietGuiTien>();

            string query = "SELECT MaChiTietGoiTien, SoTaiKhoanTienGoi, NgayGoi, SoTienGoi FROM ChiTietGoiTien";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var chiTiet = new DTO.ChiTietGuiTien
                        { 
                            MaChiTietGuiTien = reader["MaChiTietGoiTien"].ToString()!,
                            SoTaiKhoanTienGoi = reader["SoTaiKhoanTienGoi"].ToString()!,
                            NgayGui = Convert.ToDateTime(reader["NgayGoi"]),
                            SoTienGui = Convert.ToDouble(reader["SoTienGoi"])
                        };

                        list.Add(chiTiet);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi truy vấn dữ liệu: " + ex.Message);
                }
            }

            return list;
        }

        // Phương thức kiểm tra thông tin gửi tiền theo mã phiếu
        public List<ChiTietGuiTien> GetByMaPhieu(string maPhieu)
        {
            List<ChiTietGuiTien> listChiTiet = new List<ChiTietGuiTien>();

            string query = "SELECT MaChiTietGoiTien, SoTaiKhoanTienGoi, NgayGoi, SoTienGoi FROM ChiTietGoiTien WHERE SoTaiKhoanTienGoi = @MaPhieu";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaPhieu", maPhieu);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var chiTiet = new ChiTietGuiTien
                        {
                            MaChiTietGuiTien = reader["MaChiTietGoiTien"].ToString(),
                            SoTaiKhoanTienGoi = reader["SoTaiKhoanTienGoi"].ToString(),
                            NgayGui = Convert.ToDateTime(reader["NgayGoi"]),
                            SoTienGui = Convert.ToDouble(reader["SoTienGoi"])
                        };

                        listChiTiet.Add(chiTiet);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi truy vấn dữ liệu: " + ex.Message);
                }
            }

            return listChiTiet;
        }


        public List<DTO.ChiTietGuiTien> GetTenKhachHang()
        {
            List<DTO.ChiTietGuiTien> list = new List<DTO.ChiTietGuiTien>();

            string query = @"
        SELECT 
            CTG.MaChiTietGoiTien, 
            CTG.SoTaiKhoanTienGoi, 
            KH.TenKhachHang, 
            CTG.NgayGoi, 
            CTG.SoTienGoi
        FROM ChiTietGoiTien CTG
        JOIN PhieuGoiTien PG ON CTG.SoTaiKhoanTienGoi = PG.SoTaiKhoanTienGoi
        JOIN KhachHang KH ON PG.SoTaiKhoanThanhToan = KH.SoTaiKhoanThanhToan";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var chiTiet = new DTO.ChiTietGuiTien
                        {
                            MaChiTietGuiTien = reader["MaChiTietGoiTien"].ToString(),
                            SoTaiKhoanTienGoi = reader["SoTaiKhoanTienGoi"].ToString(),
                            TenKhachHang = reader["TenKhachHang"].ToString(),
                            NgayGui = Convert.ToDateTime(reader["NgayGoi"]),
                            SoTienGui = (float)Convert.ToDouble(reader["SoTienGoi"])
                        };

                        list.Add(chiTiet);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi truy vấn dữ liệu: " + ex.Message);
                }
            }

            return list;
        }

        public List<DTO.ChiTietGuiTien> GetNgay(DateTime startDate, DateTime endDate)
        {
            List<DTO.ChiTietGuiTien> list = new List<DTO.ChiTietGuiTien>();

            string query = @"
        SELECT MaChiTietGoiTien, SoTaiKhoanTienGoi, NgayGoi, SoTienGoi
        FROM ChiTietGoiTien
        WHERE NgayGoi >= @StartDate AND NgayGoi <= @EndDate";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var chiTiet = new DTO.ChiTietGuiTien
                        {
                            MaChiTietGuiTien = reader["MaChiTietGoiTien"].ToString(),
                            SoTaiKhoanTienGoi = reader["SoTaiKhoanTienGoi"].ToString(),
                            NgayGui = Convert.ToDateTime(reader["NgayGoi"]),
                            SoTienGui = Convert.ToDouble(reader["SoTienGoi"])
                        };

                        list.Add(chiTiet);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi truy vấn dữ liệu: " + ex.Message);
                }
            }

            return list;
        }

        public List<DTO.PhieuGoiTien> GetTongTienGoc(string maPhieu)
        {
            List<DTO.PhieuGoiTien> listChiTiet = new List<DTO.PhieuGoiTien>();
            string query = "SELECT SoTaiKhoanTienGoi, TongTienGoc FROM PhieuGoiTien WHERE SoTaiKhoanTienGoi = @MaPhieu";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaPhieu", maPhieu);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var chiTiet = new DTO.PhieuGoiTien
                        {
                            SoTaiKhoanTienGoi = reader["SoTaiKhoanTienGoi"].ToString(),
                            TongTienGoc = Convert.ToSingle(reader["TongTienGoc"]),
                        };

                        listChiTiet.Add(chiTiet);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi truy vấn dữ liệu: " + ex.Message);
                }
            }

            return listChiTiet;
        }
        public List<ChiTietGuiTien> SearchChiTietGuiTien(string searchText)
        {
            var danhSach = new List<ChiTietGuiTien>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
        SELECT 
            CGT.MaChiTietGoiTien, 
            CGT.SoTaiKhoanTienGoi, 
            CGT.NgayGoi, 
            CGT.SoTienGoi
        FROM 
            ChiTietGoiTien CGT
        WHERE 
            CGT.MaChiTietGoiTien LIKE @SearchText OR 
            CGT.SoTaiKhoanTienGoi LIKE @SearchText";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    danhSach.Add(new ChiTietGuiTien
                    {
                        MaChiTietGuiTien = reader.GetString(0),
                        SoTaiKhoanTienGoi = reader.GetString(1),
                        NgayGui = reader.GetDateTime(2),
                        SoTienGui = (float)reader.GetDouble(3)
                    });
                }
            }

            return danhSach;

        }
    }
}
