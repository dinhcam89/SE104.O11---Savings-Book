using DTO;
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
        private LoaiTietKiem _loaiTietKiem;
        private Action reload;

        public ListItem()
        {
            InitializeComponent();
        }
        public ListItem(LoaiTietKiem ltk, Action reload)
        {
            InitializeComponent();
            _loaiTietKiem = ltk;
            Ten1 = ltk.MaLoaiTietKiem.ToString();
            Ten2 = ltk.KyHan.ToString();
            Ten3 = ltk.LaiSuat.ToString();
            Ten4 = "";
            FormType = ObjectType.LoaiTietKiem;
            this.reload = reload;
        }

        private string _ten1;
        private string _ten2;
        private string _ten3;
        private string _ten4;
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
                        string maPhieuGoiTien = Ten2;
                        if (!string.IsNullOrEmpty(maPhieuGoiTien))
                        {
                            cmsPhieuGoiTien.maPhieuGoiTien = maPhieuGoiTien; // Gán số tài khoản thanh toán
                        }
                        cmsPhieuGoiTien.Show(screenPoint);
                        break;
                    case ObjectType.LoaiTietKiem:
                        CMSLoaiTietKiem cmsLoaiTietKiem = new CMSLoaiTietKiem(_loaiTietKiem, reload);
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
        public string Ten1
        {
            get { return _ten1; }
            set { _ten1 = value; lblTen1.Text = value; }
        }

        [Category("Custom")]
        public string Ten2
        {
            get { return _ten2; }
            set { _ten2 = value; lblTen2.Text = value; }
        }

        [Category("Custom")]
        public string Ten3
        {
            get { return _ten3; }
            set { _ten3 = value; lblTen3.Text = value; }
        }

        [Category("Custom")]
        public string Ten4
        {
            get { return _ten4; }
            set { _ten4 = value; lblTen4.Text = value; }
        }

        // Property: Form type
        [Category("Custom")]
        [Description("Thiết lập context menu strip nút options")]
        public ObjectType FormType
        {
            get => _formType;
            set => _formType = value;
        }

        [Category("Custom")]
        public bool IsButtonVisible
        {
            get { return btnTuyChon.Visible; }
            set { btnTuyChon.Visible = value; }
        }

    }
}
