using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuGuiTien
    {
        #region Properties
        public int MaPhieuGuiTien { get; set; }
        public int MaKH { get; set; }
        public int MaLoaiTietKiem { get; set; } 
        public double LaiSuatApDung { get; set; }
        public double LaiSuatPhatSinh { get; set; }
        public DateTime NgayDaoHanKeTiep { get; set; }
        public DateTime NgayGui { get; set; }
        public double TongTienGoc { get; set; }
        public double TongTienLaiPhatSinh { get; set; }
        public int HinhThucGiaHan { get; set; }
        #endregion

        #region Constructors
        public PhieuGuiTien() { }
        public PhieuGuiTien(int maphieu, int makh,int maltk, double laisuatapdung, double laisuatphatsinh, DateTime ngaydaohanketiep,
            DateTime ngaygui, double tongtiengoc, double tongtienlaiphatsinh, int hinhthucgiahan)
        {
            MaPhieuGuiTien = maphieu;
            MaKH = makh;
            MaLoaiTietKiem = maltk;
            LaiSuatApDung = laisuatapdung;
            LaiSuatPhatSinh = laisuatphatsinh;
            NgayDaoHanKeTiep = ngaydaohanketiep;
            NgayGui = ngaygui;
            TongTienGoc = tongtiengoc;
            TongTienLaiPhatSinh = tongtienlaiphatsinh;
            HinhThucGiaHan = hinhthucgiahan;
        }
        #endregion
    }
}
