using System;

namespace DTO
{
    public class KhachHang
    {
        public string SoTaiKhoanThanhToan { get; set; } // Thay cho MaKhachHang
        public string TenKhachHang { get; set; }
        public string SoDienThoai { get; set; }
        public string CCCD { get; set; }
        public string DiaChi { get; set; }
        public DateTime? NgaySinh { get; set; }
        public float SoDuHienCo { get; set; }

        public KhachHang() { }

        public KhachHang(string soTaiKhoanThanhToan, string tenKhachHang, string soDienThoai, string cccd, string diaChi, DateTime? ngaySinh, float soDuHienCo)
        {
            SoTaiKhoanThanhToan = soTaiKhoanThanhToan;
            TenKhachHang = tenKhachHang;
            SoDienThoai = soDienThoai;
            CCCD = cccd;
            DiaChi = diaChi;
            NgaySinh = ngaySinh;
            SoDuHienCo = soDuHienCo;
        }
    }
}
