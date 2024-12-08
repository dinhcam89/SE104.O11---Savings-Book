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

            contextMenuStrip1 = new ContextMenuStrip();
            contextMenuStrip1.Items.Add("Quản lý");
            contextMenuStrip1.Items.Add("Gửi tiền");
            contextMenuStrip1.Items.Add("Rút tiền");
            contextMenuStrip1.Items.Add("Xóa");

            contextMenuStrip1.ItemClicked += contextMenuStrip1_ItemClick;

            foreach (var item in flowLayoutPanel1.Controls.OfType<ListItem>())
            {
                item.ButtonClick += ListItem_ButtonClick;
            }
        }

        private ContextMenuStrip contextMenuStrip1;


        private void btnCustomer11_Click(object sender, EventArgs e)
        {
            SlotInfor slotInfor = new SlotInfor();
            slotInfor.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddSlot editCustomerInfor = new AddSlot();
            editCustomerInfor.Show();
        }

        private void ucManageSavingBooks_Load(object sender, EventArgs e)
        {
            populateItems();

        }

        private void ListItem_ButtonClick(object sender, EventArgs e)
        {
            // Tạo và hiển thị ContextMenuStrip
            //ListItem item = sender as ListItem;
            //Point screenPoint = item.PointToScreen(new Point(0, item.Height));
            //contextMenuStrip1.Show(screenPoint);

            ListItem item = sender as ListItem;
            if (item != null)
            {
                Point screenPoint = item.PointToScreen(new Point(0, item.Height));
                contextMenuStrip1.Show(screenPoint);
            }
        }

        private void contextMenuStrip1_ItemClick(object sender, ToolStripItemClickedEventArgs e)
        {
            // Xử lý khi chọn item trong menu
            switch (e.ClickedItem.Text)
            {
                case "Quản lý":
                    OpenManagementForm();
                    break;
                case "Gửi tiền":
                    OpenDepositForm();
                    break;
                case "Rút tiền":
                    OpenWithdrawalForm();
                    break;
                case "Xóa":
                    DeleteItem();
                    break;
            }
        }


        private void OpenManagementForm()
        {
            SlotInfor slotInfor = new SlotInfor();
            slotInfor.Show();
        }

        private void OpenDepositForm()
        {
            DepositReceiptForm form = new DepositReceiptForm();
            form.Show();
        }

        private void OpenWithdrawalForm()
        {
            WithdrawalReceiptForm form = new WithdrawalReceiptForm();
            form.Show();
        }

        private void DeleteItem()
        {
            //thêm hàm xóa vào đây nhé Conal
            MessageBox.Show("Item đã được xóa.");
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
                //listItems[i].btnCustom.Text = "Xem";

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




        private void btnGuiTien_Click(object sender, EventArgs e)
        {
            DepositReceiptForm form = new DepositReceiptForm();
            form.Show();
        }

        private void btnRutTien_Click(object sender, EventArgs e)
        {
            WithdrawalReceiptForm form = new WithdrawalReceiptForm();
            form.Show();
        }
    }
}
