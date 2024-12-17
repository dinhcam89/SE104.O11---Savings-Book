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
    public class ThamSoDAO
    {
        private DatabaseConnection dbConnection;
        public ThamSoDAO()
        {
            dbConnection = new DatabaseConnection();
        }
        public ThamSo? getThamSo()
        {
            string query = "" +
                "SELECT * " +
                "FROM THAMSO";
            DataTable? dataTable = dbConnection.executeSelectQuery(query, null);
            if (dataTable != null)
            {
                ThamSo thamSo = new ThamSo();
                thamSo.SoTienGuiBanDauToiThieu = double.Parse(dataTable.Rows[0]["SoTienGuiBanDauToiThieu"].ToString() ?? "0");
                thamSo.SoTienGuiThemToiThieu = double.Parse(dataTable.Rows[0]["SoTienGuiThemToiThieu"].ToString() ?? "0");
                return thamSo;
            }
            return null;
        }
        public bool updateThamSo(ThamSo thamSo)
        {
            string query = "" +
                "UPDATE " +
                "   ThamSo " +
                "SET " +
                "   SoTienBanDauToiThieu = @SoTienBanDauToiThieu, " +
                "   SoTienGoiThemToiThieu = @SoTienGoiThemToiThieu";
            SqlParameter[] sqlParameters =
            [
                new SqlParameter("@SoTienGuiBanDauToiThieu", thamSo.SoTienGuiBanDauToiThieu),
                new SqlParameter("@SoTienGuiThemToiThieu", thamSo.SoTienGuiThemToiThieu),
            ];
            bool response = dbConnection.executeUpdateQuery(query, sqlParameters);
            return response;
        }
    }
}
