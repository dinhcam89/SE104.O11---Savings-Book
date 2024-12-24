using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class BaseForm : Form
    {
        public BaseForm()
        {
            // Đặt kích thước mặc định
            this.Size = new System.Drawing.Size(1035, 687); // Kích thước mặc định: 800x600
            this.StartPosition = FormStartPosition.CenterScreen; // Đặt form xuất hiện giữa màn hình

            // Các cài đặt chung khác (nếu có)
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Giới hạn thay đổi kích thước
        }
    }
}
