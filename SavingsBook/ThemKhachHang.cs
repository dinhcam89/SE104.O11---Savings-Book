using BUS;
using DTO;
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
    public partial class ThemKhachHang : Form
    {
        private KhachHangBUS khachHangBUS = new KhachHangBUS();
        public delegate void UpdateKhachHangListHandler();
        public event UpdateKhachHangListHandler OnKhachHangAdded;
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
            try
            {
                if (string.IsNullOrWhiteSpace(txtSoDuBanDau.Text))
                {
                    MessageBox.Show("Vui lòng nhập số dư!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtSoDuBanDau.Text))
                {
                    MessageBox.Show("Vui lòng nhập số dư ban đầu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Loại bỏ các ký tự định dạng không hợp lệ (như dấu phẩy) trước khi kiểm tra
                string soDuText = txtSoDuBanDau.Text.Replace(",", "").Trim();

                if (!int.TryParse(soDuText, out int soDuHienCo))
                {
                    MessageBox.Show("Số dư phải là một số nguyên hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (soDuHienCo < 0)
                {
                    MessageBox.Show("Số dư phải lớn hơn hoặc bằng 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                KhachHang khachHang = new KhachHang
                {
                    TenKhachHang = txtTenKhachHang.Text,
                    SoDienThoai = txtSDT.Text,
                    CCCD = txtCMND.Text,
                    DiaChi = txtDiaChi.Text,
                    NgaySinh = DTPNgaySinh.Value,
                    SoDuHienCo = soDuHienCo // Lấy giá trị số dư đã chuyển đổi
                };

                bool isAdded = khachHangBUS.ThemKhachHang(khachHang);

                if (isAdded)
                {
                    MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OnKhachHangAdded?.Invoke();

                    this.Close();
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

        private void txtSoDuBanDau_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

