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
    public class AddDepositSlipDAO
    {
        private string connectionString = "sqlserver_connection_string_here";  // Kết nối đến cơ sở dữ liệu

        // Phương thức để thêm phiếu gửi tiền
        public bool AddDeposit(DepositSlipDTO depositslip)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Bắt đầu transaction để đảm bảo cả hai hoạt động đều thành công hoặc bị rollback
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Thêm phiếu rút tiền vào bảng depositslips
                    string querydepositslip = "INSERT INTO depositslips (depositslipId, SavingsBookId, Amount, depositslipDate) " +
                                             "VALUES (@depositslipId, @SavingsBookId, @Amount, @depositslipDate)";

                    SqlCommand cmddepositslip = new SqlCommand(querydepositslip, conn, transaction);
                    cmddepositslip.Parameters.AddWithValue("@depositslipId", depositslip.DepositSlipId);
                    cmddepositslip.Parameters.AddWithValue("@SavingsBookId", depositslip.SavingBookId);
                    cmddepositslip.Parameters.AddWithValue("@Amount", depositslip.DepositAmount);
                    cmddepositslip.Parameters.AddWithValue("@depositslipDate", depositslip.DepositDate);

                    cmddepositslip.ExecuteNonQuery();

                    // Cập nhật LastdepositslipId trong bảng SavingsBook
                    string queryUpdateBook = "UPDATE SavingsBook SET LastdepositslipId = @depositslipId " +
                                             "WHERE SavingsBookId = @SavingsBookId";

                    SqlCommand cmdUpdateBook = new SqlCommand(queryUpdateBook, conn, transaction);
                    cmdUpdateBook.Parameters.AddWithValue("@depositslipId", depositslip.DepositSlipId);
                    cmdUpdateBook.Parameters.AddWithValue("@SavingsBookId", depositslip.SavingBookId);

                    cmdUpdateBook.ExecuteNonQuery();

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
