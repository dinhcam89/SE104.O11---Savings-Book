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
    }
}
