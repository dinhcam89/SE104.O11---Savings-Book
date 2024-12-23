using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoaiTietKiem
    {
        public string MaLoaiTietKiem { get; set; }
        public int KyHan { get; set; }
        public float LaiSuat { get; set; }
        public int SoNgayToiThieuDuocRutTien { get; set; }
        public string QuyDinhSoTienRut { get; set; }
        public LoaiTietKiem() { }

        // Constructor
        public LoaiTietKiem(string maLoaiTietKiem, int kyHan, float laiSuat, int soNgayToiThieuDuocRutTien, string quyDinhSoTienRut)
        {
            MaLoaiTietKiem = maLoaiTietKiem;
            KyHan = kyHan;
            LaiSuat = laiSuat;
            SoNgayToiThieuDuocRutTien = soNgayToiThieuDuocRutTien;
            QuyDinhSoTienRut = quyDinhSoTienRut;
        }
    }
}
