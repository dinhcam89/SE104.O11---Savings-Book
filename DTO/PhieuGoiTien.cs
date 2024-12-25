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
        public float LaiSuatApDung { get; set; }
        public float LaiSuatPhatSinh { get; set; }
        public DateTime NgayGoi { get; set; }
        public DateTime NgayDaoHanKeTiep { get; set; }
        public float TongTienGoc { get; set; }
        public float TongTienLaiPhatSinh { get; set; }
        public int HinhThucGiaHan { get; set; }
        public PhieuGoiTien() { }

        // Constructor
        public PhieuGoiTien(string soTaiKhoanTienGoi, string soTaiKhoanThanhToan, string tenKH, string maLoaiTietKiem, float laiSuatApDung, float laiSuatPhatSinh,
                            DateTime ngayGoi, DateTime ngayDaoHanKeTiep, float tongTienGoc, float tongTienLaiPhatSinh, int hinhThucGiaHan)
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
