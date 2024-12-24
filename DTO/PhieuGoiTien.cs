using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuGoiTien
    {
        #region Properties
        public string SoTaiKhoanTienGoi { get; set; }       // Mã phiếu gửi tiền (IDENTITY)
        public string SoTaiKhoanThanhToan { get; set; }    // Mã khách hàng tham chiếu (phải giống SoTaiKhoanTienGoi)
        public string MaLoaiTietKiem { get; set; }         // Mã loại tiết kiệm
        public double LaiSuatApDung { get; set; }       // Lãi suất áp dụng
        public double LaiSuatPhatSinh { get; set; }     // Lãi suất phát sinh
        public DateTime NgayGoi { get; set; }           // Ngày gửi
        public DateTime NgayDaoHanKeTiep { get; set; }  // Ngày đáo hạn
        public double TongTienGoc { get; set; }         // Tổng tiền gốc
        public double TongTienLaiPhatSinh { get; set; } // Tổng tiền lãi phát sinh
        public int HinhThucGiaHan { get; set; }         // Hình thức gia hạn
        #endregion

        #region Constructors
        public PhieuGoiTien() { }
        public PhieuGoiTien(string soTaiKhoanThanhToan, string maLoaiTietKiem, double laiSuatApDung, double laiSuatPhatSinh, DateTime ngayGoi, DateTime ngayDaoHanKeTiep, double tongTienGoc, double tongTienLaiPhatSinh, int hinhThucGiaHan)
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
        #endregion
    }
}
