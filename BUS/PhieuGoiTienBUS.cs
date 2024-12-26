using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BUS
{
    public class PhieuGoiTienBUS
    {
        private PhieuGoiTienDAO phieuGoiTienDAO;
        private LoaiTietKiem loaiTietKiemDAO;

        public PhieuGoiTienBUS()
        {
            phieuGoiTienDAO = new PhieuGoiTienDAO();
            loaiTietKiemDAO = new LoaiTietKiem();
        }
        public List<PhieuGoiTien> GetPhieuGoiTien()
        {
            return phieuGoiTienDAO.GetAllPhieuGoiTienWithKhachHang();
        }
        public bool UpdatePhieuGoiTien(PhieuGoiTien phieuGoiTien)
        {
            phieuGoiTien.LaiSuatApDung = Math.Round(phieuGoiTien.LaiSuatApDung, 2);
            phieuGoiTien.LaiSuatPhatSinh = Math.Round(phieuGoiTien.LaiSuatPhatSinh, 2);
            phieuGoiTien.TongTienGoc = Math.Round(phieuGoiTien.TongTienGoc, 2);
            phieuGoiTien.TongTienLaiPhatSinh = Math.Round(phieuGoiTien.TongTienLaiPhatSinh, 2);
            return phieuGoiTienDAO.UpdatePhieuGoiTien(phieuGoiTien);
        }
        public List<PhieuGoiTien> SearchPhieuGoiTien(string searchText)
        {
            var dao = new PhieuGoiTienDAO();
            return dao.SearchPhieuGoiTien(searchText);
        }
        public bool ThemPhieuGoiTien(PhieuGoiTien phieu)
        {
            return PhieuGoiTienDAO.ThemPhieuGoiTien(phieu);
        }
    }
}
