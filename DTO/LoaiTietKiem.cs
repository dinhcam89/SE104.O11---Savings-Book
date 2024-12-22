using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
<<<<<<< HEAD
    public class LoaiTietKiem
    {
        #region Properties
        public int MaLoaiTietKiem { get; set; }
        public int KyHan { get; set; }
        public double LaiSuat { get; set; }
        public int SoNgayToiThieuDuocRutTien { get; set; }
        public string QuyDinhSoTienRut { get; set; }
        #endregion

        #region Constructors
        public LoaiTietKiem() { }
        public LoaiTietKiem(int maloaitk, int kyhan, double laisuat, int songaytoithieuduocruttien, string quydinhsotienrut)
        {
            MaLoaiTietKiem = maloaitk;
            KyHan = kyhan;
            LaiSuat = laisuat;
            SoNgayToiThieuDuocRutTien = songaytoithieuduocruttien;
            QuyDinhSoTienRut = quydinhsotienrut;
        }
        #endregion
=======
    public class LoaiTietKiemDTO
    {
        public int MaLoaiTietKiem { get; set; }           // Mã loại tiết kiệm
        public int KyHan { get; set; }                   // Kỳ hạn (tháng)
        public float LaiSuat { get; set; }               // Lãi suất (%)
        public int SoNgayToiThieuDuocRutTien { get; set; } // Số ngày tối thiểu để được rút tiền
        public string QuiDinhSoTienRut { get; set; }     // Quy định số tiền được rút (<=, =, ...)

        public LoaiTietKiemDTO() { }

        public LoaiTietKiemDTO(int maLoaiTietKiem, int kyHan, float laiSuat, int soNgayToiThieuDuocRutTien, string quiDinhSoTienRut)
        {
            MaLoaiTietKiem = maLoaiTietKiem;
            KyHan = kyHan;
            LaiSuat = laiSuat;
            SoNgayToiThieuDuocRutTien = soNgayToiThieuDuocRutTien;
            QuiDinhSoTienRut = quiDinhSoTienRut;
        }
>>>>>>> b9113d9 (Initial commit)
    }
}
