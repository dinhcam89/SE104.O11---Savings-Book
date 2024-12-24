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
        private string connectionString = "Data Source=CONALNGUYEN\\NGUYENCHAU;Initial Catalog=saving_books_management;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

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
    }
}
