using DAO;
using System.Data;

namespace BUS
{
    public class BookTypeBUS
    {
        private BookTypeDAO _bookTypeDAO;

        public BookTypeBUS()
        {
            _bookTypeDAO = new BookTypeDAO();
        }

        public DataTable? getAllBookType()
        {
            DataTable? dataTable = _bookTypeDAO.getAllBookTypes();
            return dataTable;
        }

        public DataTable? searchBookTypeById(int _id)
        {
            DataTable? dataTable = _bookTypeDAO.searchBookTypeById(_id);
            return dataTable;
        }
    }
}
