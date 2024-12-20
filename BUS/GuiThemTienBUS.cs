using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BUS
{
    public class GuiThemTienBUS
    {
        private readonly GuiThemTienDAO guiThemTienDAO = new GuiThemTienDAO();

        public string GuiThemTien(int soTaiKhoanTienGoi, float soTienGuiThem, DateTime ngayGiaoDich)
        {
            // Kiểm tra số tiền gửi thêm có hợp lệ
            if (soTienGuiThem < 100000)
                return "Số tiền gửi thêm tối thiểu là 100,000 đồng.";

            // Lấy ngày đáo hạn kế tiếp từ DAO
            DateTime ngayDaoHanKeTiep = guiThemTienDAO.GetNgayDaoHanKeTiep(soTaiKhoanTienGoi);

            if (ngayGiaoDich.Date != ngayDaoHanKeTiep.Date)
            {
                return $"Chỉ được gửi thêm tiền vào đúng ngày đáo hạn kế tiếp ({ngayDaoHanKeTiep:dd/MM/yyyy}).";
            }

            // Cập nhật tổng tiền gốc trong cơ sở dữ liệu
            bool isUpdated = guiThemTienDAO.UpdateTongTienGoc(soTaiKhoanTienGoi, soTienGuiThem);

            // Trả về kết quả
            if (isUpdated)
                return "Gửi thêm tiền thành công! Tổng tiền gốc đã được cập nhật.";
            else
                return "Gửi thêm tiền thất bại. Vui lòng thử lại.";
        }
    }
}
