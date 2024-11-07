using System;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class SavingBookDAO
    {
        private string connectionString = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=saving_books_management;Integrated Security=True;TrustServerCertificate=True";

        public int InsertSavingBook(SavingBookDTO savingBook)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO SoTietKiem (MSKhachHang, MSLoaiTietKiem, DiaChi, SoTienGoi, NgayMoSo, NgayDongSo) " +
                               "VALUES (@MSKhachHang, @MSLoaiTietKiem, @DiaChi, @SoTienGoi, @NgayMoSo, @NgayDongSo)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MSKhachHang", savingBook.MSKhachHang);
                    command.Parameters.AddWithValue("@MSLoaiTietKiem", savingBook.MSLoaiTietKiem);
                    command.Parameters.AddWithValue("@DiaChi", savingBook.DiaChi);
                    command.Parameters.AddWithValue("@SoTienGoi", savingBook.SoTienGoi);
                    command.Parameters.AddWithValue("@NgayMoSo", savingBook.NgayMoSo);
                    command.Parameters.AddWithValue("@NgayDongSo", savingBook.NgayDongSo);

                    return command.ExecuteNonQuery(); // Sẽ trả về số hàng bị ảnh hưởng
                }
            }
        }
    }
}
