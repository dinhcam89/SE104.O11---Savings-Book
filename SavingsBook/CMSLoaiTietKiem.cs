﻿using SavingsBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class CMSLoaiTietKiem : ContextMenuStrip
    {
        public CMSLoaiTietKiem()
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
            MessageBox.Show("Hiện thông tin chi tiết của loại tiết kiệm");
        }
        private void DeleteItem(object sender, EventArgs e)
        {
            //thêm hàm xóa vào đây nhé Conal
            MessageBox.Show("Item đã được xóa.");
        }
    }
}