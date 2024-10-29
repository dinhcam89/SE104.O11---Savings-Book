using DTO;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class BookTypeDAO
    {
        private DatabaseConnection dbConnection;

        public BookTypeDAO()
        {
            dbConnection = new DatabaseConnection();
        }
        private static List<BookTypeDTO>? mapDataTableToBookType(DataTable? result)
        {
            List<BookTypeDTO> bookTypeList = new();
            if (result == null) return null;
            foreach (DataRow dr in result.Rows)
            {
                BookTypeDTO bookType = new BookTypeDTO();
                bookType.MaSo = (int)dr["MaSo"];
                bookType.ThoiHan = (int)dr["ThoiHan"];
                bookType.LaiSuatNam = (float)dr["LaiSuatNam"];
                bookType.SoTienBanDauToiThieu = (float)dr["SoTienBanDauToiThieu"];
                bookType.SoTienGoiThemToiThieu = (float)dr["SoTienGoiThemToiThieu"];
                bookType.ThoiGianGoiThemToiThieu = (int)dr["ThoiGianGoiThemToiThieu"];
                bookTypeList.Add(bookType);
            }
            return bookTypeList;
        }
        public List<BookTypeDTO>? getAllBookTypes()
        {
            string query = string.Format("select * from LoaiTietKiem");
            SqlParameter[] sqlParameters = [];
            DataTable? result = dbConnection.executeSelectQuery(query, sqlParameters);

            return mapDataTableToBookType(result);
        }

        public BookTypeDTO? searchBookTypeById(int _id)
        {
            string query = string.Format("select * from LoaiTietKiem where MaSo = @BookTypeId");
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@BookTypeId", SqlDbType.Int);
            sqlParameters[0].Value = _id;
            DataTable? result = dbConnection.executeSelectQuery(query, sqlParameters);

            var bookTypes = mapDataTableToBookType(result);
            return bookTypes?.First();
        }
        public bool insertBookType(int _id, int _term, float _interestRate, float _minInitialDeposit, float _minDeposit, int _minDepositTime)
        {
            string query = string.Format("insert into LoaiTietKiem values(@BookTypeId, @Term, @InterestRate, @MinInitialDeposit, @MinDeposit, @MinDepositTime)");
            SqlParameter[] sqlParameters = createBookTypeParameters(_id, _term, _interestRate, _minInitialDeposit, _minDeposit, _minDepositTime);
            bool result = false;
            try
            {
                result = dbConnection.executeInsertQuery(query, sqlParameters);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return result;
        }

        public bool deleteBookType(int _id)
        {
            string query = string.Format("delete from LoaiTietKiem where MaSo = @BookTypeId");
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@BookTypeId", SqlDbType.Int);
            sqlParameters[0].Value = _id;
            bool result = false;
            try
            {
                result = dbConnection.executeInsertQuery(query, sqlParameters);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return result;
        }

        public bool updateBookType(int _id, int _term, float _interestRate, float _minInitialDeposit, float _minDeposit, int _minDepositTime)
        {
            string query = string.Format("update LoaiTietKiem set ThoiHan = @Term, LaiSuatNam = @InterestRate, SoTienBanDauToiThieu = @MinInitialDeposit, SoTienGoiThemToiThieu = @MinDeposit, ThoiGianGoiThemToiThieu = @MinDepositTime where MaSo = @BookTypeId");
            SqlParameter[] sqlParameters = createBookTypeParameters(_id, _term, _interestRate, _minInitialDeposit, _minDeposit, _minDepositTime);
            bool result = false;
            try
            {
                result = dbConnection.executeInsertQuery(query, sqlParameters);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return result;
        }

        private static SqlParameter[] createBookTypeParameters(int _id, int _term, float _interestRate, float _minInitialDeposit, float _minDeposit, int _minDepositTime)
        {
            SqlParameter[] sqlParameters = new SqlParameter[6];
            sqlParameters[0] = new SqlParameter("@BookTypeId", SqlDbType.Int);
            sqlParameters[0].Value = _id;
            sqlParameters[1] = new SqlParameter("@Term", SqlDbType.Int);
            sqlParameters[1].Value = _term;
            sqlParameters[2] = new SqlParameter("@InterestRate", SqlDbType.Float);
            sqlParameters[2].Value = _interestRate;
            sqlParameters[3] = new SqlParameter("@MinInitialDeposit", SqlDbType.Float);
            sqlParameters[3].Value = _minInitialDeposit;
            sqlParameters[4] = new SqlParameter("@MinDeposit", SqlDbType.Float);
            sqlParameters[4].Value = _minDeposit;
            sqlParameters[5] = new SqlParameter("@MinDepositTime", SqlDbType.Int);
            sqlParameters[5].Value = _minDepositTime;
            return sqlParameters;
        }
    }
}
