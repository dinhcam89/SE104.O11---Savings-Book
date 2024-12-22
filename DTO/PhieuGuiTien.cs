using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
<<<<<<< HEAD
    public class PhieuGuiTien
    {
        #region Properties
        public int MaPhieuGuiTien { get; set; }
        public int MaKH { get; set; }
        public double LaiSuatApDung { get; set; }
        public double LaiSuatPhatSinh { get; set; }
        public DateOnly NgayDaoHanKeTiep { get; set; }
        public DateOnly NgayGui { get; set; }
        public double TongTienGoc { get; set; }
        public double TongTienLaiPhatSinh { get; set; }
        public int HinhThucGiaHan { get; set; }
        #endregion

        #region Constructors
        public PhieuGuiTien() { }
        public PhieuGuiTien(int maphieu, int makh, double laisuatapdung, double laisuatphatsinh, DateOnly ngaydaohanketiep, 
            DateOnly ngaygui, double tongtiengoc, double tongtienlaiphatsinh, int hinhthucgiahan)
        {
            MaPhieuGuiTien = maphieu;
            MaKH = makh;
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
=======
    public class PhieuGoiTienDTO
    {
        public int SoTaiKhoanTienGoi { get; set; }       // Mã phiếu gửi tiền (IDENTITY)
        public int SoTaiKhoanThanhToan { get; set; }    // Mã khách hàng tham chiếu (phải giống SoTaiKhoanTienGoi)
        public int MaLoaiTietKiem { get; set; }         // Mã loại tiết kiệm
        public double LaiSuatApDung { get; set; }       // Lãi suất áp dụng
        public double LaiSuatPhatSinh { get; set; }     // Lãi suất phát sinh
        public DateTime NgayGoi { get; set; }           // Ngày gửi
        public DateTime NgayDaoHanKeTiep { get; set; }  // Ngày đáo hạn
        public double TongTienGoc { get; set; }         // Tổng tiền gốc
        public double TongTienLaiPhatSinh { get; set; } // Tổng tiền lãi phát sinh
        public int HinhThucGiaHan { get; set; }         // Hình thức gia hạn

        public PhieuGoiTienDTO() { }

        public PhieuGoiTienDTO(int soTaiKhoanThanhToan, int maLoaiTietKiem, double laiSuatApDung, double laiSuatPhatSinh,
                               DateTime ngayGoi, DateTime ngayDaoHanKeTiep, double tongTienGoc, double tongTienLaiPhatSinh, int hinhThucGiaHan)
        {
            SoTaiKhoanTienGoi = soTaiKhoanThanhToan;  // SoTaiKhoanTienGoi được gán từ SoTaiKhoanThanhToan
            SoTaiKhoanThanhToan = soTaiKhoanThanhToan;
            MaLoaiTietKiem = maLoaiTietKiem;
            LaiSuatApDung = laiSuatApDung;
            LaiSuatPhatSinh = laiSuatPhatSinh;
            NgayGoi = ngayGoi;
            NgayDaoHanKeTiep = ngayDaoHanKeTiep;
            TongTienGoc = tongTienGoc;
            TongTienLaiPhatSinh = tongTienLaiPhatSinh;
            HinhThucGiaHan = hinhThucGiaHan;
        }
    }
}


>>>>>>> b9113d9 (Initial commit)
