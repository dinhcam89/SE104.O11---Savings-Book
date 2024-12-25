using SavingsBook;
using System;
using System.Windows.Forms;

namespace GUI
{
    public class CMSPhieuGoiTien : ContextMenuStrip
    {
        public string SoTaiKhoanTienGoi { get; set; }

        public CMSPhieuGoiTien()
        {
            ToolStripMenuItem menuItemQuanLy = new ToolStripMenuItem("Chi tiết");
            menuItemQuanLy.Click += OpenManagementForm!;

            ToolStripMenuItem menuItemGuiTien = new ToolStripMenuItem("Gửi tiền");
            menuItemGuiTien.Click += OpenDepositForm!;

            ToolStripMenuItem menuItemRutTien = new ToolStripMenuItem("Rút tiền");
            menuItemRutTien.Click += OpenWithdrawalForm!;

            ToolStripMenuItem menuItemXoa = new ToolStripMenuItem("Xóa");
            menuItemXoa.Click += DeleteItem!;

            this.Items.Add(menuItemQuanLy);
            this.Items.Add(menuItemGuiTien);
            this.Items.Add(menuItemRutTien);
            this.Items.Add(menuItemXoa);
        }

        private void OpenManagementForm(object sender, EventArgs e)
        {
            try
            {
                // Lấy giá trị số tài khoản tiền gửi
                if (string.IsNullOrWhiteSpace(SoTaiKhoanTienGoi))
                {
                    MessageBox.Show("Số tài khoản tiền gửi không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Mở form chi tiết và hiển thị thông tin
                ThongTinPhieu thongTinForm = new ThongTinPhieu();
                thongTinForm.HienThiThongTinPhieu(SoTaiKhoanTienGoi); // Truyền số tài khoản
                thongTinForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenDepositForm(object sender, EventArgs e)
        {
            GuiTien form = new GuiTien();
            form.Show();
        }

        private void OpenWithdrawalForm(object sender, EventArgs e)
        {
            RutTienForm form = new RutTienForm();
            form.Show();
        }

        private void DeleteItem(object sender, EventArgs e)
        {
            MessageBox.Show("Phiếu gửi tiền đã được xóa.");
        }
    }
}
