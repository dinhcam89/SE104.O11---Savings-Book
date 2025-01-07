using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using DAO;

namespace BUS
{
    public class ChiTietGuiTienBUS
    {
        private readonly ChiTietGuiTienDAO ChiTietGuiTienDAO = new ChiTietGuiTienDAO();

        public string GuiThemTien(string soTaiKhoanTienGoi, float soTienGuiThem, DateTime ngayGiaoDich)
        {
            // Lấy số tiền gửi tối thiểu của tham số
            double soTenGoiThemToiThieu = new ThamSoBUS().getThamSo()!.SoTienGoiThemToiThieu;

            // Lấy số dư hiện có của khách hàng
            string soTaiKhoanThanhToan = new PhieuGoiTienBUS().GetPhieuGoiTienBySoTaiKhoanTienGoi(soTaiKhoanTienGoi)!.SoTaiKhoanThanhToan;
            double soDuHienCo = new KhachHangBUS().LayKhachHangTheoSoTaiKhoan(soTaiKhoanThanhToan)!.SoDuHienCo;

            // Kiểm tra số tiền gửi thêm có hợp lệ
            if (soTienGuiThem < soTenGoiThemToiThieu || soTienGuiThem > soDuHienCo)
                return $"Số tiền gửi thêm nằm trong khoảng từ {formatSoTien(soTenGoiThemToiThieu)} đến {formatSoTien(soDuHienCo)}.";

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
                {
                    // Trừ số dư hiện có của khách hàng
                    KhachHang kh = new KhachHangBUS().LayKhachHangTheoSoTaiKhoan(soTaiKhoanThanhToan)!;
                    kh.SoDuHienCo -= soTienGuiThem;
                    bool res = new KhachHangBUS().CapNhatKhachHang(kh);
                    if (!res)
                    {
                        return "Trừ số dư hiện có không thành công!";
                    }
                    return "Gửi thêm tiền thành công!";
                }
                else
                    return "Ghi giao dịch thất bại.";
            }
            else
            {
                return "Gửi thêm tiền thất bại. Vui lòng thử lại.";
            }

            

        }
        string formatSoTien(double sotien)
        {
            string formatedText;
            if (sotien == 0)
            {
                formatedText = sotien + " VND";
            }
            else
            {
                formatedText = sotien.ToString("#,#.##") + " VND";
            }
            return formatedText;
        }
    }
}
