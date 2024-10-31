﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BUS
{
    public class MonthlySavingBookReportBUS
    {
        private MonthlySavingBookReportDAO monthlySavingBookReportDAO = new();
        public MonthlySavingBookReportBUS()
        {
            monthlySavingBookReportDAO = new MonthlySavingBookReportDAO();
        }
        public List<DTO.MonthlySavingBookReportDTO>? getMonthlySavingBookReportByMonthAndBookType(DateTime date, int bookTypeId)
        {
            return monthlySavingBookReportDAO.getByMonthAndBookType(date, bookTypeId);
        }
        public DataTable? getTotalMonthlySavingBookReport(DateTime date, int bookTypeId)
        {
            return monthlySavingBookReportDAO.getTotalReport(date, bookTypeId);
        }
    }
}
