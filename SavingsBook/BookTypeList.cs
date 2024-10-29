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
            DataTable? dataTable = _bookTypeBUS.getAllBookType();
            dataGridView1.DataSource = dataTable;
        }
    }
}
