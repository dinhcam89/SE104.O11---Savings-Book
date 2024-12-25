using System;
using System.Windows.Forms;
using DTO;
using BUS;
using DAO;

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
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtSoDu.Text))
                {
                    MessageBox.Show("Vui lòng nhập số dư!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!float.TryParse(txtSoDu.Text, out float soDuHienCo) || soDuHienCo < 0)
                {
                    MessageBox.Show("Số dư phải là một số hợp lệ lớn hơn hoặc bằng 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
