using DTO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class HienThiChiTietRutTienDAO
    {
        private string connectionString = @"Server=MSI\SQLEXPRESS;Database=saving_books_management;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True";
        public List<DTO.ChiTietRutTien> GetAll()
        {
            List<DTO.ChiTietRutTien> list = new List<DTO.ChiTietRutTien>();

            string query = "SELECT MaChiTietRutTien, SoTaiKhoanTienGoi, NgayRut, SoTienRut FROM ChiTietRutTien";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var chiTiet = new DTO.ChiTietRutTien
                        {
                            MaChiTietRutTien = reader["MaChiTietRutTien"].ToString(),
                            SoTaiKhoanTienGui = reader["SoTaiKhoanTienGoi"].ToString(),
                            NgayRut = Convert.ToDateTime(reader["NgayRut"]),
                            SoTienRut = Convert.ToDouble(reader["SoTienRut"])
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
        public ChiTietRutTien GetByMaPhieu(string maPhieu)
        {
            ChiTietRutTien chiTiet = null;
            string query = "SELECT MaChiTietRutTien, SoTaiKhoanTienGoi, NgayRut, SoTienRut FROM ChiTietRutTien WHERE MaChiTietRutTien = @MaPhieu";

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
                        chiTiet = new ChiTietRutTien
                        {
                            //MaChiTietRutTien = reader["MaChiTietRutTien"].ToString(),
                            //SoTaiKhoanTienGui = reader["SoTaiKhoanTienGoi"].ToString(),
                            NgayRut = Convert.ToDateTime(reader["NgayRut"]),
                            SoTienRut = Convert.ToDouble(reader["SoTienRut"])
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
