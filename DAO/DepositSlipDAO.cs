using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class DepositSlipDAO
    {
        private DatabaseConnection dbConnection;
        public DepositSlipDAO()
        {
            dbConnection = new DatabaseConnection();
        }
        private static List<DepositSlipDTO>? MapDataTableToDepositSlipDTO(DataTable? result)
        {
            List<DepositSlipDTO>? depositSlipData = new();
            if (result == null) return null;
            for (int i = 0; i < result.Rows.Count; i++)
            {
                DataRow row = result.Rows[i];
                DepositSlipDTO depositSlip = new DepositSlipDTO();
                depositSlip.MaSo = (int)row["MaSo"];
                depositSlip.TenKhachHang = (string)row["HoTen"];
                depositSlip.NgayGui = DateOnly.FromDateTime((DateTime)row["NgayGoi"]);
                depositSlip.SoTienGui = (double)row["SoTienGoi"];
                depositSlipData.Add(depositSlip);
            }
            return depositSlipData;
        }
        public List<DepositSlipDTO>? getAllDepositSlip()
        {
            string query = string.Format(
                "SELECT " +
                "   PGT.MaSo, " +
                "   KH.HoTen, " +
                "   PGT.NgayGoi, " +
                "   PGT.SoTienGoi " +
                "FROM " +
                "   PhieuGoiTien PGT, " +
                "   KhachHang KH " +
                "WHERE " +
                "   PGT.MSKhachHang = KH.MaSo");
            SqlParameter[] sqlParameters = new SqlParameter[0];
            DataTable? result = dbConnection.executeSelectQuery(query, sqlParameters);

            return MapDataTableToDepositSlipDTO(result);
        }
        public List<DepositSlipDTO>? getDepositSlipByDate(DateOnly date)
        {
            string query = string.Format(
                "SELECT " +
                "   PGT.MaSo, " +
                "   KH.HoTen, " +
                "   PGT.NgayGoi, " +
                "   PGT.SoTienGoi " +
                "FROM " +
                "   PhieuGoiTien PGT, " +
                "   KhachHang KH " +
                "WHERE " +
                "   PGT.MSKhachHang = KH.MaSo AND " +
                "   PGT.NgayGoi = @depositDate");
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@depositDate", SqlDbType.DateTime);
            sqlParameters[0].Value = date;
            DataTable? result = dbConnection.executeSelectQuery(query, sqlParameters);

            return MapDataTableToDepositSlipDTO(result);
        }
    }
}
