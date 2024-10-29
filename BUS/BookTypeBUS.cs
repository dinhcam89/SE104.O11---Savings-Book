using DAO;
using DTO;
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

        public List<BookTypeDTO>? getAllBookType()
        {
            return _bookTypeDAO.getAllBookTypes();
        }

        public BookTypeDTO? searchBookTypeById(int _id)
        {
            return _bookTypeDAO.searchBookTypeById(_id);
        }

        public bool insertBookType(int _id, int _term, float _interestRate, float _minInitialDeposit, float _minDeposit, int _minDepositTime)
        {
            bool isSuccess = _bookTypeDAO.insertBookType(_id, _term, _interestRate, _minInitialDeposit, _minDeposit, _minDepositTime);
            return isSuccess;
        }
    }
}
