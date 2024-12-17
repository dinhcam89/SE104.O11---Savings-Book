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
                thamSo.SoTienBanDauToiThieu = double.Parse(dataTable.Rows[0]["SoTienBanDauToiThieu"].ToString() ?? "0");
                thamSo.SoTienGoiThemToiThieu = double.Parse(dataTable.Rows[0]["SoTienGoiThemToiThieu"].ToString() ?? "0");
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
                new SqlParameter("@SoTienBanDauToiThieu", thamSo.SoTienBanDauToiThieu),
                new SqlParameter("@SoTienGoiThemToiThieu", thamSo.SoTienGoiThemToiThieu),
            ];
            bool response = dbConnection.executeUpdateQuery(query, sqlParameters);
            return response;
        }
    }
}
