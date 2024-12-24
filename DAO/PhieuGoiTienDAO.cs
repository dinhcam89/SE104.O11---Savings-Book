using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;

namespace DAO
{
    public class PhieuGoiTienDAO
    {
        private DatabaseConnection dbConnection;
        public PhieuGoiTienDAO()
        {
            dbConnection = new DatabaseConnection();
        }
        public List<PhieuGoiTien> getAllPhieuGoiTien()
        {
            string query = "" +
                "SELECT * " +
                "FROM PhieuGoiTien";
            List<PhieuGoiTien> listPhieuGoiTien = new List<PhieuGoiTien>();
            DataTable? dataTable = dbConnection.executeSelectQuery(query, null);
            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    PhieuGoiTien phieuGoiTien = new PhieuGoiTien();
                    phieuGoiTien.SoTaiKhoanTienGoi = row["SoTaiKhoanTienGoi"].ToString()!;
                    phieuGoiTien.SoTaiKhoanThanhToan = row["SoTaiKhoanThanhToan"].ToString()!;
                    phieuGoiTien.MaLoaiTietKiem = row["MaLoaiTietKiem"].ToString()!;
                    phieuGoiTien.NgayGoi = DateTime.Parse(row["NgayGoi"].ToString()!);
                    phieuGoiTien.LaiSuatApDung = double.Parse(row["LaiSuatApDung"].ToString()!);
                    phieuGoiTien.LaiSuatPhatSinh = double.Parse(row["LaiSuatPhatSinh"].ToString()!);
                    phieuGoiTien.TongTienGoc = double.Parse(row["TongTienGoc"].ToString()!);
                    phieuGoiTien.HinhThucGiaHan = int.Parse(row["HinhThucGiaHan"].ToString()!);
                    phieuGoiTien.TongTienLaiPhatSinh = double.Parse(row["TongTienLaiPhatSinh"].ToString()!);
                    phieuGoiTien.NgayDaoHanKeTiep = DateTime.Parse(row["NgayDaoHanKeTiep"].ToString()!);
                    listPhieuGoiTien.Add(phieuGoiTien);
                }
            }
            return listPhieuGoiTien;
        }
        /// <summary>
        /// Cập nhật phiếu gởi tiền, ngoại trừ Tài khoản tiền gởi, Tài khoản thanh toán, Mã loại tiết kiệm, Ngày gởi và Hình thức gia hạn là không được cập nhật, thì các trường còn lại đều có thể cập nhật
        /// </summary>
        /// <param name="pgt">Phiếu gởi tiền cần cập nhật vào database</param>
        /// <returns>Trạng thái thành công của lệnh query UPDATE</returns>
        public bool updatePhieuGoiTien(PhieuGoiTien pgt)
        {
            string query = "" +
                "UPDATE " +
                "   PhieuGoiTien " +
                "SET " +
                "   LaiSuatApDung = @LaiSuatApDung, " +
                "   LaiSuatPhatSinh = @LaiSuatPhatSinh, " +
                "   NgayDaoHanKeTiep = @NgayDaoHanKeTiep, " +
                "   TongTienGoc = @TongTienGoc, " +
                "   TongTienLaiPhatSinh = @TongTienLaiPhatSinh, " +
                "WHERE " +
                "   SoTaiKhoanTienGoi = @SoTaiKhoanTienGoi";
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@LaiSuatApDung", pgt.LaiSuatApDung),
                new SqlParameter("@LaiSuatPhatSinh", pgt.LaiSuatPhatSinh),
                new SqlParameter("@NgayDaoHanKeTiep", pgt.NgayDaoHanKeTiep),
                new SqlParameter("@TongTienGoc", pgt.TongTienGoc),
                new SqlParameter("@TongTienLaiPhatSinh", pgt.TongTienLaiPhatSinh),
                new SqlParameter("@SoTaiKhoanTienGoi", pgt.SoTaiKhoanTienGoi),
            };
            return dbConnection.executeUpdateQuery(query, sqlParameters);
        }
    }
}
