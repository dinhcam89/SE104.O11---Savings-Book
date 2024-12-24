using DTO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUS;
using System.Windows.Forms;

namespace GUI
{
    public partial class GiaHanVaTinhLai : Form
    {
        public GiaHanVaTinhLai()
        {
            InitializeComponent();
            List<PhieuGoiTien> phieuGoiTiens = new PhieuGoiTienBUS().GetPhieuGoiTien();
            foreach (PhieuGoiTien pgt in  phieuGoiTiens)
            {
                // Lấy kỳ hạn, lãi suất của loại tiết kiệm dựa vào mã loại tiết kiệm
                LoaiTietKiem? ltk = new LoaiTietKiemBUS().getLoaiTietKiemById(pgt.MaLoaiTietKiem);
                if (ltk == null)
                {
                    continue;
                }
                while (DateTime.Now > pgt.NgayDaoHanKeTiep)
                {
                    pgt.TongTienGoc = tinhTongTienGoc(pgt.TongTienGoc, pgt.HinhThucGiaHan, pgt.TongTienLaiPhatSinh, pgt.NgayDaoHanKeTiep);
                    pgt.TongTienLaiPhatSinh = tinhTongLaiPhatSinh(pgt.TongTienLaiPhatSinh, pgt.TongTienGoc, ltk.KyHan, pgt.LaiSuatApDung);
                    pgt.LaiSuatApDung = tinhLaiSuatApDung(pgt.LaiSuatApDung, pgt.LaiSuatPhatSinh, ltk.LaiSuat, pgt.NgayDaoHanKeTiep, pgt.HinhThucGiaHan);
                    pgt.NgayDaoHanKeTiep = tinhNgayDaoHanKeTiep(pgt.NgayDaoHanKeTiep, ltk.KyHan);
                }
            }
            dgvPhieuGoiTien.DataSource = phieuGoiTiens;
        }

        double tinhLaiPhatSinh(double tongTienGoc, int kyHan, double laiSuat)
        {
            return tongTienGoc * kyHan * (laiSuat / (12 * 100));
        }
        /// <summary>
        /// Trả về tổng lãi suất phát sinh đã tính khi hết kỳ hạn, dựa vào tổng lãi phát sinh, tổng tiền gốc, kỳ hạn và lãi suất
        /// </summary>
        /// <param name="tongLaiPhatSinh">Tổng lãi phát sinh cần cập nhật</param>
        /// <param name="tongTienGoc">Tổng số tiền gốc</param>
        /// <param name="kyHan">Kỳ hạn của loại tiết kiệm</param>
        /// <param name="laiSuat">Lãi suất của loại tiết kiệm</param>
        /// <returns>Tổng lãi suất phát sinh đã được cập nhật</returns>
        double tinhTongLaiPhatSinh(double tongLaiPhatSinh, double tongTienGoc, int kyHan, double laiSuat)
        {
            return tongLaiPhatSinh + tinhLaiPhatSinh(tongTienGoc, kyHan, laiSuat);
        }
        DateTime tinhNgayDaoHanKeTiep(DateTime ngayDaoHanKeTiep, int kyHan)
        {
            // Cập nhật ngày đáo hạn kế tiếp, bằng cách cộng thêm kỳ hạn (tháng) vào ngày đáo hạn hiện tại
            return ngayDaoHanKeTiep.AddMonths(kyHan);
        }
        double tinhLaiSuatApDung(double laiSuatApDung, double laiSuatPhatSinh, double laiSuatKhongKyHan, DateTime ngayDaoHanKeTiep, int hinhThucGiaHan)
        {
            // Nếu ngày hiện tại chưa quá ngày đáo hạn kế tiếp, lãi suất giữ nguyên
            if (DateTime.Now <= ngayDaoHanKeTiep)
            {
                return laiSuatApDung;
            }
            // Nếu hình thức gia hạn = 1, tức là không gia hạn, lãi suất áp dụng sẽ bằng lãi suất không kỳ hạn
            // Nếu hình thức gia hạn = 2 hoặc 3, tức là gia hạn, lãi suất áp dụng sẽ bằng lãi suất phát sinh
            return hinhThucGiaHan == 1 ? laiSuatKhongKyHan : laiSuatPhatSinh;
        }
        double tinhLaiSuatPhatSinh(double laiSuatPhatSinh)
        {
            // Chỉ cập nhật lãi suất phát sinh nếu lãi suất của loại tiết kiệm thay đổi
            return laiSuatPhatSinh;
        }
        double tinhTongTienGoc(double tongTienGoc, int hinhThucGiaHan, double tongLaiPhatSinh, DateTime ngayDaoHanKeTiep)
        {
            // Ngày hiện tại chưa quá ngày đáo hạn kế tiếp, tổng tiền gốc giữ nguyên
            if (DateTime.Now <= ngayDaoHanKeTiep)
            {
                return tongTienGoc;
            }
            // Nếu hình thức gia hạn = 1 hoặc 2, tức là không gia hạn hoặc gia hạn xoay vòng gốc, tổng tiền gốc giữ nguyên
            if (hinhThucGiaHan == 1 || hinhThucGiaHan == 2)
            {
                return tongTienGoc;
            }
            // Nếu hình thức gia hạn = 3, tức là gia hạn xoay vòng gốc lẫn lãi, tổng tiền gốc sẽ bằng tổng tiền gốc cũ cộng với tổng lãi phát sinh
            else
            {
                return tongTienGoc + tongLaiPhatSinh;
            }
        }
    }
}
