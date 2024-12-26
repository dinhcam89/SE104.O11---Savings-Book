using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class KhachHangBUS
    {
        private KhachHangDAO _khachHangDAO;
        public KhachHangBUS()
        {
            _khachHangDAO = new KhachHangDAO();
        }
        public List<KhachHang> getListKhachHang()
        {
            return _khachHangDAO.getAllKhachHang();
        }
        public KhachHang? getKhachHangById(string soTaiKhoanThanhToan)
        {
            return _khachHangDAO.getKhachHangById(soTaiKhoanThanhToan);
        }
    }
}
