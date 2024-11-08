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

        private void btnCustomer11_Click(object sender, EventArgs e)
        {
            CustomerInfor customerInfor = new CustomerInfor();
            customerInfor.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddSavingBooks editCustomerInfor = new AddSavingBooks();
            editCustomerInfor.Show();
        }

        private void ucManageSavingBooks_Load(object sender, EventArgs e)
        {
           populateItems();

        }

        private void populateItems()
        {
            ListItem[] listItems = new ListItem[20];

            for (int i = 0; i < listItems.Length; i++)
            {
                listItems[i] = new ListItem();
                listItems[i].CustomerName = "Tên khách hàng " + i;
                listItems[i].Id = "Mã khách hàng " + i;
                listItems[i].Type = "Loại kỳ hạn " + i;

                flowLayoutPanel1.Controls.Add(listItems[i]);
            }

            flowLayoutPanel1.Resize += (s, e) => {
                foreach (ListItem item in flowLayoutPanel1.Controls)
                {
                    item.Width = flowLayoutPanel1.ClientSize.Width;
                }
            };

        }



    }
}
