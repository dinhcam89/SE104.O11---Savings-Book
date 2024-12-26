using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BUS
{
    public class HienThiChiTietRutTienBUS
    {
        private DAO.HienThiChiTietRutTienDAO hienthichitietrut = new DAO.HienThiChiTietRutTienDAO();

        public List<DTO.ChiTietRutTien> GetAllChiTietRutTien()
        {
            return hienthichitietrut.GetAll();
        }

        public DTO.ChiTietRutTien GetChiTietGuiTienByMaPhieu(string maPhieu)
        {
            return hienthichitietrut.GetByMaPhieu(maPhieu);
        }

        public List<DTO.ChiTietRutTien> GetTenKhachHang()
        {
            return hienthichitietrut.GetTenKhachHang();
        }
        public List<DTO.ChiTietRutTien> GetNgay(DateTime startDate, DateTime endDate)
        {
            return hienthichitietrut.GetNgay(startDate, endDate);
        }
    }
}
