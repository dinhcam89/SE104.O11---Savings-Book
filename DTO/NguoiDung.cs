using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NguoiDung
    {
        public string TaiKhoan { get; set; }
        public string TenNguoiDung { get; set; }
        public string MatKhau { get; set; }

        // Constructor
        public NguoiDung(string taiKhoan, string tenNguoiDung, string matKhau)
        {
            TaiKhoan = taiKhoan;
            TenNguoiDung = tenNguoiDung;
            MatKhau = matKhau;
        }
    }
}
