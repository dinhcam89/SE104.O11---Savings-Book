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
        private string connectionString = @"Server=MSI\SQLEXPRESS;Database=stk_db;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True";

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
        public int GetTotalSavingsAccountsByTerm(int maLoaiTietKiem)
        {
            int total = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM PhieuGoiTien WHERE TongTienGoc > 0 AND MaLoaiTietKiem = @MaLoaiTietKiem";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaLoaiTietKiem", maLoaiTietKiem); // Truyền giá trị mã loại tiết kiệm vào tham số

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

                object result = cmd.ExecuteScalar();
                if (result != DBNull.Value) // Kiểm tra kết quả không null
                {
                    total = Convert.ToDecimal(result);
                }
            }
            return total;
        }

        // Hàm lấy dữ liệu tổng quan theo tháng (Ví dụ: Tổng tiền gửi theo từng tháng)
        public Dictionary<string, Dictionary<int, decimal>> GetSavingsByMonthAndTerm(string kyHan) {
            var data = new Dictionary<string, Dictionary<int, decimal>>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = kyHan == "-1" // Kiểm tra nếu chọn "Tất cả kỳ hạn"
                    ? @"
                SELECT 
                    FORMAT(pg.NgayGoi, 'yyyy-MM') AS Thang,
                    lk.KyHan AS KyHan,
                    SUM(pg.TongTienGoc) AS TongTienGui
                FROM 
                    PhieuGoiTien pg
                JOIN 
                    LoaiTietKiem lk ON pg.MaLoaiTietKiem = lk.MaLoaiTietKiem
                GROUP BY 
                    FORMAT(pg.NgayGoi, 'yyyy-MM'),
                    lk.KyHan
                ORDER BY 
                    Thang, KyHan"
                    : @"
                SELECT 
                    FORMAT(pg.NgayGoi, 'yyyy-MM') AS Thang,
                    lk.KyHan AS KyHan,
                    SUM(pg.TongTienGoc) AS TongTienGui
                FROM 
                    PhieuGoiTien pg
                JOIN 
                    LoaiTietKiem lk ON pg.MaLoaiTietKiem = lk.MaLoaiTietKiem
                WHERE 
                    lk.KyHan = @KyHan
                GROUP BY 
                    FORMAT(pg.NgayGoi, 'yyyy-MM'),
                    lk.KyHan
                ORDER BY 
                    Thang, KyHan";

                SqlCommand cmd = new SqlCommand(query, conn);

                // Nếu không phải là "Tất cả kỳ hạn", thêm tham số kỳ hạn
                if (kyHan != "-1")
                {
                    cmd.Parameters.AddWithValue("@KyHan", int.Parse(kyHan)); // Chuyển đổi kỳ hạn thành số nguyên
                }

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string month = reader["Thang"].ToString();
                        int kyHanValue = Convert.ToInt32(reader["KyHan"]); // Giá trị kỳ hạn là số nguyên
                        decimal totalAmount = Convert.ToDecimal(reader["TongTienGui"]);

                        if (!data.ContainsKey(month))
                        {
                            data[month] = new Dictionary<int, decimal>();
                        }

                        data[month][kyHanValue] = totalAmount;
                    }
                }
            }

            return data;
        }

        public Dictionary<int, Dictionary<DateTime, decimal>> GetSavingsByDateAndTerm(DateTime selectedDate)
        {
            var result = new Dictionary<int, Dictionary<DateTime, decimal>>();

            // Kết nối với cơ sở dữ liệu
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Truy vấn để lấy số tiền gửi theo kỳ hạn và ngày được chọn
                string query = @"
            SELECT 
                l.KyHan, 
                p.NgayGoi, 
                SUM(p.TongTienGoc + p.TongTienLaiPhatSinh) AS TotalAmount
            FROM 
                PhieuGoiTien p
            INNER JOIN 
                LoaiTietKiem l ON p.MaLoaiTietKiem = l.MaLoaiTietKiem
            WHERE 
                p.NgayGoi = @SelectedDate
            GROUP BY 
                l.KyHan, p.NgayGoi
            ORDER BY 
                l.KyHan";

                using (var command = new SqlCommand(query, connection))
                {
                    // Thêm tham số cho ngày người dùng chọn
                    command.Parameters.AddWithValue("@SelectedDate", selectedDate.ToString("yyyy-MM-dd"));

                    using (var reader = command.ExecuteReader())
                    {
                        // Duyệt qua kết quả và nhóm theo kỳ hạn
                        while (reader.Read())
                        {
                            int term = reader.GetInt32(0);
                            DateTime transactionDate = reader.GetDateTime(1);
                            double totalAmountDouble = reader.GetDouble(2);
                            decimal totalAmount = Convert.ToDecimal(totalAmountDouble);

                            // Nếu chưa có danh sách cho kỳ hạn này, tạo mới
                            if (!result.ContainsKey(term))
                            {
                                result[term] = new Dictionary<DateTime, decimal>();
                            }

                            // Thêm dữ liệu vào dictionary
                            result[term][transactionDate] = totalAmount;
                        }
                    }
                }
            }

            return result;
        }



    }
}
