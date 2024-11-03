using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    internal class DepositReceiptDAO
    {
        private string connectionString = "Data Source=CONALNGUYEN\\NGUYENCHAU;Initial Catalog=saving_books_management;Integrated Security=True;Trust Server Certificate=True";

        public bool AddDepositReceipt(DepositSlipDTO receipt)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO DepositSlips (SavingBookId, CustomerName, DepositDate, DepositAmount) " +
                               "VALUES (@SavingBookId, @CustomerName, @DepositDate, @DepositAmount)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@SavingBookId", receipt.SavingBookId);
                command.Parameters.AddWithValue("@CustomerName", receipt.CustomerName);
                command.Parameters.AddWithValue("@DepositDate", receipt.DepositDate);
                command.Parameters.AddWithValue("@DepositAmount", receipt.DepositAmount);

                connection.Open();
                int result = command.ExecuteNonQuery();
                return result > 0;
            }
        }
    }
}
