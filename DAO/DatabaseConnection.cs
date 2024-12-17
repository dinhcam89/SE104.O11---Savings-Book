using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace DAO
{
    internal class DatabaseConnection
    {
        private SqlDataAdapter adapter = new();
        private SqlConnection connection = new();

        public DatabaseConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }

        private SqlConnection openConnection()
        {
            if (connection.State == ConnectionState.Closed || connection.State == ConnectionState.Broken)
            {
                connection.Open();
            }
            return connection;
        }

        public DataTable? executeSelectQuery(String _query, SqlParameter[] sqlParameter)
        {
            SqlCommand myCommand = new SqlCommand();
            DataTable dataTable = new DataTable();
            adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                myCommand.Connection = openConnection();
                myCommand.CommandText = _query;
                myCommand.Parameters.AddRange(sqlParameter);
                myCommand.ExecuteNonQuery();
                adapter.SelectCommand = myCommand;
                adapter.Fill(ds);
                dataTable = ds.Tables[0];
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {

            }
            return dataTable;
        }

        public bool executeInsertQuery(String _query, SqlParameter[] sqlParameter)
        {
            SqlCommand myCommand = new SqlCommand();
            try
            {
                myCommand.Connection = openConnection();
                myCommand.CommandText = _query;
                myCommand.Parameters.AddRange(sqlParameter);
                adapter.InsertCommand = myCommand;
                myCommand.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                return false;
            }
            finally
            {
            }
            return true;
        }

        public bool executeUpdateQuery(String _query, SqlParameter[] sqlParameter)
        {
            SqlCommand myCommand = new SqlCommand();
            try
            {
                myCommand.Connection = openConnection();
                myCommand.CommandText = _query;
                myCommand.Parameters.AddRange(sqlParameter);
                adapter.UpdateCommand = myCommand;
                myCommand.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                return false;
            }
            finally
            {
            }
            return true;
        }
    }
}
