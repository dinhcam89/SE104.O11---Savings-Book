using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MonthlySavingBookReportDTO
    {
        #region Properties
        public DateTime Ngay { get; set; }
        public int SoSoMo { get; set; }
        public int SoSoDong { get; set; }
        public int ChenhLech { get; set; }
        #endregion

        #region Constructors
        public MonthlySavingBookReportDTO()
        {
            Ngay = DateTime.Now;
            SoSoMo = 0;
            SoSoDong = 0;
            ChenhLech = 0;
        }
        public MonthlySavingBookReportDTO(DateTime ngay, int soSoMo, int soSoDong, int chenhLech)
        {
            Ngay = ngay;
            SoSoMo = soSoMo;
            SoSoDong = soSoDong;
            ChenhLech = chenhLech;
        }
        #endregion
    }
}
