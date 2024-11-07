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
    public partial class WithdrawalReceiptForm : Form
    {
        public WithdrawalReceiptForm()
        {
            InitializeComponent();
            // Thiết lập không cho phép thay đổi kích thước Form
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        //private void btnAdd_Click(object sender, EventArgs e)
        //{

        //}
    }
}
