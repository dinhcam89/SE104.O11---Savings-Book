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
    public class WithdrawSlipDAO
    {
        private DatabaseConnection dbConnection;
        public WithdrawSlipDAO()
        {
            dbConnection = new DatabaseConnection();
        }
        private static List<WithdrawSlipDTO>? mapWithdrawSlips(DataTable? result)
        {
            List<WithdrawSlipDTO> withdrawSlipList = new();
            if (result == null) return null;
            foreach (DataRow row in result.Rows)
            {
                WithdrawSlipDTO withdrawSlip = new WithdrawSlipDTO();
                withdrawSlip.MaSo = (int)row["MaSo"];
                withdrawSlip.TenKhachHang = (string)row["HoTen"];
                withdrawSlip.NgayRut = DateOnly.FromDateTime((DateTime)row["NgayRut"]);
                withdrawSlip.SoTienRut = (double)row["SoTienRut"];
                withdrawSlipList.Add(withdrawSlip);
            }

            return withdrawSlipList;
        }
        public List<WithdrawSlipDTO>? getAllWithdrawSlip()
        {
            string query = string.Format(
                "SELECT PRT.MaSo, KH.HoTen, PRT.NgayRut, PRT.SoTienRut " +
                "FROM PhieuRutTien PRT, KhachHang KH " +
                "WHERE PRT.MaSo = KH.MaSo");
            SqlParameter[] sqlParameters = [];
            DataTable? result = dbConnection.executeSelectQuery(query, sqlParameters);

            return mapWithdrawSlips(result);
        }
        public List<WithdrawSlipDTO>? getWithdrawSlipByDate(DateOnly date) 
        {
            string query = string.Format(
                "SELECT PRT.MaSo, KH.HoTen, PRT.NgayRut, PRT.SoTienRut " +
                "FROM PhieuRutTien PRT, KhachHang KH " +
                "WHERE PRT.MaSo = KH.MaSo AND PRT.NgayRut = @withdrawDate");
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@withdrawDate", SqlDbType.DateTime);
            sqlParameters[0].Value = date;
            DataTable? result = dbConnection.executeSelectQuery(query, sqlParameters);
            return mapWithdrawSlips(result);
        }   
    }
}
