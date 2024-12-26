using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;
using System.Drawing.Text;
using System.Configuration;

namespace DAO
{
    public class PhieuGoiTienDAO
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString;
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
                        SoTaiKhoanTienGoi = reader["SoTaiKhoanTienGoi"].ToString()!,
                        SoTaiKhoanThanhToan = reader["SoTaiKhoanThanhToan"].ToString()!,
                        TenKhachHang = reader["TenKhachHang"].ToString()!, // Gán tên khách hàng
                        MaLoaiTietKiem = reader["MaLoaiTietKiem"].ToString()!,
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
        public bool UpdatePhieuGoiTien(PhieuGoiTien pgt)
        {
            string query = "" +
                "UPDATE " +
                "   PhieuGoiTien " +
                "SET " +
                "   LaiSuatApDung = @LaiSuatApDung, " +
                "   LaiSuatPhatSinh = @LaiSuatPhatSinh, " +
                "   NgayDaoHanKeTiep = @NgayDaoHanKeTiep, " +
                "   TongTienGoc = @TongTienGoc, " +
                "   TongTienLaiPhatSinh = @TongTienLaiPhatSinh " +
                "WHERE " +
                "   SoTaiKhoanTienGoi = @SoTaiKhoanTienGoi";
            SqlParameter[] sqlParameters = new SqlParameter[6];
            sqlParameters[0] = new SqlParameter("@LaiSuatApDung", pgt.LaiSuatApDung);
            sqlParameters[1] = new SqlParameter("@LaiSuatPhatSinh", pgt.LaiSuatPhatSinh);
            sqlParameters[2] = new SqlParameter("@NgayDaoHanKeTiep", pgt.NgayDaoHanKeTiep);
            sqlParameters[3] = new SqlParameter("@TongTienGoc", pgt.TongTienGoc);
            sqlParameters[4] = new SqlParameter("@TongTienLaiPhatSinh", pgt.TongTienLaiPhatSinh);
            sqlParameters[5] = new SqlParameter("@SoTaiKhoanTienGoi", pgt.SoTaiKhoanTienGoi);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddRange(sqlParameters);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}

