using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;

namespace DAO
{
    public class BaoCaoDAO
    {
        private string connectionString = @"Server=MSI\SQLEXPRESS;Database=saving_books_management;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True";

        public List<BaoCaoGiaoDich> LayDanhSachGiaoDich(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            // Gọi vào database hoặc logic để lấy dữ liệu giao dịch
            string truyVan = @"SELECT 
                         KH.TenKhachHang, 
                         PGT.SoTaiKhoanTienGoi, 
                         PGT.TongTienGoc AS SoTienGui, 
                         LTK.KyHan AS LoaiKyHan, 
                         PGT.NgayGoi AS NgayTao
                     FROM PhieuGoiTien PGT
                     JOIN KhachHang KH ON PGT.SoTaiKhoanThanhToan = KH.SoTaiKhoanThanhToan
                     JOIN LoaiTietKiem LTK ON PGT.MaLoaiTietKiem = LTK.MaLoaiTietKiem
                     WHERE PGT.NgayGoi BETWEEN @NgayBatDau AND @NgayKetThuc;";

            List<BaoCaoGiaoDich> danhSachGiaoDich = new List<BaoCaoGiaoDich>();
            using (var ketNoi = new SqlConnection(connectionString))
            {
                var lenh = new SqlCommand(truyVan, ketNoi);
                lenh.Parameters.AddWithValue("@NgayBatDau", ngayBatDau);
                lenh.Parameters.AddWithValue("@NgayKetThuc", ngayKetThuc);

                ketNoi.Open();
                using (var doc = lenh.ExecuteReader())
                {
                    while (doc.Read())
                    {
                        var giaoDich = new BaoCaoGiaoDich
                        {
                            TenKhachHang = doc["TenKhachHang"].ToString(),
                            SoTaiKhoanTienGoi = doc["SoTaiKhoanTienGoi"].ToString(),
                            SoTienGui = Convert.ToDecimal(doc["SoTienGui"]),
                            LoaiKyHan = doc["LoaiKyHan"].ToString(),
                            NgayTao = Convert.ToDateTime(doc["NgayTao"])
                        };
                        danhSachGiaoDich.Add(giaoDich);
                    }
                }
            }
            return danhSachGiaoDich;
        }


    }
}
