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
    }
}
