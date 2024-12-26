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

        public List<DTO.ChiTietRutTien> GetChiTietRutTienByMaPhieu(string maPhieu)
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

        public float GetTongTien(string maPhieu)
        {
            var phieuGoiTienList = hienthichitietrut.GetTongTienGoc(maPhieu);
            if (phieuGoiTienList != null && phieuGoiTienList.Count > 0)
            {
                return phieuGoiTienList.First().TongTienGoc;
            }
            return 0; // Nếu không tìm thấy dữ liệu
        }
    }
}
