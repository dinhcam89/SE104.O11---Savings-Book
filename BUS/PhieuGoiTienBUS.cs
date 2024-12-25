using DAO;
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
        private PhieuGoiTienDAO PhieuGoiTienDAO = new PhieuGoiTienDAO();
        public List<PhieuGoiTien> GetAllPhieuGoiTien()
        {
            return PhieuGoiTienDAO.GetAllPhieuGoiTienWithKhachHang();
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
