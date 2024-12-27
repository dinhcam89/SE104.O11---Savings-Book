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
            List<PhieuGoiTien> listPhieuGoiTien = phieuGoiTienDAO.GetAllPhieuGoiTienWithKhachHang();
            foreach (PhieuGoiTien phieuGoiTien in listPhieuGoiTien)
            {
                phieuGoiTien.LaiSuatApDung = Math.Round(phieuGoiTien.LaiSuatApDung, 2);
                phieuGoiTien.LaiSuatPhatSinh = Math.Round(phieuGoiTien.LaiSuatPhatSinh, 2);
                phieuGoiTien.TongTienGoc = Math.Round(phieuGoiTien.TongTienGoc, 2);
                phieuGoiTien.TongTienLaiPhatSinh = Math.Round(phieuGoiTien.TongTienLaiPhatSinh, 2);
            }
            return listPhieuGoiTien;
        }
        public bool UpdatePhieuGoiTien(PhieuGoiTien phieuGoiTien)
        {
            //phieuGoiTien.LaiSuatApDung = Math.Round(phieuGoiTien.LaiSuatApDung, 2);
            //phieuGoiTien.LaiSuatPhatSinh = Math.Round(phieuGoiTien.LaiSuatPhatSinh, 2);
            //phieuGoiTien.TongTienGoc = Math.Round(phieuGoiTien.TongTienGoc, 2);
            //phieuGoiTien.TongTienLaiPhatSinh = Math.Round(phieuGoiTien.TongTienLaiPhatSinh, 2);
            return phieuGoiTienDAO.UpdatePhieuGoiTien(phieuGoiTien);
        }
        public List<PhieuGoiTien> SearchPhieuGoiTien(string searchText)
        {
            var dao = new PhieuGoiTienDAO();
            return dao.SearchPhieuGoiTien(searchText);
        }
        public bool ThemPhieuGoiTien(PhieuGoiTien phieu)
        {
            phieu.LaiSuatApDung = Math.Round(phieu.LaiSuatApDung, 2);
            phieu.LaiSuatPhatSinh = Math.Round(phieu.LaiSuatPhatSinh, 2);
            return phieuGoiTienDAO.ThemPhieuGoiTien(phieu);
        }
        public PhieuGoiTien? GetPhieuGoiTienBySoTaiKhoanTienGoi(string soTaiKhoanTienGoi)
        {
            PhieuGoiTien phieuGoiTien = new PhieuGoiTien();
            phieuGoiTien = phieuGoiTienDAO.GetPhieuGoiTienBySoTaiKhoanTienGoi(soTaiKhoanTienGoi);
            phieuGoiTien.LaiSuatApDung = Math.Round(phieuGoiTien.LaiSuatApDung, 2);
            phieuGoiTien.LaiSuatPhatSinh = Math.Round(phieuGoiTien.LaiSuatPhatSinh, 2);
            phieuGoiTien.TongTienGoc = Math.Round(phieuGoiTien.TongTienGoc, 2);
            phieuGoiTien.TongTienLaiPhatSinh = Math.Round(phieuGoiTien.TongTienLaiPhatSinh, 2);
            return phieuGoiTien;
        }
    }
}
