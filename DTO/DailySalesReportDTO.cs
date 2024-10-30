using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DailySalesReportDTO
    {
        #region Properties
        public int LoaiTietKiem { get; set; }
        public double TongThu { get; set; }
        public double TongChi { get; set; }
        public double ChenhLech { get; set; }
        #endregion

        #region Constructors
        public DailySalesReportDTO()
        {
            LoaiTietKiem = 0;
            TongThu = 0;
            TongChi = 0;
            ChenhLech = 0;
        }
        public DailySalesReportDTO(int loaiTietKiem, double tongThu, double tongChi, double chenhLech)
        {
            LoaiTietKiem = loaiTietKiem;
            TongThu = tongThu;
            TongChi = tongChi;
            ChenhLech = chenhLech;
        }
        #endregion
    }
}
