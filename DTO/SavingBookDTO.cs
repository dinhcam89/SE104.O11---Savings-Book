using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SavingBookDTO
    {
        #region Properties
        public string SavingsBookId { get; set; }
        public CustomerDTO Customer { get; set; }
        public string AccountType { get; set; }
        public bool IsClosed { get; set; }
        #endregion

        #region Constructors
        public SavingBookDTO() 
        {
            SavingsBookId = "";
            Customer = new CustomerDTO();
            AccountType = "";
            IsClosed = false;
        }

        public SavingBookDTO(string savingsBookId, CustomerDTO customer, string accountType, string Address, DateTime openDate, bool isClosed)
        {
            SavingsBookId = savingsBookId;
            Customer = customer;
            AccountType = accountType;
            IsClosed = isClosed;
        }
        #endregion
    }
}
