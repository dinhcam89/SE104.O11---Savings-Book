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
        public int MaChiTietRutTien { get; set; }
        public int MaPhieuGuiTien { get; set; }
        public DateTime NgayRut { get; set; }
        public double SoTienRut { get; set; }
        #endregion

        #region Constructors
        public ChiTietRutTien() { }
        public ChiTietRutTien(int machitietruttien, int maphieuguitien, DateTime ngayrut, double sotienrut)
        {
            MaChiTietRutTien = machitietruttien;
            MaPhieuGuiTien = maphieuguitien;
            NgayRut = ngayrut;
            SoTienRut = sotienrut;
        }
        #endregion
    }
}
