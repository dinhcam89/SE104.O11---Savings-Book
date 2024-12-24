using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class KhachHangDAO
    {
        private DatabaseConnection dbConnection;
        public KhachHangDAO()
        {
            dbConnection = new DatabaseConnection();
        }
    }
}
