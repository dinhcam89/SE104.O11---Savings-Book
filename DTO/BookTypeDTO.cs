using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BookTypeDTO
    {
        #region Properties
        public string BookTypeId { get; set; }
        public string BookTerm { get; set; }
        public double InterestRate { get; set; }
        public string MinimumBalance { get; set; }
        public string MinimumDepositBalance { get; set; }
        #endregion

        #region Constructors
        public BookTypeDTO() { }
        public BookTypeDTO(string bookTypeId, string bookTerm, double interestRate, string minimumBalance, string minimumDepositBalance)
        {
            BookTypeId = bookTypeId;
            BookTerm = bookTerm;
            InterestRate = interestRate;
            MinimumBalance = minimumBalance;
            MinimumDepositBalance = minimumDepositBalance;
        }
        #endregion
    }
}
