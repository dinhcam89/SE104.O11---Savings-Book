using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietGoiTien
    {
        public string MaChiTietGoiTien { get; set; }
        public string SoTaiKhoanTienGoi { get; set; }
        public DateTime NgayGoi { get; set; }
        public float SoTienGoi { get; set; }
        public ChiTietGoiTien() { }

        // Constructor
        public ChiTietGoiTien(string maChiTietGoiTien, string soTaiKhoanTienGoi, DateTime ngayGoi, float soTienGoi)
        {
            MaChiTietGoiTien = maChiTietGoiTien;
            SoTaiKhoanTienGoi = soTaiKhoanTienGoi;
            NgayGoi = ngayGoi;
            SoTienGoi = soTienGoi;
        }
    }
}
