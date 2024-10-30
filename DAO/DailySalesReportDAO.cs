using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class DailySalesReportDAO
    {
        private DatabaseConnection dbConnection;

        public DailySalesReportDAO()
        {
            dbConnection = new DatabaseConnection();
        }
        private static List<DailySalesReportDTO>? mapDailySalesReportDTO(DataTable? result)
        {
            List<DailySalesReportDTO> dailySalesReportList = new();
            if (result == null) return null;
            foreach (DataRow row in result.Rows)
            {
                DailySalesReportDTO dailySalesReport = new DailySalesReportDTO();
                dailySalesReport.LoaiTietKiem = (int)row["ThoiHan"];
                dailySalesReport.TongThu = (double)row["TongThu"];
                dailySalesReport.TongChi = (double)row["TongChi"];
                dailySalesReport.ChenhLech = (double)row["ChenhLech"];
                dailySalesReportList.Add(dailySalesReport);
            }
            return dailySalesReportList;
        }
        public List<DailySalesReportDTO>? getDailySalesReportByDate(DateTime date)
        {
            string query = string.Format("" +
                "SELECT" +
                "   LTK.ThoiHan, " +
                "   SUM(PGT.SoTienGoi) AS TongThu, " +
                "   SUM(PRT.SoTienRut) AS TongChi, " +
                "   SUM(PGT.SoTienGoi) - SUM(PRT.SoTienRut) AS ChenhLech " +
                "FROM " +
                "   PhieuRutTien PRT, " +
                "   PhieuGoiTien PGT, " +
                "   SoTietKiem STK, " +
                "   LoaiTietKiem LTK " +
                "WHERE " +
                "   STK.MaSo = PRT.MSSoTietKiem AND " +
                "   STK.MaSo = PGT.MSSoTietKiem AND " +
                "   STK.MSLoaiTietKiem = LTK.MaSo AND " +
                "   PRT.NgayRut = @reportDate " +
                "GROUP BY " +
                "   LTK.ThoiHan");
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@reportDate", SqlDbType.DateTime);
            const string format = "yyyy-MM-dd";
            sqlParameters[0].Value = date.ToString(format);
            DataTable? result = dbConnection.executeSelectQuery(query, sqlParameters);

            return mapDailySalesReportDTO(result);
        }
    }
}
