using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
<<<<<<< HEAD

=======
using DTO;
using BUS;
>>>>>>> b9113d9 (Initial commit)
namespace GUI
{
    public partial class ThemKhachHang : Form
    {
<<<<<<< HEAD
=======
        private KhachHangBUS khachHangBUS = new KhachHangBUS();
>>>>>>> b9113d9 (Initial commit)
        public ThemKhachHang()
        {
            InitializeComponent();
            //customizeDesign();
            // Thiết lập không cho phép thay đổi kích thước Form
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
=======
            try
            {
                KhachHangDTO khachHang = new KhachHangDTO
                {

                    TenKhachHang = txtTenKhachHang.Text,
                    SoDienThoai = txtSDT.Text,
                    CCCD = txtCMND.Text,
                    DiaChi = txtDiaChi.Text,
                    NgaySinh = DTPNgaySinh.Value,
                };

                bool isAdded = khachHangBUS.ThemKhachHang(khachHang);

                if (isAdded)
                {
                    MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm khách hàng thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblSDT0_Click(object sender, EventArgs e)
        {
>>>>>>> b9113d9 (Initial commit)

        }
    }
}

