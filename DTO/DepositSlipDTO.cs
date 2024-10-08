using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DepositSlipDTO
    {
        #region Properties
        public string DepositSlipId { get; set; }
        public string SavingBookId { get; set; }
        public string CustomerName { get; set; }
        public DateOnly DepositDate { get; set; }
        public double DepositAmount { get; set; }
        #endregion

        #region Constructors
        public DepositSlipDTO() { }
        public DepositSlipDTO(string savingBookId, string customerName, DateOnly depositDate, double depositAmount)
        {
            SavingBookId = savingBookId;
            CustomerName = customerName;
            DepositDate = depositDate;
            DepositAmount = depositAmount;
        }
        #endregion
    }
}
