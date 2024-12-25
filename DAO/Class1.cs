
using System;
using System.Data.SqlClient;
using DTO;
namespace DAO
{
    public class KhachHangDAO
    {
        private string connectionString = @"Data Source=CL-5CD6492KYP;Initial Catalog=saving_books_management;Integrated Security=True";
        public Dictionary<string, string> LayDanhSachKhachHang_1()
        {
            Dictionary<string, string> khachHangDict = new Dictionary<string, string>();
            string query = "SELECT SoTaiKhoanThanhToan, TenKhachHang FROM KhachHang";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string soTaiKhoan = reader["SoTaiKhoanThanhToan"].ToString();
                        string tenKhachHang = reader["TenKhachHang"].ToString();

                        if (!khachHangDict.ContainsKey(soTaiKhoan))
                        {
                            khachHangDict.Add(soTaiKhoan, tenKhachHang);
                        }
                    }

                    reader.Close();
                }
                catch (SqlException ex)
                {
                    throw new System.Exception("Lỗi khi lấy danh sách khách hàng: " + ex.Message);
                }
            }

            return khachHangDict;
        }

        public bool ThemKhachHang(KhachHang khachHang)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Tự động sinh số tài khoản thanh toán
                    khachHang.SoTaiKhoanThanhToan = GenerateUniqueSoTaiKhoan(conn);

                    string query = @"INSERT INTO KhachHang 
                                     (SoTaiKhoanThanhToan, TenKhachHang, SoDienThoai, CCCD, DiaChi, NgaySinh, SoDuHienCo) 
                                     VALUES 
                                     (@SoTaiKhoanThanhToan, @TenKhachHang, @SoDienThoai, @CCCD, @DiaChi, @NgaySinh, @SoDuHienCo)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@SoTaiKhoanThanhToan", khachHang.SoTaiKhoanThanhToan);
                    cmd.Parameters.AddWithValue("@TenKhachHang", khachHang.TenKhachHang);
                    cmd.Parameters.AddWithValue("@SoDienThoai", khachHang.SoDienThoai);
                    cmd.Parameters.AddWithValue("@CCCD", khachHang.CCCD);
                    cmd.Parameters.AddWithValue("@DiaChi", khachHang.DiaChi);
                    cmd.Parameters.AddWithValue("@NgaySinh", khachHang.NgaySinh ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SoDuHienCo", khachHang.SoDuHienCo);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm khách hàng: " + ex.Message);
            }
        }

        public List<KhachHang> LayDanhSachKhachHang()
        {
            List<KhachHang> danhSachKhachHang = new List<KhachHang>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT * FROM KhachHang";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        KhachHang khachHang = new KhachHang
                        {
                            SoTaiKhoanThanhToan = reader["SoTaiKhoanThanhToan"].ToString(),
                            TenKhachHang = reader["TenKhachHang"].ToString(),
                            SoDienThoai = reader["SoDienThoai"].ToString(),
                            CCCD = reader["CCCD"].ToString(),
                            DiaChi = reader["DiaChi"].ToString(),
                            NgaySinh = reader["NgaySinh"] != DBNull.Value ? Convert.ToDateTime(reader["NgaySinh"]) : (DateTime?)null,
                            SoDuHienCo = float.Parse(reader["SoDuHienCo"].ToString())
                        };
                        danhSachKhachHang.Add(khachHang);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách khách hàng: " + ex.Message);
            }

            return danhSachKhachHang;
        }

        private string GenerateUniqueSoTaiKhoan(SqlConnection conn)
        {
            Random rand = new Random();
            string soTaiKhoan;

            while (true)
            {
                soTaiKhoan = rand.NextInt64(1000000000, 9999999999).ToString();

                string query = "SELECT COUNT(*) FROM KhachHang WHERE SoTaiKhoanThanhToan = @SoTaiKhoanThanhToan";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SoTaiKhoanThanhToan", soTaiKhoan);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count == 0) break; // Nếu không trùng lặp, thoát khỏi vòng lặp
            }

            return soTaiKhoan;
        }
        public bool XoaKhachHang(string soTaiKhoanThanhToan)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Xóa tất cả phiếu gửi tiền liên quan trước
                    string deletePhieuQuery = "DELETE FROM PhieuGoiTien WHERE SoTaiKhoanThanhToan = @SoTaiKhoanThanhToan";
                    SqlCommand cmdDeletePhieu = new SqlCommand(deletePhieuQuery, conn, transaction);
                    cmdDeletePhieu.Parameters.AddWithValue("@SoTaiKhoanThanhToan", soTaiKhoanThanhToan);
                    cmdDeletePhieu.ExecuteNonQuery();

                    // Xóa khách hàng
                    string deleteKhachHangQuery = "DELETE FROM KhachHang WHERE SoTaiKhoanThanhToan = @SoTaiKhoanThanhToan";
                    SqlCommand cmdDeleteKhachHang = new SqlCommand(deleteKhachHangQuery, conn, transaction);
                    cmdDeleteKhachHang.Parameters.AddWithValue("@SoTaiKhoanThanhToan", soTaiKhoanThanhToan);
                    cmdDeleteKhachHang.ExecuteNonQuery();

                    // Commit transaction
                    transaction.Commit();
                    return true;
                }
                catch
                {
                    // Rollback transaction nếu có lỗi
                    transaction.Rollback();
                    throw;
                }
            }
        }
        public KhachHang? LayKhachHangTheoSoTaiKhoan(string soTaiKhoan)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM KhachHang WHERE SoTaiKhoanThanhToan = @SoTaiKhoanThanhToan";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@SoTaiKhoanThanhToan", soTaiKhoan);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return new KhachHang
                        {
                            TenKhachHang = reader["TenKhachHang"].ToString(),
                            SoTaiKhoanThanhToan = reader["SoTaiKhoanThanhToan"].ToString(),
                            SoDienThoai = reader["SoDienThoai"].ToString(),
                            CCCD = reader["CCCD"].ToString(),
                            NgaySinh = reader["NgaySinh"] != DBNull.Value ? Convert.ToDateTime(reader["NgaySinh"]) : (DateTime?)null,
                            DiaChi = reader["DiaChi"].ToString(),
                            SoDuHienCo = float.Parse(reader["SoDuHienCo"].ToString())
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi truy vấn thông tin khách hàng: " + ex.Message);
            }
            return null;
        }

    }

    public class PhieuGoiTienDAO
    {
        private string connectionString = @"Data Source=CL-5CD6492KYP;Initial Catalog=saving_books_management;Integrated Security=True";
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
                            LaiSuatApDung = Convert.ToDouble(reader["LaiSuatApDung"]),
                            LaiSuatPhatSinh = Convert.ToDouble(reader["LaiSuatPhatSinh"]),
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


        public class LoaiTietKiemDAO
        {
            private string connectionString = @"Data Source=CL-5CD6492KYP;Initial Catalog=saving_books_management;Integrated Security=True";

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
}
