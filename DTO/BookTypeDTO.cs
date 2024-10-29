using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BookTypeDTO
    {
        #region Properties
        public int  MaSo { get; set; }
        public int ThoiHan { get; set; }
        public double LaiSuatNam { get; set; }
        public double SoTienBanDauToiThieu { get; set; }
        public double SoTienGoiThemToiThieu { get; set; }
        public int ThoiGianGoiThemToiThieu { get; set; }
        #endregion

        #region Constructors
        public BookTypeDTO() 
        {
            MaSo = 0;
            ThoiHan = 0;
            LaiSuatNam = 0;
            SoTienBanDauToiThieu = 0;
            SoTienGoiThemToiThieu = 0;
            ThoiGianGoiThemToiThieu = 0;
        }
        public BookTypeDTO(int maSo, int thoiHan, float laiSuatNam, float soTienBanDauToiThieu, float soTienGoiThemToiThieu, int thoiGianGoiThemToiThieu)
        {
            MaSo = maSo;
            ThoiHan = thoiHan;
            LaiSuatNam = laiSuatNam;
            SoTienBanDauToiThieu = soTienBanDauToiThieu;
            SoTienGoiThemToiThieu = soTienGoiThemToiThieu;
            ThoiGianGoiThemToiThieu = thoiGianGoiThemToiThieu;
        }
        #endregion
    }
}
