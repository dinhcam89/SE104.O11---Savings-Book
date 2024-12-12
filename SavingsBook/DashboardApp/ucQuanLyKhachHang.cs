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
    public partial class ucQuanLyKhachHang : UserControl
    {
        public ucQuanLyKhachHang()
        {
            InitializeComponent();
        }


        private void ucManageCustomers_Load(object sender, EventArgs e)
        {
            populateItems();

        }

        private void populateItems()
        {
            ListItem[] listItems = new ListItem[10];

            for (int i = 0; i < listItems.Length; i++)
            {
                listItems[i] = new ListItem();
                listItems[i].Ten1 = "Tên khách hàng " + i;
                listItems[i].Ten2 = "Mã khách hàng " + i;
                listItems[i].Ten3 = "Số dư " + i;
                listItems[i].Ten4 = "Số phiếu tiết kiệm " + i;

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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ThemKhachHang addSavingBooks = new ThemKhachHang();
            addSavingBooks.Show();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            ThongTinKhachHang customerInfor = new ThongTinKhachHang();
            customerInfor.Show();
        }
    }
}
