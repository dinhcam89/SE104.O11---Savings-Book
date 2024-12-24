using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHang
    {
        #region Properties
        public string SoTaiKhoanThanhToan { get; set; }
        public string HoTenKH { get; set; }
        public DateOnly NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public string SoCCCD { get; set; }
        public double SoDuHienCo { get; set; }
        #endregion

        #region Constructors
        public KhachHang() { }
        public KhachHang(string sotaikhoanthanhtoan, string tenkh, DateOnly ngaysinh, string diachi, string sdt, string socccd, double sodu)
        {
            SoTaiKhoanThanhToan = sotaikhoanthanhtoan;
            HoTenKH = tenkh;
            NgaySinh = ngaysinh;
            DiaChi = diachi;
            SDT = sdt;
            SoCCCD = socccd;
            SoDuHienCo = sodu;
        }
        #endregion
    }
}
