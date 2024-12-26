using System;
using System.Collections.Generic;
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
    }
}
