using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAO
{
    public class BieuDoDAO
    {
        private string connectionString = "MSI\\SQLEXPRESS;Initial Catalog=stk_db;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        // Hàm lấy tổng số khách hàng
        public int GetTotalCustomers()
        {
            int total = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM KhachHang";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                total = (int)cmd.ExecuteScalar();
            }
            return total;
        }

        // Hàm lấy tổng số phiếu gửi tiền có số tiền lớn hơn 0
        public int GetTotalSavingsAccounts()
        {
            int total = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM PhieuGoiTien WHERE TongTienGoc > 0";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                total = (int)cmd.ExecuteScalar();
            }
            return total;
        }

        // Hàm lấy tổng số tiền gửi
        public decimal GetTotalSavingsAmount()
        {
            decimal total = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT SUM(TongTienGoc) FROM PhieuGoiTien";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                total = (decimal)cmd.ExecuteScalar();
            }
            return total;
        }

        // Hàm lấy dữ liệu tổng quan theo tháng (Ví dụ: Tổng tiền gửi theo từng tháng)
        public Dictionary<string, decimal> GetSavingsByMonth()
        {
            Dictionary<string, decimal> data = new Dictionary<string, decimal>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                SELECT FORMAT(NgayGui, 'yyyy-MM') AS Thang, SUM(TongTienGoc) AS TongTien
                FROM PhieuGoiTien
                GROUP BY FORMAT(NgayGui, 'yyyy-MM')
                ORDER BY Thang";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string month = reader["Thang"].ToString();
                        decimal total = Convert.ToDecimal(reader["TongTien"]);
                        data.Add(month, total);
                    }
                }
            }

            return data;
        }
    }
}
