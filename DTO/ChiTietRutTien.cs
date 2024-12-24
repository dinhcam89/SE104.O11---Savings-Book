using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietRutTien
    {
        #region Properties
        public string MaChiTietRutTien { get; set; }
        public string SoTaiKhoanTienGui { get; set; }
        public DateTime NgayRut { get; set; }
        public double SoTienRut { get; set; }
        #endregion

        #region Constructors
        public ChiTietRutTien() { }
        public ChiTietRutTien(string machitietruttien, string sotaikhoantiengui, DateTime ngayrut, double sotienrut)
        {
            MaChiTietRutTien = machitietruttien;
            SoTaiKhoanTienGui = sotaikhoantiengui;
            NgayRut = ngayrut;
            SoTienRut = sotienrut;
        }
        #endregion
    }
}
