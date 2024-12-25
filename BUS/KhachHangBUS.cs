using DTO;
using DAO;
namespace BUS
{
    public class KhachHangBUS
    {
        private KhachHangDAO khachHangDAO = new KhachHangDAO();

        public bool ThemKhachHang(KhachHang khachHang)
        {
            if (string.IsNullOrEmpty(khachHang.TenKhachHang) || string.IsNullOrEmpty(khachHang.SoDienThoai))
            {
                throw new Exception("Tên khách hàng và số điện thoại không được để trống!");
            }

            if (khachHang.CCCD.Length != 12)
            {
                throw new Exception("CCCD phải có 12 ký tự!");
            }

            if (khachHang.SoDuHienCo < 0)
            {
                throw new Exception("Số dư hiện có không được nhỏ hơn 0!");
            }

            return khachHangDAO.ThemKhachHang(khachHang);
        }
    }
}