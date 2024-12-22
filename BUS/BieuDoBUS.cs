﻿using System;
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
        public decimal GetTotalSavingsAccountsByTerm(int term)
        {
            return bieuDoDAO.GetTotalSavingsAccountsByTerm(term);
        }

        // Hàm lấy dữ liệu tổng quan theo tháng
        public Dictionary<string, Dictionary<int, decimal>> GetSavingsByMonthAndTerm(string kyHan)
        {
            return bieuDoDAO.GetSavingsByMonthAndTerm(kyHan);
        }
        public Dictionary<int, Dictionary<DateTime, decimal>> GetSavingsByDateAndTerm(DateTime selectedDate)
        {
            // Truy vấn cơ sở dữ liệu để đếm số lượng phiếu tiết kiệm theo kỳ hạn
            return bieuDoDAO.GetSavingsByDateAndTerm(selectedDate);
        }

    }
}
