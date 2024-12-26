using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BUS
{
    public class HienThiChiTietGuiTienBUS
    {
        private DAO.HienThiChiTietGuiTienDAO hienthichitietgui = new DAO.HienThiChiTietGuiTienDAO();

        public List<DTO.ChiTietGuiTien> GetAllChiTietGuiTien()
        {
            return hienthichitietgui.GetAll();
        }

        public List<DTO.ChiTietGuiTien> GetChiTietGuiTienByMaPhieu(string maPhieu)
        {
            return hienthichitietgui.GetByMaPhieu(maPhieu);
        }
        public List<DTO.ChiTietGuiTien> GetTenKhachHang()
        {
            return hienthichitietgui.GetTenKhachHang();
        }
        public List<DTO.ChiTietGuiTien> GetNgay(DateTime startDate, DateTime endDate)
        {
            return hienthichitietgui.GetNgay(startDate, endDate);
        }
        /*public List<DTO.PhieuGoiTien> GetTongTien(string maPhieu)
        {
            return hienthichitietgui.GetTongTienGoc(maPhieu);
        }*/
        public double GetTongTien(string maPhieu)
        {
            var phieuGoiTienList = hienthichitietgui.GetTongTienGoc(maPhieu);
            if (phieuGoiTienList != null && phieuGoiTienList.Count > 0)
            {
                return phieuGoiTienList.First().TongTienGoc;
            }
            return 0; // Nếu không tìm thấy dữ liệu
        }
    }
}
