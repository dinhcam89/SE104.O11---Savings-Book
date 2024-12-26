using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuGoiTien
    {
        public string SoTaiKhoanTienGoi { get; set; }
        public string SoTaiKhoanThanhToan { get; set; }
        public string TenKhachHang { get; set; }
        public string MaLoaiTietKiem { get; set; }
        public double LaiSuatApDung { get; set; }
        public double LaiSuatPhatSinh { get; set; }
        public DateTime NgayGoi { get; set; }
        public DateTime NgayDaoHanKeTiep { get; set; }
        public double TongTienGoc { get; set; }
        public double TongTienLaiPhatSinh { get; set; }
        public int HinhThucGiaHan { get; set; }
        public PhieuGoiTien() { }

        // Constructor
        public PhieuGoiTien(string soTaiKhoanTienGoi, string soTaiKhoanThanhToan, string tenKH, string maLoaiTietKiem, double laiSuatApDung, double laiSuatPhatSinh,
                            DateTime ngayGoi, DateTime ngayDaoHanKeTiep, double tongTienGoc, double tongTienLaiPhatSinh, int hinhThucGiaHan)
        {
            SoTaiKhoanTienGoi = soTaiKhoanTienGoi;
            SoTaiKhoanThanhToan = soTaiKhoanThanhToan;
            TenKhachHang = tenKH;
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
