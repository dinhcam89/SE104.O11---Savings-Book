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
        public string SoTaiKhoanTienGui { get; set; }
        public DateTime NgayGui { get; set; }
        public double SoTienGui { get; set; }
        public string? TenKhachHang { get; set; } // Thuộc tính tạm thời
        #endregion

        #region Constructors
        public ChiTietGuiTien() { }
        public ChiTietGuiTien(string machitietguitien, string sotaikhoantiengui, DateTime ngaygui, double sotiengui)
        {
            MaChiTietGuiTien = machitietguitien;
            SoTaiKhoanTienGui = sotaikhoantiengui;
            NgayGui = ngaygui;
            SoTienGui = sotiengui;
        }
        #endregion
    }
}
