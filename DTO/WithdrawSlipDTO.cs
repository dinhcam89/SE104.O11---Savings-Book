using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class WithdrawSlipDTO
    {
        #region Properties
        public int MaSo { get; set; }
        public int MaSoSoTietKiem { get; set; }
        public string TenKhachHang { get; set; }
        public DateOnly NgayRut { get; set; }
        public double SoTienRut { get; set; }
        #endregion

        #region Constructors
        public WithdrawSlipDTO() {
            MaSo = 0;
            MaSoSoTietKiem = 0;
            TenKhachHang = "";
            NgayRut = new DateOnly();
            SoTienRut = 0;
        }
        public WithdrawSlipDTO(int maSo, string tenKhachHang, int maSoSoTietKiem, DateOnly ngayRut, double soTienRut)
        {
            MaSo = maSo;
            TenKhachHang = tenKhachHang;
            MaSoSoTietKiem = maSoSoTietKiem;
            NgayRut = ngayRut;
            SoTienRut = soTienRut;
        }
        #endregion
    }
}
