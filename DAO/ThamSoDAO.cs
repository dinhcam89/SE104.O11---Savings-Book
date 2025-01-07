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
                thamSo.MaThamSo = dataTable.Rows[0]["MaThamSo"].ToString()!;
                thamSo.SoTienBanDauToiThieu = double.Parse(dataTable.Rows[0]["SoTienBanDauToiThieu"].ToString() ?? "0");
                thamSo.SoTienGoiThemToiThieu = double.Parse(dataTable.Rows[0]["SoTienGoiThemToiThieu"].ToString() ?? "0");
                return thamSo;
            }
            return null;
        }
        public ThamSo? getDefaultThamSo()
        {
            string query = "" +
                "SELECT * " +
                "FROM THAMSO";
            DataTable? dataTable = dbConnection.executeSelectQuery(query, null);
            if (dataTable != null)
            {
                ThamSo thamSo = new ThamSo();
                thamSo.MaThamSo = dataTable.Rows[1]["MaThamSo"].ToString()!;
                thamSo.SoTienBanDauToiThieu = double.Parse(dataTable.Rows[1]["SoTienBanDauToiThieu"].ToString() ?? "0");
                thamSo.SoTienGoiThemToiThieu = double.Parse(dataTable.Rows[1]["SoTienGoiThemToiThieu"].ToString() ?? "0");
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
                "   SoTienGoiThemToiThieu = @SoTienGoiThemToiThieu " +
                "WHERE " +
                "   MaThamSo = @MaThamSo";
            SqlParameter[] sqlParameters =
            [
                new SqlParameter("@MaThamSo", thamSo.MaThamSo),
                new SqlParameter("@SoTienBanDauToiThieu", thamSo.SoTienBanDauToiThieu),
                new SqlParameter("@SoTienGoiThemToiThieu", thamSo.SoTienGoiThemToiThieu),
            ];
            try
            {
                bool response = dbConnection.executeUpdateQuery(query, sqlParameters);
                return response;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
