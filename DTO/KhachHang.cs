using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
<<<<<<< HEAD
    public class KhachHang
    {
        #region Properties
        public string MaKH { get; set; }
        public string HoTenKH { get; set; }
        public DateOnly NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public string SoCCCD { get; set; }
        public double SoDuHienCo { get; set; }
        #endregion

        #region Constructors
        public KhachHang() { }
        public KhachHang(string makh, string tenkh, DateOnly ngaysinh, string diachi, string sdt, string socccd, double sodu)
        {
            MaKH = makh;
            HoTenKH = tenkh;
            NgaySinh = ngaysinh;
            DiaChi = diachi;
            SDT = sdt;
            SoCCCD = socccd;
            SoDuHienCo = sodu;
        }
        #endregion
=======
    public class KhachHangDTO
    {
        public int MaKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public string SoDienThoai { get; set; }
        public string CCCD { get; set; }
        public string DiaChi { get; set; }
        public DateTime? NgaySinh { get; set; }
        public int SoTaiKhoanThanhToan { get; set; }
        public float SoDuHienCo { get; set; }
        public KhachHangDTO() { }

        public KhachHangDTO(int maKH, string tenKH, string sdt, string cccd, string diaChi, DateTime? ngaySinh, int stkThanhToan, float soDuHienCo)
        {
            MaKhachHang = maKH;
            TenKhachHang = tenKH;
            SoDienThoai = sdt;
            CCCD = cccd;
            DiaChi = diaChi;
            NgaySinh = ngaySinh;
            SoTaiKhoanThanhToan = stkThanhToan;
            SoDuHienCo = soDuHienCo;
        }
>>>>>>> b9113d9 (Initial commit)
    }
}
