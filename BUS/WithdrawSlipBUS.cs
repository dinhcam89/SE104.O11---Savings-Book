using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class WithdrawSlipBUS
    {
        private WithdrawSlipDAO _withdrawSlipDAO;
        public WithdrawSlipBUS()
        {
            _withdrawSlipDAO = new WithdrawSlipDAO();
        }
        public List<WithdrawSlipDTO>? getAllWithdrawSlip()
        {
            return _withdrawSlipDAO.getAllWithdrawSlip();
        }
        public List<WithdrawSlipDTO>? getWithdrawSlipById(DateOnly date)
        {
            return _withdrawSlipDAO.getWithdrawSlipByDate(date);
        }
    }
}
