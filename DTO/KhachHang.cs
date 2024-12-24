using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHang
    {
        public string SoTaiKhoanThanhToan { get; set; }
        public string TenKhachHang { get; set; }
        public string CCCD { get; set; }
        public string SoDienThoai { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public float SoDuHienCo { get; set; }
        public KhachHang() { }

        // Constructor
        public KhachHang(string soTaiKhoanThanhToan, string tenKhachHang, string cccd, string soDienThoai, DateTime ngaySinh, string diaChi, float soDuHienCo)
        {
            SoTaiKhoanThanhToan = soTaiKhoanThanhToan;
            TenKhachHang = tenKhachHang;
            CCCD = cccd;
            SoDienThoai = soDienThoai;
            NgaySinh = ngaySinh;
            DiaChi = diaChi;
            SoDuHienCo = soDuHienCo;
        }
    }
}
