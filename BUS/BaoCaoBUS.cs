using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BUS
{
    public class BaoCaoBUS
    {
        private BaoCaoDAO baoCaoDAO = new BaoCaoDAO();
        public List<BaoCaoGiaoDich> LayDanhSachGiaoDich(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            return baoCaoDAO.LayDanhSachGiaoDich(ngayBatDau, ngayKetThuc);
        }
    }
}
