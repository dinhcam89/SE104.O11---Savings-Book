using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return phieuGoiTienDAO.getAllPhieuGoiTien();
        }
        public bool UpdatePhieuGoiTien(PhieuGoiTien phieuGoiTien)
        {
            return phieuGoiTienDAO.updatePhieuGoiTien(phieuGoiTien);
        }
    }
}
