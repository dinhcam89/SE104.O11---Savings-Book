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
    public partial class ucQuanLyChiTietRutTien : UserControl
    {
        public ucQuanLyChiTietRutTien()
        {
            InitializeComponent();
        }

        private void ucQuanLyChiTietRutTien_Load(object sender, EventArgs e)
        {
            populateItems();
        }

        private void populateItems()
        {
            ListItem[] listItems = new ListItem[20];

            for (int i = 0; i < listItems.Length; i++)
            {
                listItems[i] = new ListItem();
                listItems[i].Ten1 = "Mã phiếu " + i;
                listItems[i].Ten2 = "Ngày rút " + i;
                listItems[i].Ten3 = "Số tiền rút " + i;
                listItems[i].Ten4 = "";

                listItems[i].FormType = ObjectType.PhieuGoiTien;

                listItems[i].IsButtonVisible = false; // Ẩn nút

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
