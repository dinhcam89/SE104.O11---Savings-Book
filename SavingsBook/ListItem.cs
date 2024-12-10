using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public enum ObjectType
{
    KhachHang,
    PhieuGoiTien,
    ChiTietRutTien,
    LoaiTietKiem
}

namespace GUI
{
    public partial class ListItem : UserControl
    {
        public event EventHandler ButtonClick;
        public int clickCount = 0;

        public ListItem()
        {
            InitializeComponent();
        }

        private string _name;
        private string _id;
        private string _type;
        private Image _image;
        private ObjectType _formType;

        [Category("Custom")]
        private void btnCustom_Click(object sender, EventArgs e)
        {
            // Lấy đối tượng ListItem từ nút được click
            var button = sender as Guna2GradientButton;

            if (button != null)
            {
                Point screenPoint = button!.PointToScreen(new Point(0, button.Height));

                switch (_formType)
                {
                    case ObjectType.KhachHang:
                        CMSKhachHang cmsKhachHang = new CMSKhachHang();
                        cmsKhachHang.Show(screenPoint);
                        break;
                    case ObjectType.ChiTietRutTien:
                        CMSChiTietRutTien cmsChiTietRutTien = new CMSChiTietRutTien();
                        cmsChiTietRutTien.Show(screenPoint);
                        break;
                    case ObjectType.PhieuGoiTien:
                        CMSPhieuGoiTien cmsPhieuGoiTien = new CMSPhieuGoiTien();
                        cmsPhieuGoiTien.Show(screenPoint);
                        break;
                    case ObjectType.LoaiTietKiem:
                        CMSLoaiTietKiem cmsLoaiTietKiem = new CMSLoaiTietKiem();
                        cmsLoaiTietKiem.Show(screenPoint);
                        break;
                    default:
                        MessageBox.Show("Thông tin loại form không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
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

        // Property: Form type
        [Category("Custom")]
        [Description("Thiết lập context menu strip nút options")]
        public ObjectType FormType
        {
            get => _formType;
            set => _formType = value;
        }

    }
}
