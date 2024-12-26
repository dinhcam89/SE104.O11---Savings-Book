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
        public ChiTietGuiTien? GetByMaPhieu(string maPhieu)
        {
            ChiTietGuiTien chiTiet = new();
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
                            SoTaiKhoanTienGoi = reader["SoTaiKhoanTienGoi"].ToString()!,
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
    }
}
