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
    public partial class ucManageSavingBooks : UserControl
    {
        public ucManageSavingBooks()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblCustomerName_Click(object sender, EventArgs e)
        {

        }

        private void btnCustomer11_Click(object sender, EventArgs e)
        {
            CustomerInfor customerInfor = new CustomerInfor();
            customerInfor.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EditCustomerInfor editCustomerInfor = new EditCustomerInfor();
            editCustomerInfor.Show();
        }
    }
}
