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
        public CMSKhachHang()
        {
            // Khởi tạo các mục menu
            ToolStripMenuItem menuItemQuanLy = new ToolStripMenuItem("Chi tiết");
            menuItemQuanLy.Click += OpenManagementForm!;

            ToolStripMenuItem menuItemXoa = new ToolStripMenuItem("Xóa");
            menuItemXoa.Click += DeleteItem!;

            ToolStripMenuItem menuItemThemPhieu = new ToolStripMenuItem("Thêm phiếu gửi tiền");
            menuItemThemPhieu.Click += AddSavingsBook!;
            // Thêm các mục vào ContextMenuStrip
            this.Items.Add(menuItemQuanLy);
            this.Items.Add(menuItemXoa);
            this.Items.Add(menuItemThemPhieu);

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
                KhachHangDAO khachHangDAO = new KhachHangDAO();
                KhachHang? khachHang = khachHangDAO.LayKhachHangTheoSoTaiKhoan(SoTaiKhoanThanhToan);

                if (khachHang != null)
                {
                    // Mở form và hiển thị thông tin
                    ThongTinKhachHang thongTinForm = new ThongTinKhachHang();
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
        private void DeleteItem(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này không? Hành động này không thể hoàn tác!",
        "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    var khachHangDAO = new DAO.KhachHangDAO();
                    bool result = khachHangDAO.XoaKhachHang(SoTaiKhoanThanhToan);

                    if (result)
                    {
                        MessageBox.Show("Xóa khách hàng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Làm mới giao diện khách hàng
                        if (Parent is GUI.DashboardApp.ucQuanLyKhachHang parentControl)
                        {
                            parentControl.RefreshCustomerList();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
