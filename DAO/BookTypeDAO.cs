using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class BookTypeDAO
    {
        private DatabaseConnection connection;

        public BookTypeDAO()
        {
            connection = new DatabaseConnection();
        }

        public DataTable? getAllBookTypes()
        {
            string query = string.Format("select * from LoaiTietKiem");
            SqlParameter[] sqlParameters = [];
            DataTable? result = connection.executeSelectQuery(query, sqlParameters);
            return result;
        }

        public DataTable? searchBookTypeById(int _id)
        {
            string query = string.Format("select * from LoaiTietKiem where MaSo = @BookTypeId");
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@BookTypeId", SqlDbType.Int);
            sqlParameters[0].Value = _id;
            DataTable? result = connection.executeSelectQuery(query, sqlParameters);
            return result;
        }
    }
}
