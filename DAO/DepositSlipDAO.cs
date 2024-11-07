using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class DepositSlipDAO
    {
        private string connectionString = "Data Source=CONALNGUYEN\\NGUYENCHAU;Initial Catalog=saving_books_management;Integrated Security=True";

        public bool AddDepositReceipt(DepositSlipDTO receipt)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO PhieuGoiTien (MSSoTietKiem, NgayGoi, SoTienGoi) " +
                               "VALUES (@MSSoTietKiem, @NgayGoi, @SoTienGoi)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MSSoTietKiem", receipt.SavingBookId);
                //command.Parameters.AddWithValue("@CustomerName", receipt.CustomerName);
                command.Parameters.AddWithValue("@NgayGoi", receipt.DepositDate);
                command.Parameters.AddWithValue("@SoTienGoi", receipt.DepositAmount);

                connection.Open();
                int result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        public string GetNextReceiptID()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT MAX(MaSo) FROM PhieuGoiTien";
                SqlCommand command = new SqlCommand(query, connection);
                object result = command.ExecuteScalar();

                if (result != DBNull.Value && int.TryParse(result.ToString(), out int maxID))
                {
                    // Tăng mã số hiện tại lên 1 và trả về chuỗi với định dạng số 3 chữ số
                    return (maxID + 1).ToString("D3");
                }
                else
                {
                    // Nếu không có mã nào, bắt đầu từ "001"
                    return "001";
                }
            }
        }

    }
}
