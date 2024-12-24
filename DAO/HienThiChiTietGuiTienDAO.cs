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
    }
}
