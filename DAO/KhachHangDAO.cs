
using System;
using System.Data.Common;
using System.Data.SqlClient;
using DTO;
namespace DAO;
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
                khachHang.SoTaiKhoanThanhToan = GenerateUniqueSoTaiKhoan(conn, "ThanhToan");

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
                cmd.Parameters.AddWithValue("@NgaySinh", khachHang.NgaySinh.HasValue ? khachHang.NgaySinh.Value : (object)DBNull.Value);
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

    private string GenerateUniqueSoTaiKhoan(SqlConnection conn, string loaiTaiKhoan)
    {
        Random rand = new Random();
        string soTaiKhoan;
        string prefix; // Phần đầu của số tài khoản

        // Xác định tiền tố dựa trên loại tài khoản
        if (loaiTaiKhoan == "ThanhToan")
        {
            prefix = "KH"; // Số tài khoản thanh toán
        }
        else if (loaiTaiKhoan == "GoiTien")
        {
            prefix = "PGT"; // Số tài khoản gửi tiền
        }
        else
        {
            throw new Exception("Loại tài khoản không hợp lệ!");
        }

        while (true)
        {
            if (loaiTaiKhoan == "ThanhToan")
            {
                // Sinh số ngẫu nhiên có 8 chữ số
                soTaiKhoan = prefix + rand.Next(10000000, 99999999).ToString();
            }
            else
            {
                // Sinh số ngẫu nhiên có 7 chữ số
                soTaiKhoan = prefix + rand.Next(1000000, 9999999).ToString();
            }

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
