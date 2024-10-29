using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DepositSlipDTO
    {
        #region Properties
        public int MaSo { get; set; }
        public string TenKhachHang { get; set; }
        public int MaSoSoTietKiem { get; set; }
        public DateOnly NgayGui { get; set; }
        public double SoTienGui { get; set; }
        #endregion

        #region Constructors
        public DepositSlipDTO() {
            MaSo = 0;
            TenKhachHang = "";
            MaSoSoTietKiem = 0;
            NgayGui = new DateOnly();
            SoTienGui = 0;
        }
        public DepositSlipDTO(int maSo, string tenKhachHang, int maSoSoTietKiem, DateOnly ngayGui, double soTienDui)
        {
            MaSo = maSo;
            TenKhachHang = tenKhachHang;
            MaSoSoTietKiem = maSoSoTietKiem;
            NgayGui = ngayGui;
            SoTienGui = soTienDui;
        }
        #endregion
    }
}
