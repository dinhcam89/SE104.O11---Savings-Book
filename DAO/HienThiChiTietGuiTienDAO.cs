using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using DTO;

namespace DAO
{
    public class HienThiChiTietGuiTienDAO
    {
        private string connectionString = "Data Source=CONALNGUYEN\\NGUYENCHAU;Initial Catalog=saving_books_management;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        public List<DTO.ChiTietGuiTien> GetAll()
        {
            List<DTO.ChiTietGuiTien> list = new List<DTO.ChiTietGuiTien>();

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
                            MaChiTietGuiTien = reader["MaChiTietGoiTien"].ToString(),
                            SoTaiKhoanTienGui = reader["SoTaiKhoanTienGoi"].ToString(),
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
        public ChiTietGuiTien GetByMaPhieu(string maPhieu)
        {
            ChiTietGuiTien chiTiet = null;
            string query = "SELECT MaChiTietGoiTien, SoTaiKhoanTienGoi, NgayGoi, SoTienGoi FROM ChiTietGoiTien WHERE SoTaiKhoanTienGoi = @MaPhieu";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaPhieu", maPhieu);  // Thêm tham số mã phiếu

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        chiTiet = new ChiTietGuiTien
                        {
                            //MaChiTietGuiTien = reader["MaChiTietGoiTien"].ToString(),
                            SoTaiKhoanTienGui = reader["SoTaiKhoanTienGoi"].ToString(),
                            NgayGui = Convert.ToDateTime(reader["NgayGoi"]),
                            SoTienGui = Convert.ToDouble(reader["SoTienGoi"])
                        };
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi truy vấn dữ liệu: " + ex.Message);
                }
            }

            return chiTiet;

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
                            SoTaiKhoanTienGui = reader["SoTaiKhoanTienGoi"].ToString(),
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
                            SoTaiKhoanTienGui = reader["SoTaiKhoanTienGoi"].ToString(),
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
    }
}
