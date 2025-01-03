﻿using SavingsBook;
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
    public partial class ucQuanLyPhieu : UserControl
    {
        public ucQuanLyPhieu()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ThemPhieu editCustomerInfor = new ThemPhieu();
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
                listItems[i].Ten1 = "Tên khách hàng " + i;
                listItems[i].Ten2 = "Mã khách hàng " + i;
                listItems[i].Ten3 = "Loại kỳ hạn " + i;
                listItems[i].Ten4 = "";
                //listItems[i].btnCustom.Text = "Xem";
                listItems[i].FormType = ObjectType.PhieuGoiTien;

                //listItems[i].ButtonClick += ListItem_ButtonClick;


                flowLayoutPanel1.Controls.Add(listItems[i]);
            }

            flowLayoutPanel1.Resize += (s, e) =>
            {
                foreach (ListItem item in flowLayoutPanel1.Controls)
                {
                    item.Width = flowLayoutPanel1.ClientSize.Width;
                }
            };

        }
    }
}
