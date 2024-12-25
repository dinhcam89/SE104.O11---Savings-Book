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
    public partial class ChiTietRutTien : Form
    {
        public string maPhieuGoiTien;
        public ChiTietRutTien()
        {
            InitializeComponent();
        }
        public ChiTietRutTien(string maPhieuGoiTien) : this()
        {
            this.maPhieuGoiTien = maPhieuGoiTien;
             // Tự động điền số tài khoản thanh toán

        }
        private void ChiTietRutTien_Load(object sender, EventArgs e)
        {
            lb_MaPhieu.Text = "01234";
            populateItems();
        }

        private void populateItems()
        {
            ListItem[] listItems = new ListItem[20];

            for (int i = 0; i < listItems.Length; i++)
            {
                listItems[i] = new ListItem();
                listItems[i].Ten1 = "Ngày rút " + i;
                listItems[i].Ten2 = "Số tiền " + i;
                listItems[i].Ten3 = "";
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
