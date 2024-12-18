using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class ChiTietRutTienBUS
    {
        private readonly ChiTietRutTienDAO rutTienDAO = new ChiTietRutTienDAO();
        public string RutTien(int maPhieuGuiTien, DateTime ngayRut, double soTienRut)
        {
            PhieuGuiTien phieuGuiTien = rutTienDAO.GetPhieuGoiTienById(maPhieuGuiTien);

            if (soTienRut > phieuGuiTien.TongTienGoc + phieuGuiTien.TongTienLaiPhatSinh)
                return $"Số tiền rút lớn hơn số tiền hiện có trong sổ tiết kiệm.";

            LoaiTietKiem loaiTietKiem = rutTienDAO.GetLoaiTietKiemById(phieuGuiTien.MaLoaiTietKiem);
            if (loaiTietKiem == null)
                return "Không tìm thấy thông tin loại tiết kiệm.";

            int soNgayGui = (ngayRut - phieuGuiTien.NgayGui).Days;

            if (loaiTietKiem.KyHan == 0)
            {

                if (soNgayGui < 15)
                    return "Sổ tiết kiệm không kỳ hạn chỉ được rút sau 15 ngày.";

                if (!rutTienDAO.UpdatePhieuGoiTienAfterRut(maPhieuGuiTien, soTienRut))
                    return "Lỗi khi cập nhật số tiền gốc sau khi rút.";

                if (!rutTienDAO.UpdateKhachHangSoDu(phieuGuiTien.MaKH, soTienRut))
                    return "Lỗi khi cập nhật số dư hiện có của khách hàng.";

                InsertChiTietRutTien(maPhieuGuiTien, soTienRut, ngayRut);

                return $"Rút tiền thành công.";
            }
            else
            {
                if (ngayRut < phieuGuiTien.NgayDaoHanKeTiep)
                    return "Sổ tiết kiệm có kỳ hạn chỉ được rút khi đã quá kỳ hạn.";

                if (!rutTienDAO.UpdatePhieuGoiTienToZero(maPhieuGuiTien))
                    return "Lỗi khi cập nhật thông tin sổ tiết kiệm (gốc và lãi phát sinh).";

                if (!rutTienDAO.UpdateKhachHangSoDu(phieuGuiTien.MaKH, soTienRut))
                    return "Lỗi khi cập nhật số dư hiện có của khách hàng.";

                InsertChiTietRutTien(maPhieuGuiTien, soTienRut, ngayRut);

                return $"Rút tiền thành công.";
            }
        }

        private void InsertChiTietRutTien(int maPhieuGuiTien, double soTienRut, DateTime ngayRut)
        {
            ChiTietRutTien chiTietRutTien = new ChiTietRutTien
            {
                MaPhieuGuiTien = maPhieuGuiTien,
                NgayRut = ngayRut,
                SoTienRut = soTienRut
            };
            rutTienDAO.InsertChiTietRutTien(chiTietRutTien);
        }

    }
}
