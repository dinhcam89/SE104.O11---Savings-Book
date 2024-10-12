using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class AddWithdrawSlipDAO
    {
        private string connectionString = "sqlserver_connection_string_here";  // Kết nối đến cơ sở dữ liệu
        public bool addWithdrawSlip(WithdrawSlipDTO withdrawSlip)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Bắt đầu transaction để đảm bảo cả hai hoạt động đều thành công hoặc bị rollback
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Thêm phiếu rút tiền
                    string insertWithdrawSlipQuery = @"
                        INSERT INTO WithdrawSlips (SlipId, SavingBookId, CustomerName, WithdrawDate, WithdrawAmount) 
                        VALUES (@SlipId, @SavingBookId, @CustomerName, @WithdrawDate, @WithdrawAmount)";

                    using (SqlCommand cmd = new SqlCommand(insertWithdrawSlipQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@SlipId", withdrawSlip.SlipId);
                        cmd.Parameters.AddWithValue("@SavingBookId", withdrawSlip.SavingBookId);
                        cmd.Parameters.AddWithValue("@CustomerName", withdrawSlip.CustomerName);
                        cmd.Parameters.AddWithValue("@WithdrawDate", withdrawSlip.WithdrawDate);
                        cmd.Parameters.AddWithValue("@WithdrawAmount", withdrawSlip.WithdrawAmount);

                        cmd.ExecuteNonQuery();
                    }

                    // Lệnh SQL để cập nhật số dư của sổ tiết kiệm
                    string updateSavingBookBalanceQuery = @"
                        UPDATE SavingBooks 
                        SET Balance = Balance - @WithdrawAmount 
                        WHERE SavingBookId = @SavingBookId";

                    using (SqlCommand cmd = new SqlCommand(updateSavingBookBalanceQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@WithdrawAmount", withdrawSlip.WithdrawAmount);
                        cmd.Parameters.AddWithValue("@SavingBookId", withdrawSlip.SavingBookId);

                        cmd.ExecuteNonQuery();
                    }
                    // Commit transaction nếu cả hai hoạt động thành công
                    transaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    // Rollback nếu có lỗi xảy ra
                    transaction.Rollback();
                    return false;
                }
            }
        }
    }
}
