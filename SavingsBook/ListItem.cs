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
    public partial class ListItem : UserControl
    {
        public event EventHandler ButtonClick;

        public ListItem()
        {
            InitializeComponent();
            //btnCustom.Click += (s, e) => ButtonClick?.Invoke(this, e);


            contextMenuStrip1 = new ContextMenuStrip();
            contextMenuStrip1.Items.Add("Quản lý");
            contextMenuStrip1.Items.Add("Gửi tiền");
            contextMenuStrip1.Items.Add("Rút tiền");
            contextMenuStrip1.Items.Add("Xóa");

            btnCustom.Click += (s, e) =>
            {
                Point screenPoint = this.PointToScreen(new Point(0, this.Height));
                contextMenuStrip1.Show(screenPoint);
            };
        }

        private string _name;
        private string _id;
        private string _type;
        private Image _image;

        [Category("Custom")]
        private void btnCustom_Click(object sender, EventArgs e)
        {

            // Lấy ListItem chứa nút và tính toán vị trí để hiển thị ContextMenuStrip
            //ListItem item = sender as ListItem;
            //Point screenPoint = item.PointToScreen(new Point(0, item.Height));
            //contextMenuStrip1.Show(screenPoint);

            // Lấy đối tượng ListItem từ nút được click
            var button = sender as Button;
            var item = button?.Parent as ListItem;

            if (item != null)
            {
                Point screenPoint = item.PointToScreen(new Point(0, item.Height));
                contextMenuStrip1.Show(screenPoint);
            }
            else
            {
                MessageBox.Show("Không thể lấy thông tin từ item!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        [Category("Custom")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string CustomerName
        {
            get { return _name; }
            set { _name = value; lblCustomerName.Text = value; }
        }

        [Category("Custom")]
        public string Id
        {
            get { return _id; }
            set { _id = value; lblIDNumber.Text = value; }
        }

        [Category("Custom")]
        public string Type
        {
            get { return _type; }
            set { _type = value; lblType.Text = value; }
        }

        [Category("Custom")]
        public Image Avatar
        {
            get { return _image; }
            set { _image = value; picAvatar.Image = value; }
        }

    }
}
