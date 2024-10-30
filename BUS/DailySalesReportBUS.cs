using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class DailySalesReportBUS
    {
        private DailySalesReportDAO _dailySalesReportDAO;
        public DailySalesReportBUS()
        {
            _dailySalesReportDAO = new DailySalesReportDAO();
        }
        public List<DailySalesReportDTO>? getDailySalesReportByDate(DateTime date)
        {
            return _dailySalesReportDAO.getDailySalesReportByDate(date);
        }
    }
}
