using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DAO
{
    public class LoaiTietKiemDAO
    {
        private DatabaseConnection dbConnection;
        public LoaiTietKiemDAO()
        {
            dbConnection = new DatabaseConnection();
        }
        public List<LoaiTietKiem> getAllLoaiTietKiem()
        {
            string query = "" +
                "SELECT " +
                "   * " +
                "FROM " +
                "   LoaiTietKiem";
            List<LoaiTietKiem> listLoaiTietKiem = new List<LoaiTietKiem>();
            DataTable? dataTable = dbConnection.executeSelectQuery(query, null);
            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    LoaiTietKiem loaiTietKiem = new LoaiTietKiem();
                    loaiTietKiem.MaLoaiTietKiem = row["MaLoaiTietKiem"].ToString()!;
                    loaiTietKiem.KyHan = int.Parse(row["KyHan"].ToString()!);
                    loaiTietKiem.LaiSuat = double.Parse(row["LaiSuat"].ToString()!);
                    loaiTietKiem.SoNgayToiThieuDuocRutTien = int.Parse(row["SoNgayToiThieuDuocRutTien"].ToString()!);
                    loaiTietKiem.QuyDinhSoTienRut = row["QuyDinhSoTienRut"].ToString()!;
                    listLoaiTietKiem.Add(loaiTietKiem);
                }
            }
            return listLoaiTietKiem;
        }
        public LoaiTietKiem? getLoaiTietKiem(LoaiTietKiem ltk)
        {
            string query = "" +
                "SELECT " +
                "   * " +
                "FROM " +
                "   LoaiTietKiem " +
                "WHERE " +
                "   MaLoaiTietKiem = @MaLoaiTietKiem";
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@MaLoaiTietKiem", ltk.MaLoaiTietKiem),
            };
            DataTable? dataTable = dbConnection.executeSelectQuery(query, sqlParameters);
            if (dataTable != null)
            {
                LoaiTietKiem loaiTietKiem = new LoaiTietKiem();
                loaiTietKiem.MaLoaiTietKiem = dataTable.Rows[0]["MaLoaiTietKiem"].ToString()!;
                loaiTietKiem.KyHan = int.Parse(dataTable.Rows[0]["KyHan"].ToString()!);
                loaiTietKiem.LaiSuat = double.Parse(dataTable.Rows[0]["LaiSuat"].ToString()!);
                loaiTietKiem.SoNgayToiThieuDuocRutTien = int.Parse(dataTable.Rows[0]["SoNgayToiThieuDuocRutTien"].ToString()!);
                loaiTietKiem.QuyDinhSoTienRut = dataTable.Rows[0]["QuyDinhSoTienRut"].ToString()!;
                return loaiTietKiem;
            }
            return null;
        }
        public LoaiTietKiem? getLoaiTietKiemById(string maLoaiTietKiem)
        {
            LoaiTietKiem ltk = new LoaiTietKiem();
            ltk.MaLoaiTietKiem = maLoaiTietKiem;
            return getLoaiTietKiem(ltk);
        }
        public bool updateLoaiTietKiem(LoaiTietKiem ltk)
        {
            string query = "" +
                "UPDATE " +
                "   LoaiTietKiem " +
                "SET " +
                "   KyHan = @KyHan, " +
                "   LaiSuat = @LaiSuat, " +
                "   SoNgayToiThieuDuocRutTien = @SoNgayToiThieuDuocRutTien, " +
                "   QuyDinhSoTienRut = @QuyDinhSoTienRut " +
                "WHERE " +
                "   MaLoaiTietKiem = @MaLoaiTietKiem";
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@KyHan", ltk.KyHan),
                new SqlParameter("@LaiSuat", ltk.LaiSuat),
                new SqlParameter("@SoNgayToiThieuDuocRutTien", ltk.SoNgayToiThieuDuocRutTien),
                new SqlParameter("@QuyDinhSoTienRut", ltk.QuyDinhSoTienRut),
                new SqlParameter("@MaLoaiTietKiem", ltk.MaLoaiTietKiem),
            };
            bool response = dbConnection.executeUpdateQuery(query, sqlParameters);
            return response;
        }
        public bool deleteLoaiTietKiem(LoaiTietKiem ltk)
        {
            string query = "" +
                "DELETE " +
                "FROM " +
                "   LoaiTietKiem " +
                "WHERE " +
                "   MaLoaiTietKiem = @MaLoaiTietKiem";
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@MaLoaiTietKiem", ltk.MaLoaiTietKiem),
            };
            bool response = dbConnection.executeUpdateQuery(query, sqlParameters);
            return response;
        }
        public bool insertLoaiTietKiem(int kyHan, double laiSuat, int soNgayToiThieuDuocRutTien, string quyDinhSoTienRut)
        {
            string query = "" +
                "INSERT INTO " +
                "   LoaiTietKiem " +
                "VALUES " +
                "   (@KyHan, @LaiSuat, @SoNgayToiThieuDuocRutTien, @QuyDinhSoTienRut)";
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@KyHan", kyHan),
                new SqlParameter("@LaiSuat", laiSuat),
                new SqlParameter("@SoNgayToiThieuDuocRutTien", soNgayToiThieuDuocRutTien),
                new SqlParameter("@QuyDinhSoTienRut", quyDinhSoTienRut),
            };
            bool response = dbConnection.executeUpdateQuery(query, sqlParameters);
            return response;
        }
    }
}
