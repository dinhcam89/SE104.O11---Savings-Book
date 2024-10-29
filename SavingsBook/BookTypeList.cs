using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;

namespace GUI
{
    public partial class BookTypeList : Form
    {
        public BookTypeList()
        {
            InitializeComponent();
        }

        BookTypeBUS _bookTypeBUS = new();

        private void btnLoadBookTypes_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _bookTypeBUS.getAllBookType();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Thêm một dòng mới vào DataGridView với nội dung có Số tiền tối thiểu ban đầu là 121212
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Xóa dòng cuối cùng
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Cập nhật dòng cuối cùng với Số tiền tối thiểu ban đầu là 999999
        }
    }
}
