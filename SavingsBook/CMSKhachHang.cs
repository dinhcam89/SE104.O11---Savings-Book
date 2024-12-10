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
        public CMSKhachHang()
        {
            // Khởi tạo các mục menu
            ToolStripMenuItem menuItemQuanLy = new ToolStripMenuItem("Chi tiết");
            menuItemQuanLy.Click += OpenManagementForm!;

            ToolStripMenuItem menuItemXoa = new ToolStripMenuItem("Xóa");
            menuItemXoa.Click += DeleteItem!;

            // Thêm các mục vào ContextMenuStrip
            this.Items.Add(menuItemQuanLy);
            this.Items.Add(menuItemXoa);
        }
        private void OpenManagementForm(object sender, EventArgs e)
        {
            MessageBox.Show("Hiện thông tin chi tiết của khách hàng");
        }
        private void DeleteItem(object sender, EventArgs e)
        {
            MessageBox.Show("Khách hàng đã được xóa.");
        }
    }
}
