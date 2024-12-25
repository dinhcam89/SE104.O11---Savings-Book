using SavingsBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class CMSPhieuGoiTien : ContextMenuStrip
    {
        public string maPhieu;
        public string tenKhachHang;

        public CMSPhieuGoiTien()
        {
            // Khởi tạo các mục menu
            ToolStripMenuItem menuItemThemPhieu = new ToolStripMenuItem("Thêm phiếu");
            menuItemThemPhieu.Click += OpenAddSlotForm!;

            ToolStripMenuItem menuItemQuanLy = new ToolStripMenuItem("Chi tiết");
            menuItemQuanLy.Click += OpenManagementForm!;

            ToolStripMenuItem menuItemGuiTien = new ToolStripMenuItem("Gửi tiền");
            menuItemGuiTien.Click += OpenDepositForm!;

            ToolStripMenuItem menuItemChiTietGuiTien = new ToolStripMenuItem("Chi tiết gửi tiền");
            menuItemChiTietGuiTien.Click += OpenDetailDepositForm!;

            ToolStripMenuItem menuItemRutTien = new ToolStripMenuItem("Rút tiền");
            menuItemRutTien.Click += OpenWithdrawalForm!;

            ToolStripMenuItem menuItemChiTietRutTien = new ToolStripMenuItem("Chi tiết rút tiền");
            menuItemChiTietRutTien.Click += OpenDetailWithdrawalForm!;

            ToolStripMenuItem menuItemXoa = new ToolStripMenuItem("Xóa");
            menuItemXoa.Click += DeleteItem!;

            // Thêm các mục vào ContextMenuStrip
            this.Items.Add(menuItemThemPhieu);
            this.Items.Add(menuItemQuanLy);
            this.Items.Add(menuItemGuiTien);
            this.Items.Add(menuItemChiTietGuiTien);
            this.Items.Add(menuItemRutTien);
            this.Items.Add(menuItemChiTietRutTien);
            this.Items.Add(menuItemXoa);
        }

        private void OpenAddSlotForm(object sender, EventArgs e)
        {
            ThemPhieu form = new ThemPhieu();
            form.Show();
        }

        private void OpenManagementForm(object sender, EventArgs e)
        {
            ThongTinPhieu slotInfor = new ThongTinPhieu();
            slotInfor.Show();
        }

        private void OpenDepositForm(object sender, EventArgs e)
        {
            GuiTien form = new GuiTien(maPhieu);
            form.Show();
        }

        private void OpenDetailDepositForm(object sender, EventArgs e)
        {
            ChiTietGuiTien form = new ChiTietGuiTien(maPhieu, tenKhachHang);
            form.Show();
        }

        private void OpenWithdrawalForm(object sender, EventArgs e)
        {
            RutTienForm form = new RutTienForm(maPhieu);
            form.Show();
        }

        private void OpenDetailWithdrawalForm(object sender, EventArgs e)
        {
            ChiTietRutTien form = new ChiTietRutTien(maPhieu, tenKhachHang);
            form.Show();
        }

        private void DeleteItem(object sender, EventArgs e)
        {
            //thêm hàm xóa vào đây nhé Conal
            MessageBox.Show("Item đã được xóa.");
        }
    }
}
