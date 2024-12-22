<<<<<<< HEAD
﻿namespace BUS
{
    public class Class1
    {

=======
﻿using DTO;
using DAO;
namespace BUS
{
    public class KhachHangBUS
    {
        private KhachHangDAO khachHangDAO = new KhachHangDAO();

        public bool ThemKhachHang(KhachHangDTO khachHang)
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
    public class PhieuGoiTienBUS
    {
        private PhieuGoiTienDAO phieuGoiTienDAO = new PhieuGoiTienDAO();
        private LoaiTietKiemDAO loaiTietKiemDAO = new LoaiTietKiemDAO();

        public bool ThemPhieuGoiTien(PhieuGoiTienDTO phieu, int maKhachHang, int kyHan)
        {
            // Lấy SoTaiKhoanThanhToan từ MaKhachHang
            phieu.SoTaiKhoanThanhToan = phieuGoiTienDAO.GetSoTaiKhoanThanhToanByMaKhachHang(maKhachHang);

            // Xác định Mã Loại Tiết Kiệm dựa trên kỳ hạn
            switch (kyHan)
            {
                case 1:
                    phieu.MaLoaiTietKiem = 1;
                    break;
                case 7:
                    phieu.MaLoaiTietKiem = 7;
                    break;
                case 8:
                    phieu.MaLoaiTietKiem = 8;
                    break;
                default:
                    throw new Exception("Kỳ hạn không hợp lệ!");
            }

            // Lấy thông tin loại tiết kiệm
            var loaiTietKiem = loaiTietKiemDAO.GetLoaiTietKiemByMa(phieu.MaLoaiTietKiem);
            if (loaiTietKiem == null)
                throw new Exception("Loại tiết kiệm không tồn tại!");

            // Gán lãi suất
            phieu.LaiSuatApDung = loaiTietKiem.LaiSuat;
            phieu.LaiSuatPhatSinh = loaiTietKiem.LaiSuat;

            // Tính ngày đáo hạn
            phieu.NgayDaoHanKeTiep = phieu.NgayGoi.AddMonths(loaiTietKiem.KyHan);

            // Tính tổng tiền lãi phát sinh
            phieu.TongTienLaiPhatSinh = phieu.TongTienGoc * (1 + phieu.LaiSuatApDung / 100);

            return phieuGoiTienDAO.ThemPhieuGoiTien(phieu);
        }
        public double GetLaiSuatByKyHan(int kyHan)
        {
            // Lấy Mã Loại Tiết Kiệm tương ứng với kỳ hạn
            int maLoaiTietKiem;
            switch (kyHan)
            {
                case 1:
                    maLoaiTietKiem = 1; // Không kỳ hạn
                    break;
                case 7:
                    maLoaiTietKiem = 7; // 3 tháng
                    break;
                case 8:
                    maLoaiTietKiem = 8; // 6 tháng
                    break;
                default:
                    throw new Exception("Kỳ hạn không hợp lệ!");
            }

            // Lấy thông tin Loại Tiết Kiệm từ DAO
            var loaiTietKiem = loaiTietKiemDAO.GetLoaiTietKiemByMa(maLoaiTietKiem);
            if (loaiTietKiem == null)
                throw new Exception("Loại tiết kiệm không tồn tại!");

            // Trả về lãi suất
            return loaiTietKiem.LaiSuat;
        }
        public int GetSoTaiKhoanThanhToanByMaKhachHang(int maKhachHang)
        {
            try
            {
                return phieuGoiTienDAO.GetSoTaiKhoanThanhToanByMaKhachHang(maKhachHang);
            }
            catch
            {
                throw new Exception("Mã khách hàng không tồn tại!");
            }
        }
>>>>>>> b9113d9 (Initial commit)
    }
}
