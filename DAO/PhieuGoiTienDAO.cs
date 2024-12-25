using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;
using System.Drawing.Text;
namespace DAO
{
    public class PhieuGoiTienDAO
    {
        private string connectionString = @"Data Source=CL-5CD6492KYP;Initial Catalog=saving_books_management;Integrated Security=True";
        public string? LaySoTaiKhoanThanhToan(string soTaiKhoanTienGoi)
        {
            string? soTaiKhoanThanhToan = null;

            string query = @"SELECT SoTaiKhoanThanhToan 
                     FROM PhieuGoiTien
                     WHERE SoTaiKhoanTienGoi = @SoTaiKhoanTienGoi";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@SoTaiKhoanTienGoi", soTaiKhoanTienGoi);

                try
                {
                    connection.Open();
                    var result = cmd.ExecuteScalar(); // Trả về giá trị đầu tiên của kết quả truy vấn

                    if (result != null)
                    {
                        soTaiKhoanThanhToan = result.ToString();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Lỗi khi lấy số tài khoản thanh toán: {ex.Message}");
                }
            }

            return soTaiKhoanThanhToan;
        }

        public List<PhieuGoiTien> GetAllPhieuGoiTienWithKhachHang()
        {
            List<PhieuGoiTien> result = new List<PhieuGoiTien>();

            string query = @"
            SELECT 
                pg.SoTaiKhoanTienGoi,
                pg.SoTaiKhoanThanhToan,
                pg.MaLoaiTietKiem,
                pg.LaiSuatApDung,
                pg.LaiSuatPhatSinh,
                pg.NgayGoi,
                pg.NgayDaoHanKeTiep,
                pg.TongTienGoc,
                pg.TongTienLaiPhatSinh,
                pg.HinhThucGiaHan,
                kh.TenKhachHang
            FROM    
                PhieuGoiTien pg
            JOIN 
                KhachHang kh ON pg.SoTaiKhoanThanhToan = kh.SoTaiKhoanThanhToan";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var phieuGoiTien = new PhieuGoiTien
                    {
                        SoTaiKhoanTienGoi = reader["SoTaiKhoanTienGoi"].ToString(),
                        SoTaiKhoanThanhToan = reader["SoTaiKhoanThanhToan"].ToString(),
                        TenKhachHang = reader["TenKhachHang"].ToString(), // Gán tên khách hàng
                        MaLoaiTietKiem = reader["MaLoaiTietKiem"].ToString(),
                        LaiSuatApDung = Convert.ToSingle(reader["LaiSuatApDung"]),
                        LaiSuatPhatSinh = Convert.ToSingle(reader["LaiSuatPhatSinh"]),
                        NgayGoi = Convert.ToDateTime(reader["NgayGoi"]),
                        NgayDaoHanKeTiep = Convert.ToDateTime(reader["NgayDaoHanKeTiep"]),
                        TongTienGoc = Convert.ToSingle(reader["TongTienGoc"]),
                        TongTienLaiPhatSinh = Convert.ToSingle(reader["TongTienLaiPhatSinh"]),
                        HinhThucGiaHan = Convert.ToInt32(reader["HinhThucGiaHan"])
                    };

                    result.Add(phieuGoiTien);
                }
            }

            return result;
        }
        public bool XoaPhieuGoiTien(string soTaiKhoanTienGoi)
        {
            try
            {
                string query = "DELETE FROM PhieuGoiTien WHERE SoTaiKhoanTienGoi = @SoTaiKhoanTienGoi";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@SoTaiKhoanTienGoi", soTaiKhoanTienGoi);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa phiếu gửi tiền: " + ex.Message);
            }
        }

        public PhieuGoiTien LayPhieuGoiTienTheoSoTaiKhoan(string soTaiKhoanTienGoi)
        {
            PhieuGoiTien phieu = null;

            // Truy vấn SQL
            string query = @"
                SELECT 
                    SoTaiKhoanTienGoi, 
                    SoTaiKhoanThanhToan, 
                    MaLoaiTietKiem, 
                    LaiSuatApDung, 
                    LaiSuatPhatSinh, 
                    NgayGoi, 
                    NgayDaoHanKeTiep, 
                    TongTienGoc, 
                    TongTienLaiPhatSinh, 
                    HinhThucGiaHan
                FROM 
                    PhieuGoiTien
                WHERE 
                    SoTaiKhoanTienGoi = @SoTaiKhoanTienGoi";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@SoTaiKhoanTienGoi", soTaiKhoanTienGoi);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        phieu = new PhieuGoiTien
                        {
                            SoTaiKhoanTienGoi = reader["SoTaiKhoanTienGoi"].ToString(),
                            SoTaiKhoanThanhToan = reader["SoTaiKhoanThanhToan"].ToString(),
                            MaLoaiTietKiem = reader["MaLoaiTietKiem"].ToString(),
                            LaiSuatApDung = Convert.ToSingle(reader["LaiSuatApDung"]),
                            LaiSuatPhatSinh = Convert.ToSingle(reader["LaiSuatPhatSinh"]),
                            NgayGoi = Convert.ToDateTime(reader["NgayGoi"]),
                            NgayDaoHanKeTiep = reader["NgayDaoHanKeTiep"] != DBNull.Value
                                ? Convert.ToDateTime(reader["NgayDaoHanKeTiep"])
                                : default(DateTime),
                            TongTienGoc = Convert.ToSingle(reader["TongTienGoc"]), // Chuyển đổi sang float
                            TongTienLaiPhatSinh = Convert.ToSingle(reader["TongTienLaiPhatSinh"]),
                            HinhThucGiaHan = Convert.ToInt32(reader["HinhThucGiaHan"])
                        };
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi lấy phiếu gửi tiền: " + ex.Message);
                }
            }

            return phieu;
        }

        public List<PhieuGoiTien> LayDanhSachPhieuGoiTien()
        {
            List<PhieuGoiTien> danhSachPhieu = new List<PhieuGoiTien>();
            string query = "SELECT SoTaiKhoanTienGoi, MaLoaiTietKiem FROM PhieuGoiTien";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        PhieuGoiTien phieu = new PhieuGoiTien
                        {
                            SoTaiKhoanTienGoi = reader["SoTaiKhoanTienGoi"].ToString(),
                            MaLoaiTietKiem = reader["MaLoaiTietKiem"].ToString()
                        };

                        danhSachPhieu.Add(phieu);
                    }

                    reader.Close();
                }
                catch (SqlException ex)
                {
                    throw new System.Exception("Lỗi khi lấy danh sách phiếu gửi tiền: " + ex.Message);
                }
            }

            return danhSachPhieu;
        }

        public bool ThemPhieuGoiTien(PhieuGoiTien phieu)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                phieu.SoTaiKhoanTienGoi = GenerateUniqueSoTaiKhoan(conn, "GoiTien");

                string query = @"INSERT INTO PhieuGoiTien 
                         (SoTaiKhoanTienGoi, SoTaiKhoanThanhToan, MaLoaiTietKiem, LaiSuatApDung, LaiSuatPhatSinh, NgayGoi, NgayDaoHanKeTiep, TongTienGoc, TongTienLaiPhatSinh, HinhThucGiaHan) 
                         VALUES 
                         (@SoTaiKhoanTienGoi, @SoTaiKhoanThanhToan, @MaLoaiTietKiem, @LaiSuatApDung, @LaiSuatPhatSinh, @NgayGoi, @NgayDaoHanKeTiep, @TongTienGoc, @TongTienLaiPhatSinh, @HinhThucGiaHan)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SoTaiKhoanTienGoi", phieu.SoTaiKhoanTienGoi); // Đảm bảo giá trị không NULL
                cmd.Parameters.AddWithValue("@SoTaiKhoanThanhToan", phieu.SoTaiKhoanThanhToan);
                cmd.Parameters.AddWithValue("@MaLoaiTietKiem", phieu.MaLoaiTietKiem);
                cmd.Parameters.AddWithValue("@LaiSuatApDung", phieu.LaiSuatApDung);
                cmd.Parameters.AddWithValue("@LaiSuatPhatSinh", phieu.LaiSuatPhatSinh);
                cmd.Parameters.AddWithValue("@NgayGoi", phieu.NgayGoi);
                cmd.Parameters.AddWithValue("@NgayDaoHanKeTiep", phieu.NgayDaoHanKeTiep);
                cmd.Parameters.AddWithValue("@TongTienGoc", phieu.TongTienGoc);
                cmd.Parameters.AddWithValue("@TongTienLaiPhatSinh", phieu.TongTienLaiPhatSinh);
                cmd.Parameters.AddWithValue("@HinhThucGiaHan", phieu.HinhThucGiaHan);

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
        private string GenerateUniqueSoTaiKhoan(SqlConnection conn, string loaiTaiKhoan)
        {
            Random rand = new Random();
            string soTaiKhoan;
            string prefix;

            // Xác định tiền tố dựa trên loại tài khoản
            if (loaiTaiKhoan == "ThanhToan")
            {
                prefix = "KH"; // Tiền tố cho tài khoản thanh toán
            }
            else if (loaiTaiKhoan == "GoiTien")
            {
                prefix = "PGT"; // Tiền tố cho tài khoản gửi tiền
            }
            else
            {
                throw new Exception("Loại tài khoản không hợp lệ!");
            }

            while (true)
            {
                if (loaiTaiKhoan == "ThanhToan")
                {
                    soTaiKhoan = prefix + rand.Next(10000000, 99999999).ToString(); // Sinh 8 chữ số
                }
                else
                {
                    soTaiKhoan = prefix + rand.Next(1000000, 9999999).ToString(); // Sinh 7 chữ số
                }

                string query = "SELECT COUNT(*) FROM PhieuGoiTien WHERE SoTaiKhoanTienGoi = @SoTaiKhoan";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SoTaiKhoan", soTaiKhoan);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count == 0) break; // Nếu không trùng lặp, thoát khỏi vòng lặp
            }

            return soTaiKhoan;
        }

        public LoaiTietKiem GetLoaiTietKiemByMa(string maLoaiTietKiem)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM LoaiTietKiem WHERE MaLoaiTietKiem = @MaLoaiTietKiem";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaLoaiTietKiem", maLoaiTietKiem);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new LoaiTietKiem
                    {
                        MaLoaiTietKiem = maLoaiTietKiem,
                        KyHan = reader.GetInt32(1),
                        LaiSuat = (float)reader.GetDouble(2),
                        SoNgayToiThieuDuocRutTien = reader.GetInt32(3),
                        QuyDinhSoTienRut = reader.GetString(4)
                    };
                }
                return null;
            }
        }
    }
}

