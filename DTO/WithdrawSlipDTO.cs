using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class WithdrawSlipDTO
    {
        #region Properties
        public string SavingBookId { get; set; }
        public string SlipId { get; set; }
        public string CustomerName { get; set; }
        public DateOnly WithdrawDate { get; set; }
        public double WithdrawAmount { get; set; }
        #endregion

        #region Constructors
        public WithdrawSlipDTO() { }
        public WithdrawSlipDTO(string savingBookId, string customerName, DateOnly withdrawDate, double withdrawAmount)
        {
            SavingBookId = savingBookId;
            CustomerName = customerName;
            WithdrawDate = withdrawDate;
            WithdrawAmount = withdrawAmount;
        }
        #endregion
    }
}
