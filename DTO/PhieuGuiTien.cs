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
        public string SoTaiKhoanGuiTien { get; set; }
        public string SoTaiKhoanThanhToan { get; set; }
        public string MaLoaiTietKiem { get; set; } 
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
        public PhieuGuiTien(string sotaikhoanguitien, string sotaikhoanthanhtoan,string maltk, double laisuatapdung, double laisuatphatsinh, DateTime ngaydaohanketiep,
            DateTime ngaygui, double tongtiengoc, double tongtienlaiphatsinh, int hinhthucgiahan)
        {
            SoTaiKhoanGuiTien = sotaikhoanguitien;
            SoTaiKhoanThanhToan = sotaikhoanthanhtoan;
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
