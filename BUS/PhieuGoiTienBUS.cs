using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BUS
{
    public class PhieuGoiTienBUS
    {
        private PhieuGoiTienDAO PhieuGoiTienDAO = new PhieuGoiTienDAO();
        public List<PhieuGoiTien> GetAllPhieuGoiTien()
        {
            return PhieuGoiTienDAO.GetAllPhieuGoiTienWithKhachHang();
        }
        private PhieuGoiTienDAO phieuGoiTienDAO = new PhieuGoiTienDAO();
        private KhachHangDAO khachHangDAO;
        private readonly PhieuGoiTienDAO _phieuGoiTienDAO = new PhieuGoiTienDAO();
        public bool XoaPhieuGoiTien(string soTaiKhoanTienGoi)
        {
            PhieuGoiTienDAO phieuGoiTienDAO = new PhieuGoiTienDAO();
            return phieuGoiTienDAO.XoaPhieuGoiTien(soTaiKhoanTienGoi);
        }

        public PhieuGoiTien LayPhieuGoiTien(string soTaiKhoanTienGoi)
        {
            return _phieuGoiTienDAO.LayPhieuGoiTienTheoSoTaiKhoan(soTaiKhoanTienGoi);
        }
        public List<(string TenKhachHang, string SoTaiKhoanTienGoi, string MaLoaiTietKiem)> LayThongTinPhieuGoiTien()
        {
            List<PhieuGoiTien> danhSachPhieu = phieuGoiTienDAO.LayDanhSachPhieuGoiTien();
            Dictionary<string, string> danhSachKhachHang = khachHangDAO.LayDanhSachKhachHang_1();

            List<(string TenKhachHang, string SoTaiKhoanTienGoi, string MaLoaiTietKiem)> ketQua = new();

            foreach (var phieu in danhSachPhieu)
            {
                string tenKhachHang = danhSachKhachHang.ContainsKey(phieu.SoTaiKhoanTienGoi)
                    ? danhSachKhachHang[phieu.SoTaiKhoanTienGoi]
                    : "Không xác định";

                ketQua.Add((tenKhachHang, phieu.SoTaiKhoanTienGoi, phieu.MaLoaiTietKiem));
            }

            return ketQua;
        }
        public bool ThemPhieuGoiTien(PhieuGoiTien phieu, string maKhachHang, int kyHan)
        {
            // Lấy SoTaiKhoanThanhToan từ MaKhachHang
            phieu.SoTaiKhoanThanhToan = maKhachHang;
            phieu.SoTaiKhoanTienGoi = maKhachHang;


            // Xác định Mã Loại Tiết Kiệm dựa trên kỳ hạn
            switch (kyHan)
            {
                case 1:
                    phieu.MaLoaiTietKiem = "LTK0000000"; // Không kỳ hạn
                    break;
                case 7:
                    phieu.MaLoaiTietKiem = "LTK0000001"; // 3 tháng
                    break;
                case 8:
                    phieu.MaLoaiTietKiem = "LTK0000003"; // 6 tháng
                    break;
                default:
                    throw new Exception("Kỳ hạn không hợp lệ!");
            }

            // Lấy thông tin loại tiết kiệm
            var loaiTietKiem = phieuGoiTienDAO.GetLoaiTietKiemByMa(phieu.MaLoaiTietKiem);
            if (loaiTietKiem == null)
                throw new Exception("Loại tiết kiệm không tồn tại!");

            // Gán lãi suất
            phieu.LaiSuatApDung = Convert.ToSingle(loaiTietKiem.LaiSuat);
            phieu.LaiSuatPhatSinh = Convert.ToSingle(loaiTietKiem.LaiSuat);

            // Tính ngày đáo hạn
            phieu.NgayDaoHanKeTiep = phieu.NgayGoi.AddMonths(loaiTietKiem.KyHan);

            // Tính tổng tiền lãi phát sinh
            phieu.TongTienLaiPhatSinh = phieu.TongTienGoc * (1 + phieu.LaiSuatApDung / 100);

            return phieuGoiTienDAO.ThemPhieuGoiTien(phieu);
        }
        public double GetLaiSuatByKyHan(int kyHan)
        {
            // Lấy Mã Loại Tiết Kiệm tương ứng với kỳ hạn
            string maLoaiTietKiem;
            switch (kyHan)
            {
                case 1:
                    maLoaiTietKiem = "LTK0000000"; // Không kỳ hạn
                    break;
                case 7:
                    maLoaiTietKiem = "LTK0000001"; // 3 tháng
                    break;
                case 8:
                    maLoaiTietKiem = "LTK0000002"; // 6 tháng
                    break;
                default:
                    throw new Exception("Kỳ hạn không hợp lệ!");
            }

            // Lấy thông tin Loại Tiết Kiệm từ DAO
            var loaiTietKiem = phieuGoiTienDAO.GetLoaiTietKiemByMa(maLoaiTietKiem);
            if (loaiTietKiem == null)
                throw new Exception("Loại tiết kiệm không tồn tại!");

            // Trả về lãi suất
            return loaiTietKiem.LaiSuat;
        }
        public string? LaySoTaiKhoanThanhToan(string soTaiKhoanTienGoi)
        {
            PhieuGoiTienDAO dao = new PhieuGoiTienDAO();
            return dao.LaySoTaiKhoanThanhToan(soTaiKhoanTienGoi);
        }

    }
}
