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
    public partial class WithdrawSlipList : Form
    {
        public WithdrawSlipList()
        {
            InitializeComponent();
        }
        WithdrawSlipBUS _withdrawSlipBUS = new();
        private void btnLoad_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _withdrawSlipBUS.getAllWithdrawSlip();
            dataGridView1.Refresh();
        }
    }
}
