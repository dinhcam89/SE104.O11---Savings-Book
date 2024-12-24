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
        private string connectionString = @"Server=MSI\SQLEXPRESS;Database=saving_books_management;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True";

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
        public int GetTotalSavingsAccountsByTerm(string maLoaiTietKiem)
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

        public decimal GetTotalSavingsAmountByTerm(string maLoaiTietKiem)
        {
            decimal totalAmount = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT SUM(TongTienGoc) FROM PhieuGoiTien WHERE MaLoaiTietKiem = @MaLoaiTietKiem";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaLoaiTietKiem", maLoaiTietKiem); // Truyền giá trị mã loại tiết kiệm vào tham số

                conn.Open();
                var result = cmd.ExecuteScalar();

                // Kiểm tra nếu kết quả trả về là null (không có dữ liệu)
                totalAmount = result == DBNull.Value ? 0 : Convert.ToDecimal(result);
            }
            return totalAmount;
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
        public Dictionary<string, Dictionary<int, decimal>> GetSavingsByMonthAndTerm(string kyHan)
        {
            var data = new Dictionary<string, Dictionary<int, decimal>>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = kyHan == "-1" // "-1" đại diện cho tất cả kỳ hạn
                    ? @"SELECT 
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
                    : @"SELECT 
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

                if (kyHan != "-1")
                {
                    cmd.Parameters.AddWithValue("@KyHan", int.Parse(kyHan));
                }

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string month = reader["Thang"].ToString();
                        int kyHanValue = Convert.ToInt32(reader["KyHan"]);
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

        // Hàm lấy dữ liệu theo tháng/năm và kỳ hạn
        public Dictionary<int, Dictionary<DateTime, decimal>> GetSavingsByDateAndTerm(DateTime selectedDate)
        {
            var result = new Dictionary<int, Dictionary<DateTime, decimal>>();

            // Kết nối với cơ sở dữ liệu
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Truy vấn để lấy số tiền gửi theo kỳ hạn và tháng/năm được chọn
                string query = @"
                    SELECT 
                        l.KyHan, 
                        MONTH(p.NgayGoi) AS Month,  
                        YEAR(p.NgayGoi) AS Year,
                        SUM(p.TongTienGoc + p.TongTienLaiPhatSinh) AS TotalAmount
                    FROM 
                        PhieuGoiTien p
                    INNER JOIN 
                        LoaiTietKiem l ON p.MaLoaiTietKiem = l.MaLoaiTietKiem
                    WHERE 
                        MONTH(p.NgayGoi) = @Month AND YEAR(p.NgayGoi) = @Year
                    GROUP BY 
                        l.KyHan, MONTH(p.NgayGoi), YEAR(p.NgayGoi)
                    ORDER BY 
                        l.KyHan";

                using (var command = new SqlCommand(query, connection))
                {
                    // Thêm tham số cho tháng và năm người dùng chọn
                    command.Parameters.AddWithValue("@Month", selectedDate.Month);
                    command.Parameters.AddWithValue("@Year", selectedDate.Year);

                    using (var reader = command.ExecuteReader())
                    {
                        // Duyệt qua kết quả và nhóm theo kỳ hạn
                        while (reader.Read())
                        {
                            int term = reader.GetInt32(0);
                            int month = reader.GetInt32(1);  // Lấy tháng
                            int year = reader.GetInt32(2);   // Lấy năm
                            double totalAmountDouble = reader.GetDouble(3);
                            decimal totalAmount = Convert.ToDecimal(totalAmountDouble);

                            // Tạo ngày cho dữ liệu tháng/năm
                            DateTime transactionDate = new DateTime(year, month, 1);  // Tạo ngày đầu tháng

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


        public float LayTongSoTienDaChi()
        {
            string query = @"
        SELECT 
            SUM(CTR.SoTienRut) AS TongSoTienRut
        FROM 
            ChiTietRutTien CTR";

            float tongSoTienRut = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                object result = command.ExecuteScalar(); // Lấy giá trị đầu tiên của kết quả
                if (result != DBNull.Value)
                {
                    tongSoTienRut = float.Parse(result.ToString());
                }
            }

            return tongSoTienRut;
        }

        // Cập nhật hàm GetWithdrawalsByTerm để kết hợp bảng LoaiTietKiem và lấy thông tin kỳ hạn
        public Dictionary<int, decimal> GetWithdrawalsByTerm()
        {
            var withdrawalsByTerm = new Dictionary<int, decimal>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Truy vấn dữ liệu kết hợp giữa ChiTietRutTien, PhieuGoiTien và LoaiTietKiem để lấy kỳ hạn
                string query = @"
            SELECT LTK.KyHan, SUM(CT.SoTienRut) AS TotalAmount
            FROM ChiTietRutTien CT
            JOIN PhieuGoiTien PG ON CT.SoTaiKhoanTienGoi = PG.SoTaiKhoanTienGoi
            JOIN LoaiTietKiem LTK ON PG.MaLoaiTietKiem = LTK.MaLoaiTietKiem
            GROUP BY LTK.KyHan";

                using (var command = new SqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Lấy kỳ hạn (KyHan) và tổng số tiền rút
                        int term = reader.GetInt32(0);  // KyHan là kiểu dữ liệu INT
                        decimal totalAmount = Convert.ToDecimal(reader.GetDouble(1));

                        // Cộng dồn tổng số tiền rút theo kỳ hạn
                        if (!withdrawalsByTerm.ContainsKey(term))
                        {
                            withdrawalsByTerm[term] = 0;
                        }

                        withdrawalsByTerm[term] += totalAmount;
                    }
                }
            }

            return withdrawalsByTerm;
        }


        public Dictionary<string, float> LayTongSoTienRutTheoKyHan(DateTime thangDuocChon)
        {
            string query = @"
        SELECT 
            PG.MaLoaiTietKiem, 
            SUM(CTR.SoTienRut) AS TongSoTienRut
        FROM 
            ChiTietRutTien CTR
        JOIN 
            PhieuGoiTien PG ON CTR.SoTaiKhoanTienGoi = PG.SoTaiKhoanTienGoi
        WHERE 
            MONTH(CTR.NgayRut) = @Thang AND YEAR(CTR.NgayRut) = @Nam
        GROUP BY 
            PG.MaLoaiTietKiem";

            Dictionary<string, float> tongTienTheoKyHan = new Dictionary<string, float>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Thang", thangDuocChon.Month);
                command.Parameters.AddWithValue("@Nam", thangDuocChon.Year);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string MaLoaiTietKiem = reader["MaLoaiTietKiem"].ToString();
                        float tongTien = float.Parse(reader["TongSoTienRut"].ToString());
                        tongTienTheoKyHan[MaLoaiTietKiem] = tongTien;
                    }
                }
            }

            return tongTienTheoKyHan;
        }


    }
}
