using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ChiTietRutTienBUS
    {
        private readonly ChiTietRutTienDAO rutTienDAO = new ChiTietRutTienDAO();
        public string RutTien(string soTaiKhoanTienGoi, DateTime ngayRut, double soTienRut)
        {
            PhieuGoiTien PhieuGoiTien = rutTienDAO.GetPhieuGoiTienById(soTaiKhoanTienGoi);

            if (soTienRut > PhieuGoiTien.TongTienGoc + PhieuGoiTien.TongTienLaiPhatSinh)
                return $"Số tiền rút lớn hơn số tiền hiện có trong sổ tiết kiệm.";

            LoaiTietKiem loaiTietKiem = rutTienDAO.GetLoaiTietKiemById(PhieuGoiTien.MaLoaiTietKiem);
            if (loaiTietKiem == null)
                return "Không tìm thấy thông tin loại tiết kiệm.";

            int soNgayGui = (ngayRut - PhieuGoiTien.NgayGoi).Days;

            if (loaiTietKiem.KyHan == 0)
            {

                if (soNgayGui < 15)
                    return "Sổ tiết kiệm không kỳ hạn chỉ được rút sau 15 ngày.";

                if (!rutTienDAO.UpdatePhieuGoiTienAfterRut(soTaiKhoanTienGoi, soTienRut))
                    return "Lỗi khi cập nhật số tiền gốc sau khi rút.";

                if (!rutTienDAO.UpdateKhachHangSoDu(PhieuGoiTien.SoTaiKhoanThanhToan, soTienRut))
                    return "Lỗi khi cập nhật số dư hiện có của khách hàng.";

                InsertChiTietRutTien(soTaiKhoanTienGoi, soTienRut, ngayRut);

                return $"Rút tiền thành công.";
            }
            else
            {
                int kyHan = new LoaiTietKiemBUS().getLoaiTietKiem(PhieuGoiTien.MaLoaiTietKiem).KyHan;

                if (ngayRut < PhieuGoiTien.NgayGoi.AddMonths(kyHan))
                    return "Sổ tiết kiệm có kỳ hạn chỉ được rút khi đã quá kỳ hạn.";

                if (!rutTienDAO.UpdatePhieuGoiTienToZero(soTaiKhoanTienGoi))
                    return "Lỗi khi cập nhật thông tin sổ tiết kiệm (gốc và lãi phát sinh).";

                if (!rutTienDAO.UpdateKhachHangSoDu(PhieuGoiTien.SoTaiKhoanThanhToan, soTienRut))
                    return "Lỗi khi cập nhật số dư hiện có của khách hàng.";

                InsertChiTietRutTien(soTaiKhoanTienGoi, soTienRut, ngayRut);

                return $"Rút tiền thành công.";
            }
        }
        public double GetTongTien(string soTaiKhoanTienGoi)
        {
            PhieuGoiTien PhieuGoiTien = rutTienDAO.GetPhieuGoiTienById(soTaiKhoanTienGoi);
            if (PhieuGoiTien != null)
            {
                return PhieuGoiTien.TongTienGoc + PhieuGoiTien.TongTienLaiPhatSinh;
            }
            return 0;
        }

        public bool KiemTraQuyDinhRutTien(string soTaiKhoanTienGoi)
        {
            PhieuGoiTien PhieuGoiTien = rutTienDAO.GetPhieuGoiTienById(soTaiKhoanTienGoi);
            if (PhieuGoiTien != null)
            {
                LoaiTietKiem loaiTietKiem = rutTienDAO.GetLoaiTietKiemById(PhieuGoiTien.MaLoaiTietKiem);
                if (loaiTietKiem != null)
                {
                    return loaiTietKiem.QuyDinhSoTienRut.Equals("=");
                }
            }
            return false;

        }

        private void InsertChiTietRutTien(string soTaiKhoanTienGoi, double soTienRut, DateTime ngayRut)
        {
            ChiTietRutTien chiTietRutTien = new ChiTietRutTien
            {
                SoTaiKhoanTienGoi = soTaiKhoanTienGoi,
                NgayRut = ngayRut,
                SoTienRut = soTienRut
            };
            rutTienDAO.InsertChiTietRutTien(chiTietRutTien);
        }

    }
}
