using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class EmployeeDTO
    {
        #region Properties
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeePWD { get; set; }
        public string Position { get; set; }
        public string EmailAddress { get; set; }
        #endregion

        #region Constructors
        public EmployeeDTO() { }
        public EmployeeDTO(string staffId, string staffName, string department, string position, string emailAddress)
        {
            EmployeeID = staffId;
            EmployeeName = staffName;
            EmployeePWD = department;
            Position = position;
            EmailAddress = emailAddress;
        }
        #endregion
    }
}
