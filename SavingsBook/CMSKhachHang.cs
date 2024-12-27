using BUS;
using DAO;
using DTO;
using SavingsBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class CMSKhachHang : ContextMenuStrip
    {
        public string SoTaiKhoanThanhToan { get; set; } // Thuộc tính lưu mã khách hàng
        Action _reload;
        public CMSKhachHang(Action reload)
        {
            // Khởi tạo các mục menu
            ToolStripMenuItem menuItemQuanLy = new ToolStripMenuItem("Chi tiết");
            menuItemQuanLy.Click += OpenManagementForm!;

            ToolStripMenuItem menuItemThemPhieu = new ToolStripMenuItem("Thêm phiếu gửi tiền");
            menuItemThemPhieu.Click += AddSavingsBook!;
            // Thêm các mục vào ContextMenuStrip
            this.Items.Add(menuItemQuanLy);
            this.Items.Add(menuItemThemPhieu);
            _reload = reload;

        }
        private void AddSavingsBook(object sender, EventArgs e)
        {
            // Mở form hoặc xử lý logic để thêm phiếu gửi tiền
            ThemPhieu formThemPhieu = new ThemPhieu(SoTaiKhoanThanhToan); // Sử dụng constructor để truyền mã
            formThemPhieu.Show();
            // Thông báo cho người dùng
        }
        private void OpenManagementForm(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin khách hàng từ DAO
                KhachHangBUS khachHangBUS = new KhachHangBUS();
                KhachHang? khachHang = khachHangBUS.LayKhachHangTheoSoTaiKhoan(SoTaiKhoanThanhToan);

                if (khachHang != null)
                {
                    // Mở form và hiển thị thông tin
                    ThongTinKhachHang thongTinForm = new ThongTinKhachHang(_reload);
                    thongTinForm.LoadThongTinKhachHang(khachHang);
                    thongTinForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      
    }
}