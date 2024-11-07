using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CustomerDTO
    {
        #region Properties
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Identification { get; set; }
        #endregion

        #region Constructors
        public CustomerDTO() { }
        public CustomerDTO(string customerId, string customerName, DateOnly dateOfBirth, string address, string phoneNumber, string identification)
        {
            CustomerId = customerId;
            CustomerName = customerName;
            DateOfBirth = dateOfBirth;
            Address = address;
            PhoneNumber = phoneNumber;
            Identification = identification;
        }
        #endregion
    }
}
