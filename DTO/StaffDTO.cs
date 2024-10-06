using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class StaffDTO
    {
        #region Properties
        public string StaffId { get; set; }
        public string StaffName { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public string EmailAddress { get; set; }
        #endregion

        #region Constructors
        public StaffDTO() { }
        public StaffDTO(string staffId, string staffName, string department, string position, string emailAddress)
        {
            StaffId = staffId;
            StaffName = staffName;
            Department = department;
            Position = position;
            EmailAddress = emailAddress;
        }
        #endregion
    }
}
