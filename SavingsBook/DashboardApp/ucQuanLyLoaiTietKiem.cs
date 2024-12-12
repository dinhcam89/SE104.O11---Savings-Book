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
    public partial class ucQuanLyLoaiTietKiem : UserControl
    {
        public ucQuanLyLoaiTietKiem()
        {
            InitializeComponent();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ThemLoaiTietKiem addForm = new ThemLoaiTietKiem();
            addForm.ShowDialog();
        }

        private void ucEditAdjustRate_Load(object sender, EventArgs e)
        {
            populateItems();
        }

        private void populateItems()
        {
            ListItem[] listItems = new ListItem[5];

            for (int i = 0; i < listItems.Length; i++)
            {
                listItems[i] = new ListItem();
                listItems[i].Ten1 = "Loại tiết kiệm " + i;
                listItems[i].Ten2 = "Số tiền gởi " + i;
                listItems[i].Ten3 = "Lãi suất " + i;
                listItems[i].Ten4 = "";
                //listItems[i].btnCustom.Text = "Xem";
                listItems[i].FormType = ObjectType.LoaiTietKiem;

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
