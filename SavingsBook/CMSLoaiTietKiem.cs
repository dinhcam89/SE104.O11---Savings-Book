using BUS;
using DTO;
using SavingsBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class CMSLoaiTietKiem : ContextMenuStrip
    {
        private LoaiTietKiem _loaiTietKiem;
        private LoaiTietKiemBUS _loaiTietKiemBUS = new LoaiTietKiemBUS();
        private Action reload;
        public CMSLoaiTietKiem(LoaiTietKiem ltk, Action reload)
        {
            _loaiTietKiem = ltk;
            this.reload = reload;

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
            ChinhSuaLoaiTietKiem form = new ChinhSuaLoaiTietKiem(_loaiTietKiem, reload);
            form.Show();
        }
        private void DeleteItem(object sender, EventArgs e)
        {
            // Hiển thị MessageBox với hai nút Yes/No
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Kiểm tra xem người dùng chọn Yes
            if (result == DialogResult.Yes)
            {
                // Gọi hàm delete() để thực hiện việc xóa
                bool response = _loaiTietKiemBUS.deleteLoaiTietKiem(_loaiTietKiem);
                if (response)
                {
                    MessageBox.Show("Xóa thành công.");
                    reload();
                }
                else
                    MessageBox.Show("Xóa thất bại.");
            }
        }
    }
}
