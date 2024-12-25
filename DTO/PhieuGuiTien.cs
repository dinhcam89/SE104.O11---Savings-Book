using System;

namespace DTO
{
    public class PhieuGoiTien
    {
        public string SoTaiKhoanTienGoi { get; set; }       // Số tài khoản tiền gửi (IDENTITY - String 10 chữ số)
        public string SoTaiKhoanThanhToan { get; set; }    // Số tài khoản thanh toán (String 10 chữ số)
        public string MaLoaiTietKiem { get; set; }            // Mã loại tiết kiệm
        public double LaiSuatApDung { get; set; }          // Lãi suất áp dụng
        public double LaiSuatPhatSinh { get; set; }        // Lãi suất phát sinh
        public DateTime NgayGoi { get; set; }              // Ngày gửi
        public DateTime NgayDaoHanKeTiep { get; set; }     // Ngày đáo hạn
        public double TongTienGoc { get; set; }            // Tổng tiền gốc
        public double TongTienLaiPhatSinh { get; set; }    // Tổng tiền lãi phát sinh
        public int HinhThucGiaHan { get; set; }            // Hình thức gia hạn

        public PhieuGoiTien() { }

        public PhieuGoiTien(string soTaiKhoanThanhToan, string maLoaiTietKiem, double laiSuatApDung, double laiSuatPhatSinh,
                               DateTime ngayGoi, DateTime ngayDaoHanKeTiep, double tongTienGoc, double tongTienLaiPhatSinh, int hinhThucGiaHan)
        {
            SoTaiKhoanTienGoi = soTaiKhoanThanhToan;  // Gán Số tài khoản tiền gửi từ Số tài khoản thanh toán
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
