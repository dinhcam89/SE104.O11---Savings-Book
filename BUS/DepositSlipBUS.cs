using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DAO;
using DTO;

namespace BUS
{
    public class DepositSlipBUS
    {
        private DepositSlipDAO _depositSlipDAO;
        public DepositSlipBUS()
        {
            _depositSlipDAO = new DepositSlipDAO();
        }
        public List<DepositSlipDTO>? getAllDepositSlip()
        {
            return _depositSlipDAO.getAllDepositSlip();
        }
        public List<DepositSlipDTO>? getDepositSlipById(DateOnly date)
        {
            return _depositSlipDAO.getDepositSlipByDate(date);
        }
    }
}
