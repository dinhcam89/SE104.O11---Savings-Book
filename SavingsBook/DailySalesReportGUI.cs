using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class DailySalesReportGUI : Form
    {
        public DailySalesReportGUI()
        {
            InitializeComponent();
        }
        DailySalesReportBUS dailySalesReportBUS = new();
        private void btnLoad_Click(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker1.Value;
            dataGridView1.DataSource = dailySalesReportBUS.getDailySalesReportByDate(date);
            dataGridView1.Refresh();
        }
    }
}
