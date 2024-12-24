using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using DTO;


namespace DAO
{
    public class ChiTietRutTienDAO
    {
        private string connectionString = "Data Source=CONALNGUYEN\\NGUYENCHAU;Initial Catalog=saving_books_management;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        public PhieuGuiTien GetPhieuGoiTienById(string soTaiKhoanTienGoi)
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
                    return new PhieuGuiTien
                    {
                        SoTaiKhoanGuiTien = reader.GetString(reader.GetOrdinal("SoTaiKhoanTienGoi")),
                        MaKH = reader.GetInt32(reader.GetOrdinal("SoTaiKhoanThanhToan")),
                        MaLoaiTietKiem = reader.GetInt32(reader.GetOrdinal("MaLoaiTietKiem")),
                        LaiSuatApDung = reader.GetDouble(reader.GetOrdinal("LaiSuatApDung")),
                        LaiSuatPhatSinh = reader.GetDouble(reader.GetOrdinal("LaiSuatPhatSinh")),
                        NgayDaoHanKeTiep = reader.GetDateTime(reader.GetOrdinal("NgayDaoHanKeTiep")), // DATE
                        NgayGui = reader.GetDateTime(reader.GetOrdinal("NgayGoi")), // DATE
                        TongTienGoc = reader.GetDouble(reader.GetOrdinal("TongTienGoc")), // Sử dụng GetDouble
                        TongTienLaiPhatSinh = reader.GetDouble(reader.GetOrdinal("TongTienLaiPhatSinh")) // Sử dụng GetDouble
                    };
                }
            }
            return null;
        }

        public LoaiTietKiem GetLoaiTietKiemById(int maLoaiTietKiem)
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
                        SoNgayToiThieuDuocRutTien = reader.GetInt32(reader.GetOrdinal("SoNgayToiThieuDuocRutTien"))
                    };
                }
            }
            return null;
        }

        public double GetLaiSuatKhongKyHan()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT TOP 1 LaiSuat FROM LoaiTietKiem WHERE KyHan = 0";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToDouble(result) : 0.0;
            }
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
                string query = @"INSERT INTO ChiTietRutTien 
                             (SoTaiKhoanTienGoi, NgayRut, SoTienRut) 
                             VALUES (@SoTaiKhoanTienGoi, @NgayRut, @SoTienRut)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SoTaiKhoanTienGoi", chiTietRutTien.SoTaiKhoanGuiTien);
                cmd.Parameters.AddWithValue("@NgayRut", chiTietRutTien.NgayRut);
                cmd.Parameters.AddWithValue("@SoTienRut", chiTietRutTien.SoTienRut);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateKhachHangSoDu(int soTaiKhoanThanhToan, double soTienRut)
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
