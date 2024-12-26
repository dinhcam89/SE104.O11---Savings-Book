using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DAO
{
    public class KhachHangDAO
    {
        private DatabaseConnection dbConnection;
        public KhachHangDAO()
        {
            dbConnection = new DatabaseConnection();
        }
        public List<KhachHang> getAllKhachHang()
        {
            string query = "" +
                "SELECT " +
                "   * " +
                "FROM " +
                "   KhacHang";
            List<KhachHang> khachHangs = new List<KhachHang>();
            DataTable? dataTable = dbConnection.executeSelectQuery(query, null);

            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    KhachHang khachHang = new KhachHang();
                    khachHang.SoTaiKhoanThanhToan = row["SoTaiKhoanThanhToan"].ToString()!;
                    khachHang.TenKhachHang = row["TenKhachHang"].ToString()!;
                    khachHang.CCCD = row["CCCD"].ToString()!;
                    khachHang.NgaySinh = DateTime.Parse(row["NgaySinh"].ToString()!);
                    khachHang.DiaChi = row["DiaChi"].ToString()!;
                    khachHang.SoDienThoai = row["SoDienThoai"].ToString()!;
                    khachHangs.Add(khachHang);
                }
            }
            return khachHangs;
        }
        public KhachHang? getKhachHangById(string soTaiKhoanThanhToan)
        {
            string query = "SELECT * FROM KhachHang WHERE SoTaiKhoanThanhToan = @SoTaiKhoanThanhToan";
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@SoTaiKhoanThanhToan", soTaiKhoanThanhToan),
            };
            DataTable? dataTable = dbConnection.executeSelectQuery(query, sqlParameters);
            if (dataTable != null)
            {
                KhachHang khachHang = new KhachHang();
                khachHang.SoTaiKhoanThanhToan = dataTable.Rows[0]["SoTaiKhoanThanhToan"].ToString()!;
                khachHang.TenKhachHang = dataTable.Rows[0]["TenKhachHang"].ToString()!;
                khachHang.CCCD = dataTable.Rows[0]["CCCD"].ToString()!;
                khachHang.NgaySinh = DateTime.Parse(dataTable.Rows[0]["NgaySinh"].ToString()!);
                khachHang.DiaChi = dataTable.Rows[0]["DiaChi"].ToString()!;
                khachHang.SoDienThoai = dataTable.Rows[0]["SoDienThoai"].ToString()!;
                return khachHang;
            }
            return null;
        }

    }
}
