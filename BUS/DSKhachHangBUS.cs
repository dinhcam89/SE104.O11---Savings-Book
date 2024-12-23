using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class DSKhachHangBUS
    {
        private DSKhachHangDAO dsKhachHangDAO = new DSKhachHangDAO();
        public List<KhachHang> GetAllCustomers()
        {
            return dsKhachHangDAO.GetAllCustomers();
        }
        public int GetSavingsCount(string maKhachHang)
        {
            return dsKhachHangDAO.GetSavingsCount(maKhachHang);
        }
        public List<KhachHang> SearchKhachHang(string searchText)
        {
            return dsKhachHangDAO.SearchKhachHang(searchText);
        }
    }
}
