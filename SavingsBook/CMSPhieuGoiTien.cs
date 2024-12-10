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
        public CMSPhieuGoiTien()
        {
            // Khởi tạo các mục menu
            ToolStripMenuItem menuItemQuanLy = new ToolStripMenuItem("Chi tiết");
            menuItemQuanLy.Click += OpenManagementForm!;

            ToolStripMenuItem menuItemGuiTien = new ToolStripMenuItem("Gửi tiền");
            menuItemGuiTien.Click += OpenDepositForm!;

            ToolStripMenuItem menuItemRutTien = new ToolStripMenuItem("Rút tiền");
            menuItemRutTien.Click += OpenWithdrawalForm!;

            ToolStripMenuItem menuItemXoa = new ToolStripMenuItem("Xóa");
            menuItemXoa.Click += DeleteItem!;

            // Thêm các mục vào ContextMenuStrip
            this.Items.Add(menuItemQuanLy);
            this.Items.Add(menuItemGuiTien);
            this.Items.Add(menuItemRutTien);
            this.Items.Add(menuItemXoa);
        }
        private void OpenManagementForm(object sender, EventArgs e)
        {
            SlotInfor slotInfor = new SlotInfor();
            slotInfor.Show();
        }

        private void OpenDepositForm(object sender, EventArgs e)
        {
            DepositReceiptForm form = new DepositReceiptForm();
            form.Show();
        }

        private void OpenWithdrawalForm(object sender, EventArgs e)
        {
            WithdrawalReceiptForm form = new WithdrawalReceiptForm();
            form.Show();
        }

        private void DeleteItem(object sender, EventArgs e)
        {
            //thêm hàm xóa vào đây nhé Conal
            MessageBox.Show("Item đã được xóa.");
        }
    }
}
