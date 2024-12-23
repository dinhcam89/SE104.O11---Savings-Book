using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAO
{
    public class DSPhieuDAO
    {
        private string connectionString = @"Server=MSI\SQLEXPRESS;Database=stk_db;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True";

        //public List<PhieuGoiTien> SearchPhieuGoiTien(string keyword)
        //{
        //    List<PhieuGoiTien> PhieuGoiTienList = new List<PhieuGoiTien>();
        //    string query = @"
        //SELECT * FROM PhieuGoiTien
        //WHERE 
        //    CAST(SoTaiKhoanTienGoi AS NVARCHAR) LIKE @Keyword OR
        //    CAST(SoTaiKhoanThanhToan AS NVARCHAR) LIKE @Keyword OR
        //    CAST(MaLoaiTietKiem AS NVARCHAR) LIKE @Keyword";

        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand(query, conn);
        //        cmd.Parameters.AddWithValue("@Keyword", $"%{keyword}%");
        //        conn.Open();

        //        using (SqlDataReader reader = cmd.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                PhieuGoiTien phieu = new PhieuGoiTien
        //                {
        //                    //SoTaiKhoanTienGoi = reader.GetInt32(0),
        //                    //SoTaiKhoanThanhToan = reader.GetInt32(1),
        //                    //MaLoaiTietKiem = reader.GetInt32(2),
        //                    //LaiSuatApDung = (float)reader.GetDouble(3),
        //                    //LaiSuatPhatSinh = (float)reader.GetDouble(4),
        //                    //NgayDaoHanKeTiep = reader.GetDateTime(5),
        //                    //NgayGoi = reader.GetDateTime(6),
        //                    //TongTienGoc = (float)reader.GetDouble(7),
        //                    //TongTienLaiPhatSinh = (float)reader.GetDouble(8),
        //                    //HinhThucGiaHan = reader.GetInt32(9),
        //                };
        //                PhieuGoiTienList.Add(phieu);
        //            }
        //        }
        //    }
        //    return PhieuGoiTienList;
        //}

    }
}
