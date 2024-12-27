using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class KhachHangBUS
    {
        private KhachHangDAO khachHangDAO = new KhachHangDAO();

        public List<KhachHang> GetAllKhachHangWithPhieuGoiTienCount()
        {
            return khachHangDAO.GetAllKhachHangWithPhieuGoiTienCount();
        }
        public KhachHang? LayKhachHangTheoSoTaiKhoan(string soTaiKhoan)
        {
            return khachHangDAO.LayKhachHangTheoSoTaiKhoan(soTaiKhoan);
        }
        public bool ThemKhachHang(KhachHang khachHang)
        {
            return khachHangDAO.ThemKhachHang(khachHang);
        }
        public bool CapNhatKhachHang(KhachHang khachHang)
        {
            return khachHangDAO.CapNhatKhachHang(khachHang);
        }
    }
}
