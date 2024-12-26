using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoaiTietKiem
    {
        #region Properties
        public string MaLoaiTietKiem { get; set; }
        public int KyHan { get; set; }
        public double LaiSuat { get; set; }
        public int SoNgayToiThieuDuocRutTien { get; set; }
        public string QuyDinhSoTienRut { get; set; }
        #endregion

        #region Constructors
        public LoaiTietKiem() { }
        public LoaiTietKiem(string maloaitk, int kyhan, double laisuat, int songaytoithieuduocruttien, string quydinhsotienrut)
        {
            MaLoaiTietKiem = maloaitk;
            KyHan = kyhan;
            LaiSuat = laisuat;
            SoNgayToiThieuDuocRutTien = songaytoithieuduocruttien;
            QuyDinhSoTienRut = quydinhsotienrut;
        }
        #endregion
    }
}
