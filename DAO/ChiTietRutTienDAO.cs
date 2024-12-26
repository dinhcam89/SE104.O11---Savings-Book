using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAO
{
    public class ChiTietRutTienDAO
    {
        private string connectionString = @"Server=MSI\SQLEXPRESS;Database=saving_books_management;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True";

        public PhieuGoiTien GetPhieuGoiTienById(string soTaiKhoanTienGoi)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM PhieuGoiTien WHERE SoTaiKhoanTienGoi = @SoTaiKhoanTienGoi";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SoTaiKhoanTienGoi", soTaiKhoanTienGoi);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new PhieuGoiTien
                    {
                        SoTaiKhoanTienGoi = reader.GetString(reader.GetOrdinal("SoTaiKhoanTienGoi")),
                        SoTaiKhoanThanhToan = reader.GetString(reader.GetOrdinal("SoTaiKhoanThanhToan")),
                        MaLoaiTietKiem = reader.GetString(reader.GetOrdinal("MaLoaiTietKiem")),
                        LaiSuatApDung = (float)reader.GetDouble(reader.GetOrdinal("LaiSuatApDung")),
                        LaiSuatPhatSinh = (float)reader.GetDouble(reader.GetOrdinal("LaiSuatPhatSinh")),
                        NgayDaoHanKeTiep = reader.GetDateTime(reader.GetOrdinal("NgayDaoHanKeTiep")),
                        NgayGoi = reader.GetDateTime(reader.GetOrdinal("NgayGoi")),
                        TongTienGoc = (float)reader.GetDouble(reader.GetOrdinal("TongTienGoc")),
                        TongTienLaiPhatSinh = (float)reader.GetDouble(reader.GetOrdinal("TongTienLaiPhatSinh"))
                    };
                }
            }
            return null;
        }

        public LoaiTietKiem GetLoaiTietKiemById(string maLoaiTietKiem)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM LoaiTietKiem WHERE MaLoaiTietKiem = @MaLoaiTietKiem";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaLoaiTietKiem", maLoaiTietKiem);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new LoaiTietKiem
                    {
                        MaLoaiTietKiem = reader.GetString(reader.GetOrdinal("MaLoaiTietKiem")),
                        KyHan = reader.GetInt32(reader.GetOrdinal("KyHan")),

                        LaiSuat = (double)reader["LaiSuat"],
                        SoNgayToiThieuDuocRutTien = reader.GetInt32(reader.GetOrdinal("SoNgayToiThieuDuocRutTien")),
                        QuyDinhSoTienRut = reader.GetString(reader.GetOrdinal("QuyDinhSoTienRut")) // Lấy thêm cột QuyDinhSoTienRut
                    };
                }
            }
            return null;
        }


        public bool UpdatePhieuGoiTienAfterRut(string soTaiKhoanTienGoi, double soTienRut)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE PhieuGoiTien 
                     SET TongTienGoc = TongTienGoc - @SoTienRut 
                     WHERE SoTaiKhoanTienGoi = @SoTaiKhoanTienGoi";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SoTienRut", soTienRut);
                cmd.Parameters.AddWithValue("@SoTaiKhoanTienGoi", soTaiKhoanTienGoi);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdatePhieuGoiTienToZero(string soTaiKhoanTienGoi)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE PhieuGoiTien
                         SET TongTienGoc = 0, TongTienLaiPhatSinh = 0
                         WHERE SoTaiKhoanTienGoi = @SoTaiKhoanTienGoi";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SoTaiKhoanTienGoi", soTaiKhoanTienGoi);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool InsertChiTietRutTien(ChiTietRutTien chiTietRutTien)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Lấy mã lớn nhất hiện tại
                string getMaxIdQuery = @"
                SELECT ISNULL(MAX(CAST(SUBSTRING(MaChiTietRutTien, 4, LEN(MaChiTietRutTien)) AS INT)), 0) + 1 
                FROM ChiTietRutTien";
                SqlCommand getMaxIdCmd = new SqlCommand(getMaxIdQuery, conn);
                int newIdNumber = Convert.ToInt32(getMaxIdCmd.ExecuteScalar());

                // Tạo mã mới với tiền tố "CRT"
                string newMaChiTietRutTien = $"CRT{newIdNumber:D7}";

                // Chèn dữ liệu mới
                string insertQuery = @"
                INSERT INTO ChiTietRutTien (MaChiTietRutTien, SoTaiKhoanTienGoi, NgayRut, SoTienRut) 
                VALUES (@MaChiTietRutTien, @SoTaiKhoanTienGoi, @NgayRut, @SoTienRut)";
                SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                insertCmd.Parameters.AddWithValue("@MaChiTietRutTien", newMaChiTietRutTien);
                insertCmd.Parameters.AddWithValue("@SoTaiKhoanTienGoi", chiTietRutTien.SoTaiKhoanTienGoi);
                insertCmd.Parameters.AddWithValue("@NgayRut", chiTietRutTien.NgayRut);
                insertCmd.Parameters.AddWithValue("@SoTienRut", chiTietRutTien.SoTienRut);

                return insertCmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateKhachHangSoDu(string soTaiKhoanThanhToan, double soTienRut)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE KhachHang 
                         SET SoDuHienCo = SoDuHienCo + @SoTienRut 
                         WHERE SoTaiKhoanThanhToan = @SoTaiKhoanThanhToan";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SoTienRut", soTienRut);
                cmd.Parameters.AddWithValue("@SoTaiKhoanThanhToan", soTaiKhoanThanhToan);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

    }
}
