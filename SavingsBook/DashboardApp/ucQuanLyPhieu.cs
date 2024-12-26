using BUS;
using DAO;
using SavingsBook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using Azure;
using System.Reflection.Metadata.Ecma335;
namespace GUI.DashboardApp
{
    public partial class ucQuanLyPhieu : UserControl
    {
        private PhieuGoiTienBUS PhieuGoiTienBUS = new PhieuGoiTienBUS();
        // Danh sách các đối tượng DTO để lưu dữ liệu từ database
        private List<PhieuGoiTien> listPhieuGoiTien;

        // Lấy dữ liệu từ lớp BUS (nơi xử lý nghiệp vụ)
        // Lấy dữ liệu từ lớp BUS (nơi xử lý nghiệp vụ)
        public ucQuanLyPhieu()
        {
            InitializeComponent();
            listPhieuGoiTien = PhieuGoiTienBUS.GetPhieuGoiTien();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ThemPhieu editCustomerInfor = new ThemPhieu();
            editCustomerInfor.Show();
        }

        private void ucManageSavingBooks_Load(object sender, EventArgs e)
        {
            PopulateItems(listPhieuGoiTien);
        }
        private void PopulateItems(List<PhieuGoiTien> listPhieuGoiTien)
        {
            // Danh sách các đối tượng DTO để lưu dữ liệu từ database
            
            // Kiểm tra dữ liệu
            if (listPhieuGoiTien == null || listPhieuGoiTien.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu nào để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Xóa các điều khiển cũ nếu cần
            flowLayoutPanel1.Controls.Clear();

            // Cập nhật dữ liệu mới nhất
            listPhieuGoiTien = updatePhieuGoiTien(listPhieuGoiTien);

            // Hiển thị từng phiếu gửi tiền lên form
            foreach (var phieuGoiTien in listPhieuGoiTien)
            {
                var listItem = new ListItem
                {
                    Ten1 = phieuGoiTien.TenKhachHang,         // Tên khách hàng
                    Ten2 = phieuGoiTien.SoTaiKhoanTienGoi,    // Số tài khoản tiền gửi
                    Ten3 = phieuGoiTien.MaLoaiTietKiem,       // Mã loại tiết kiệm
                    Ten4 = phieuGoiTien.NgayGoi.ToString("dd/MM/yyyy"), // Ngày gửi (format dd/MM/yyyy)
                    FormType = ObjectType.PhieuGoiTien        // Loại đối tượng
                };

                // Gán sự kiện cho nút bấm nếu cần
                listItem.ButtonClick += (s, e) =>
                {
                    MessageBox.Show($"Xem chi tiết phiếu gửi tiền: {phieuGoiTien.SoTaiKhoanTienGoi}", "Thông tin");
                };

                // Thêm điều khiển vào FlowLayoutPanel
                flowLayoutPanel1.Controls.Add(listItem);
            }

            // Đảm bảo các ListItem tự động thay đổi kích thước theo FlowLayoutPanel
            flowLayoutPanel1.Resize += (s, e) =>
            {
                foreach (ListItem item in flowLayoutPanel1.Controls)
                {
                    item.Width = flowLayoutPanel1.ClientSize.Width;
                }
            };
        }
        List<PhieuGoiTien> updatePhieuGoiTien(List<PhieuGoiTien> phieuGoiTiens)
        {
            List<PhieuGoiTien> updatedPhieuGoiTien = new List<PhieuGoiTien>();
            foreach (PhieuGoiTien pgt in phieuGoiTiens)
            {
                // Lấy kỳ hạn, lãi suất của loại tiết kiệm dựa vào mã loại tiết kiệm
                LoaiTietKiem? ltk = new LoaiTietKiemBUS().getLoaiTietKiem(pgt.MaLoaiTietKiem);

                if (ltk == null)
                {
                    continue;
                }

                // Lấy lãi suất của loại tiết kiệm không kỳ hạn
                double laiSuatKhongKyHan = layLaiSuatKhongKyHan() ?? 0.05;

                PhieuGoiTien updatedPgt = pgt;
                while (DateTime.Now > pgt.NgayDaoHanKeTiep)
                {
                    updatedPgt.TongTienGoc = tinhTongTienGoc(pgt.TongTienGoc, pgt.HinhThucGiaHan, pgt.TongTienLaiPhatSinh, pgt.NgayDaoHanKeTiep);
                    updatedPgt.TongTienLaiPhatSinh = tinhTongLaiPhatSinh(pgt.TongTienLaiPhatSinh, pgt.TongTienGoc, ltk.KyHan, pgt.LaiSuatApDung);
                    updatedPgt.LaiSuatApDung = tinhLaiSuatApDung(pgt.LaiSuatApDung, pgt.LaiSuatPhatSinh, laiSuatKhongKyHan, pgt.NgayDaoHanKeTiep, pgt.HinhThucGiaHan);
                    updatedPgt.LaiSuatPhatSinh = tinhLaiSuatPhatSinh(pgt.LaiSuatPhatSinh, pgt.HinhThucGiaHan, pgt.NgayDaoHanKeTiep, laiSuatKhongKyHan);
                    updatedPgt.NgayDaoHanKeTiep = tinhNgayDaoHanKeTiep(pgt.NgayDaoHanKeTiep, ltk.KyHan, pgt.HinhThucGiaHan);
                    if (pgt.HinhThucGiaHan == 1)
                    {
                        break;
                    }
                }
                bool response = PhieuGoiTienBUS.UpdatePhieuGoiTien(pgt);
                if (!response)
                {
                    MessageBox.Show("Cập nhật phiếu gởi tiền thất bại. Tài khoản tiền gởi: " + pgt.SoTaiKhoanTienGoi, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } 
                else
                {
                    updatedPhieuGoiTien.Add(updatedPgt);
                }
            }
            return updatedPhieuGoiTien;

        }
        /// <summary>
        /// Tính lãi phát sinh theo kỳ hạn
        /// </summary>
        /// <param name="tongTienGoc">Tổng tiền gốc</param>
        /// <param name="kyHan">Kỳ hạn</param>
        /// <param name="laiSuat">Lãi suất</param>
        /// <returns></returns>
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
        /// <summary>
        /// Trả về ngày đáo hạn kế tiếp của phiếu gởi tiền
        /// </summary>
        /// <param name="ngayDaoHanKeTiep">Ngày đáo hạn hiện tại</param>
        /// <param name="kyHan">Kỳ hạn</param>
        /// <param name="hinhThucGiaHan">Hình thức gia hạn</param>
        /// <returns></returns>
        DateTime tinhNgayDaoHanKeTiep(DateTime ngayDaoHanHienTai, int kyHan, int hinhThucGiaHan)
        {
            if (hinhThucGiaHan == 1)
            {
                return ngayDaoHanHienTai;
            }
            // Cập nhật ngày đáo hạn kế tiếp, bằng cách cộng thêm kỳ hạn (tháng) vào ngày đáo hạn hiện tại
            return ngayDaoHanHienTai.AddMonths(kyHan);
        }
        /// <summary>
        /// Trả về lãi suất áp dụng mới nhất
        /// </summary>
        /// <param name="laiSuatApDung">Lãi suất áp dụng hiện tại</param>
        /// <param name="laiSuatPhatSinh">Lãi suất phát sinh hiện tại</param>
        /// <param name="laiSuatKhongKyHan"></param>
        /// <param name="ngayDaoHanKeTiep"></param>
        /// <param name="hinhThucGiaHan"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Tính lãi suất phát sinh mới nhất
        /// </summary>
        /// <param name="laiSuatPhatSinh">Lãi suất phát sinh hiện tại</param>
        /// <param name="hinhThucGiaHan">Hình thức gia hạn</param>
        /// <param name="ngayDaoHanKeTiep"Ngày đáo hạn kế tiếp></param>
        /// <param name="laiSuatKhongKyHan">Lãi suất không kỳ hạn</param>
        /// <returns></returns>
        double tinhLaiSuatPhatSinh(double laiSuatPhatSinh, int hinhThucGiaHan, DateTime ngayDaoHanKeTiep, double laiSuatKhongKyHan)
        {
            // Chỉ cập nhật lãi suất phát sinh nếu lãi suất của loại tiết kiệm thay đổi
            if (hinhThucGiaHan == 1 && DateTime.Now > ngayDaoHanKeTiep)
            {
                return laiSuatKhongKyHan;
            }
            return laiSuatPhatSinh;
        }
        /// <summary>
        /// Tính tổng tiền gốc mới nhất
        /// </summary>
        /// <param name="tongTienGoc">Tổng tiền gốc hiện tại</param>
        /// <param name="hinhThucGiaHan">Hình thức gia hạn</param>
        /// <param name="tongLaiPhatSinh">Lãi suất phát sinh</param>
        /// <param name="ngayDaoHanKeTiep">Ngày đáo hạn kế tiếp</param>
        /// <returns></returns>
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
        /// <summary>
        /// Lấy lãi suất không kỳ hạn
        /// </summary>
        /// <returns></returns>
        double? layLaiSuatKhongKyHan()
        {
            // Lấy tất cả loại lãi suất
            List<LoaiTietKiem> loaiTietKiems = new LoaiTietKiemBUS().getListLoaiTietKiem();

            // Tìm loại lãi suất có kỳ hạn bằng 0
            foreach (LoaiTietKiem ltk in loaiTietKiems)
            {
                if (ltk.KyHan == 0)
                {
                    return ltk.LaiSuat;
                }
            }
            return null;
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtTimKiem.Text.Trim();
            var listPhieuGoiTien = PhieuGoiTienBUS.SearchPhieuGoiTien(searchText);

            PopulateItems(listPhieuGoiTien);
        }
    }
}