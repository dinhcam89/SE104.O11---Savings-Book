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
        public string TenKhachHang { get; set; }
        public DateOnly NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string CCCD { get; set; }
        public double SoDuHienCo { get; set; }
        #endregion

        #region Constructors
        public KhachHang() { }
        public KhachHang(string sotaikhoanthanhtoan, string tenkh, DateOnly ngaysinh, string diachi, string sdt, string socccd, double sodu)
        {
            SoTaiKhoanThanhToan = sotaikhoanthanhtoan;
            TenKhachHang = tenkh;
            NgaySinh = ngaysinh;
            DiaChi = diachi;
            SoDienThoai = sdt;
            CCCD = socccd;
            SoDuHienCo = sodu;
        }
        #endregion
    }
}
