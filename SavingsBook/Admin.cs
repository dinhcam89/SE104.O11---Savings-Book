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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddAccount addAccount = new AddAccount();
            addAccount.Show();
        }

        private void populateItems()
        {
            ListItem[] listItems = new ListItem[10];

            for (int i = 0; i < listItems.Length; i++)
            {
                listItems[i] = new ListItem();
                listItems[i].CustomerName = "Tên Nhân viên " + i;
                listItems[i].Id = "Chức vụ nhân viên " + i;
                listItems[i].Type = "Phòng ban nhân viên " + i;


                flowLayoutPanel1.Controls.Add(listItems[i]);

            }
            flowLayoutPanel1.Resize += (s, e) => {
                foreach (ListItem item in flowLayoutPanel1.Controls)
                {
                    item.Width = flowLayoutPanel1.ClientSize.Width;
                }
            };
        }


        private void Admin_Load(object sender, EventArgs e)
        {
            populateItems();
        }
    }
}
