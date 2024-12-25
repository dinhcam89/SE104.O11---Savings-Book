using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietGuiTien
    {
        #region Properties
        public string MaChiTietGuiTien { get; set; }
        public string SoTaiKhoanTienGoi { get; set; }
        public DateTime NgayGui { get; set; }
        public double SoTienGui { get; set; }
        #endregion

        #region Constructors
        public ChiTietGuiTien() { }
        public ChiTietGuiTien(string machitietguitien, string sotaikhoantiengoi, DateTime ngaygui, double sotiengui)
        {
            MaChiTietGuiTien = machitietguitien;
            SoTaiKhoanTienGoi = sotaikhoantiengoi;
            NgayGui = ngaygui;
            SoTienGui = sotiengui;
        }
        #endregion
    }
}
