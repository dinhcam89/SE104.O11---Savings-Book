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

        private void Admin_Load(object sender, EventArgs e)
        {
            populateItems();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            populateItems();
        }

        private void populateItems()
        {
            ListItem[] listItems = new ListItem[5];

            for (int i = 0; i < listItems.Length; i++)
            {
                listItems[i] = new ListItem();
                listItems[i].Width = flowLayoutPanel1.ClientSize.Width;
                listItems[i].CustomerName = "Tên Nhân viên";
                listItems[i].Id = "Chức vụ nhân viên";
                listItems[i].Type = "Phòng ban nhân viên";

                flowLayoutPanel1.Controls.Add(listItems[i]);

            }
        }


    }
}
