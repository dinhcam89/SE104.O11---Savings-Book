using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class MonthlySavingBookReportDAO
    {
        private DatabaseConnection dbConnection;
        public MonthlySavingBookReportDAO()
        {
            dbConnection = new DatabaseConnection();
        }
        private int getLastDayOfMonth(DateTime date)
        {
            // Move to the first day of the next month and subtract one day to get the last day of the current month
            DateTime lastDay = new DateTime(date.Year, date.Month, 1).AddMonths(1).AddDays(-1);
            return lastDay.Day;
        }
        private string getFirstDayOfMonthString(DateTime date)
        {
            return date.ToString("yyyy-MM-01");
        }
        private string getLastDayOfMonthString(DateTime date)
        {
            return date.ToString("yyyy-MM-") + getLastDayOfMonth(date);
        }
        private static List<MonthlySavingBookReportDTO>? mapMonthlySavingBookReportDTO(DataTable? result)
        {
            List<MonthlySavingBookReportDTO> monthlySavingBookReports = new();
            if (result == null) return null;
            foreach (DataRow row in result.Rows)
            {
                MonthlySavingBookReportDTO monthlySavingBookReport = new();
                monthlySavingBookReport.Ngay = (DateTime)row["Ngay"];
                monthlySavingBookReport.SoSoMo = (int)row["SoSoMo"];
                monthlySavingBookReport.SoSoDong = (int)row["SoSoDong"];
                monthlySavingBookReport.ChenhLech = (int)row["ChenhLech"];
                monthlySavingBookReports.Add(monthlySavingBookReport);
            }
            return monthlySavingBookReports;
        }
        public List<MonthlySavingBookReportDTO>? getAll()
        {
            string query = string.Format("" +
                "SELECT " +
                "   Ngay, " +
                "   COUNT(mo.NgayMoSo) AS SoSoMo, " +
                "   COUNT(dong.NgayDongSo) AS SoSoDong, " +
                "   COUNT(mo.NgayMoSo) - COUNT(dong.NgayDongSo) AS ChenhLech " +
                "FROM " +
                "   LoaiTietKiem LTK, " +
                "   ( " +
                "   SELECT NgayMoSo AS Ngay, MSLoaiTietKiem MSLTK FROM SoTietKiem " +
                "   UNION ALL " +
                "   SELECT NgayDongSo AS Ngay, MSLoaiTietKiem MSLTK FROM SoTietKiem" +
                "   ) AS NgayGop " +
                "LEFT JOIN SoTietKiem mo ON NgayGop.Ngay = mo.NgayMoSo " +
                "LEFT JOIN SoTietKiem dong ON NgayGop.Ngay = dong.NgayDongSo " +
                "WHERE " +
                "   LTK.MaSo = MSLTK " +
                "GROUP BY " +
                "   Ngay");
            SqlParameter[] sqlParameters = new SqlParameter[0];
            DataTable? result = dbConnection.executeSelectQuery(query, sqlParameters);

            return mapMonthlySavingBookReportDTO(result);
        }
        public List<DTO.MonthlySavingBookReportDTO>? getByMonthAndBookType(DateTime date, int bookTypeId)
        {
            string query = string.Format("" +
                "SELECT " +
                "   Ngay, " +
                "   COUNT(mo.NgayMoSo) AS SoSoMo, " +
                "   COUNT(dong.NgayDongSo) AS SoSoDong, " +
                "   COUNT(mo.NgayMoSo) - COUNT(dong.NgayDongSo) AS ChenhLech " +
                "FROM " +
                "   LoaiTietKiem LTK, " +
                "   ( " +
                "   SELECT NgayMoSo AS Ngay, MSLoaiTietKiem MSLTK FROM SoTietKiem " +
                "   UNION ALL " +
                "   SELECT NgayDongSo AS Ngay, MSLoaiTietKiem MSLTK FROM SoTietKiem" +
                "   ) AS NgayGop " +
                "LEFT JOIN SoTietKiem mo ON NgayGop.Ngay = mo.NgayMoSo " +
                "LEFT JOIN SoTietKiem dong ON NgayGop.Ngay = dong.NgayDongSo " +
                "WHERE " +
                "   LTK.MaSo = MSLTK AND " +
                "   (Ngay BETWEEN @reportStartDate AND @reportEndDate) AND " +
                "   LTK.MaSo = @bookTypeId " +
                "GROUP BY " +
                "   Ngay");
            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@reportStartDate", SqlDbType.DateTime);
            sqlParameters[0].Value = getFirstDayOfMonthString(date);
            sqlParameters[1] = new SqlParameter("@reportEndDate", SqlDbType.DateTime);
            sqlParameters[1].Value = getLastDayOfMonthString(date);
            sqlParameters[2] = new SqlParameter("@bookTypeId", SqlDbType.Int);
            sqlParameters[2].Value = bookTypeId;
            DataTable? result = dbConnection.executeSelectQuery(query, sqlParameters);

            return mapMonthlySavingBookReportDTO(result);
        }
        public DataTable? getTotalReport(DateTime date, int bookTypeId)
        {
            string query = string.Format("" +
                "SELECT " +
                "   COUNT(mo.NgayMoSo) AS SoSoMo, " +
                "   COUNT(dong.NgayDongSo) AS SoSoDong, " +
                "   COUNT(mo.NgayMoSo) - COUNT(dong.NgayDongSo) AS ChenhLech " +
                "FROM " +
                "   LoaiTietKiem LTK, " +
                "   ( " +
                "   SELECT NgayMoSo AS Ngay, MSLoaiTietKiem MSLTK FROM SoTietKiem " +
                "   UNION ALL " +
                "   SELECT NgayDongSo AS Ngay, MSLoaiTietKiem MSLTK FROM SoTietKiem" +
                "   ) AS NgayGop " +
                "LEFT JOIN SoTietKiem mo ON NgayGop.Ngay = mo.NgayMoSo " +
                "LEFT JOIN SoTietKiem dong ON NgayGop.Ngay = dong.NgayDongSo " +
                "WHERE " +
                "   LTK.MaSo = MSLTK AND " +
                "   (Ngay BETWEEN @reportStartDate AND @reportEndDate) AND " +
                "   LTK.MaSo = @bookTypeId");
            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@reportStartDate", SqlDbType.DateTime);
            sqlParameters[0].Value = getFirstDayOfMonthString(date);
            sqlParameters[1] = new SqlParameter("@reportEndDate", SqlDbType.DateTime);
            sqlParameters[1].Value = getLastDayOfMonthString(date);
            sqlParameters[2] = new SqlParameter("@bookTypeId", SqlDbType.Int);
            sqlParameters[2].Value = bookTypeId;
            DataTable? result = dbConnection.executeSelectQuery(query, sqlParameters);

            return result;


        }
    }
}
