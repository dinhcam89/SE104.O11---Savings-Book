using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BUS
{
    public class ChiTietGuiTienBUS
    {
        private readonly ChiTietGuiTienDAO ChiTietGuiTienDAO = new ChiTietGuiTienDAO();

        public string GuiThemTien(string soTaiKhoanTienGoi, float soTienGuiThem, DateTime ngayGiaoDich)
        {
            // Kiểm tra số tiền gửi thêm có hợp lệ
            if (soTienGuiThem < 100000)
                return "Số tiền gửi thêm tối thiểu là 100,000 đồng.";

            // Lấy ngày đáo hạn kế tiếp từ DAO
            DateTime ngayDaoHanKeTiep = ChiTietGuiTienDAO.GetNgayDaoHanKeTiep(soTaiKhoanTienGoi);

            if (ngayGiaoDich.Date != ngayDaoHanKeTiep.Date)
            {
                return $"Chỉ được gửi thêm tiền vào đúng ngày đáo hạn kế tiếp ({ngayDaoHanKeTiep:dd/MM/yyyy}).";
            }


            // Cập nhật tổng tiền gốc trong cơ sở dữ liệu
            bool isUpdated = ChiTietGuiTienDAO.UpdateTongTienGoc(soTaiKhoanTienGoi, soTienGuiThem);


            if (isUpdated)
            {
                ChiTietGuiTien chiTietGuiTien = new ChiTietGuiTien
                {
                    SoTaiKhoanTienGoi = soTaiKhoanTienGoi,
                    SoTienGui = soTienGuiThem,
                    NgayGui = ngayGiaoDich
                };

                // Thêm thông tin giao dịch chi tiết
                bool isInserted = ChiTietGuiTienDAO.InsertChiTietGuiTien(chiTietGuiTien);
                if (isInserted)
                    return "Gửi thêm tiền thành công!";
                else
                    return "Ghi giao dịch thất bại.";
            }
            else
            {
                return "Gửi thêm tiền thất bại. Vui lòng thử lại.";
            }

        }
    }
}
