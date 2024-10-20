using SavingsBook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.DashboardApp
{
    public partial class ucManageCustomers : UserControl
    {
        public ucManageCustomers()
        {
            InitializeComponent();
        }

        private void btnCustomer1_Click(object sender, EventArgs e)
        {
            EditCustomerInfor editcustomerInfor = new EditCustomerInfor();
            editcustomerInfor.Show();
        }
    }
}
