using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BUS
{
    public class BieuDoBUS
    {
        private BieuDoDAO bieuDoDAO = new BieuDoDAO();

        // Hàm lấy tổng số khách hàng
        public int GetTotalCustomers()
        {
            return bieuDoDAO.GetTotalCustomers();
        }

        // Hàm lấy tổng số phiếu gửi tiền
        public int GetTotalSavingsAccounts()
        {
            return bieuDoDAO.GetTotalSavingsAccounts();
        }

        // Hàm lấy tổng số tiền gửi
        public decimal GetTotalSavingsAmount()
        {
            return bieuDoDAO.GetTotalSavingsAmount();
        }

        // Hàm lấy dữ liệu tổng quan theo tháng
        public Dictionary<string, decimal> GetSavingsByMonth()
        {
            return bieuDoDAO.GetSavingsByMonth();
        }
    }
}
