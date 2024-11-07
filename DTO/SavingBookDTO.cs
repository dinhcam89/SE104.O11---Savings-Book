using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SavingBookDTO
    {
        public int MaSo { get; set; }
        public int MSKhachHang { get; set; }
        public int MSLoaiTietKiem { get; set; }
        public string DiaChi { get; set; }
        public float SoTienGoi { get; set; }
        public DateTime NgayMoSo { get; set; }
        public DateTime NgayDongSo { get; set; }
        public string TenKhachHang { get; set; }
        public string CCCD_CMND { get; set; }
        public string SoDienThoai { get; set; }
        public string KyHan { get; set; }
    }
}
