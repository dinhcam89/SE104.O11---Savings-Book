using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    
    public class LoaiTietKiemBUS
    {
        private LoaiTietKiemDAO _loaiTietKiemDAO;
        public LoaiTietKiemBUS()
        {
            _loaiTietKiemDAO = new LoaiTietKiemDAO();
        }
        public List<LoaiTietKiem> getListLoaiTietKiem()
        {
            return _loaiTietKiemDAO.getAllLoaiTietKiem();
        }
        public LoaiTietKiem? getLoaiTietKiem(string maLoaiTK)
        {
            return _loaiTietKiemDAO.getLoaiTietKiem(maLoaiTK);
        }
        public LoaiTietKiem? getLoaiTietKiemById(string maLoaiTietKiem)
        {
            return _loaiTietKiemDAO.getLoaiTietKiemById(maLoaiTietKiem);
        }
        public bool updateLoaiTietKiem(LoaiTietKiem ltk)
        {
            return _loaiTietKiemDAO.updateLoaiTietKiem(ltk);
        }
        public bool deleteLoaiTietKiem(LoaiTietKiem ltk)
        {
            return _loaiTietKiemDAO.deleteLoaiTietKiem(ltk);
        }
        public bool postLoaiTietKiem(int kyHan, double laiSuat, int soNgayToiThieuDuocRutTien, string quyDinhTienRut)
        {
            return _loaiTietKiemDAO.insertLoaiTietKiem(
                kyHan, laiSuat , soNgayToiThieuDuocRutTien, quyDinhTienRut);
        }
    }
}
