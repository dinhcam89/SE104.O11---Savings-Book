using BUS;
using DTO;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class ThemPhieu : Form
    {
        private string soTaiKhoanThanhToan;

        public ThemPhieu()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Không cho phép thay đổi kích thước

            // Thêm các mục kỳ hạn với Text và Value
            cboxKyHan.Items.Add(new KeyValuePair<string, int>("Không kỳ hạn", 1));
            cboxKyHan.Items.Add(new KeyValuePair<string, int>("3 tháng", 7));
            cboxKyHan.Items.Add(new KeyValuePair<string, int>("6 tháng", 8));

            cboxKyHan.DisplayMember = "Key"; // Hiển thị `Key` (Text)
            cboxKyHan.ValueMember = "Value"; // Sử dụng `Value` trong xử lý
            cboxKyHan.SelectedIndex = 0;
            cboxKyHan.SelectedIndexChanged += cboxKyHan_SelectedIndexChanged;


            // Cấu hình hiển thị Text và xử lý Value
            cboxKyHan.DisplayMember = "Key";
            cboxKyHan.ValueMember = "Value";
           

            // Thêm các mục hình thức gia hạn với Text và Value
            cboxHinhThucGiaHan.Items.Add(new { Text = "Không gia hạn", Value = 0 });
            cboxHinhThucGiaHan.Items.Add(new { Text = "Xoay vòng gốc", Value = 1 });
            cboxHinhThucGiaHan.Items.Add(new { Text = "Xoay vòng gốc lẫn lãi", Value = 2 });

            cboxHinhThucGiaHan.DisplayMember = "Text";
            cboxHinhThucGiaHan.ValueMember = "Value";
            cboxHinhThucGiaHan.SelectedIndex = 0; // Mặc định chọn mục đầu tiên
        }
        private void cboxKyHan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxKyHan.SelectedItem is KeyValuePair<string, int> selectedPair)
            {
                int value = selectedPair.Value;

                // Hiển thị lãi suất dựa trên Value
                double laiSuat = value switch
                {
                    1 => 5.0,   // Không kỳ hạn
                    7 => 3.5,   // 3 tháng
                    8 => 4.2,   // 6 tháng
                    _ => 0.0    // Mặc định nếu không khớp
                };

                lblLaiSuat.Text = $"Lãi suất: {laiSuat}%";
            }
        }
        public ThemPhieu(string soTaiKhoanThanhToan) : this()
        {
            this.soTaiKhoanThanhToan = soTaiKhoanThanhToan;
            txtSoTaiKhoanThanhToan.Text = soTaiKhoanThanhToan; // Tự động điền số tài khoản thanh toán
            txtSoTaiKhoanThanhToan.Enabled = false; // Không cho phép sửa
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close(); // Đóng form
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra kỳ hạn
                if (cboxKyHan.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn kỳ hạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                dynamic selectedKyHan = cboxKyHan.SelectedItem;
                int kyHan = selectedKyHan.Value;
                string kyHanText = selectedKyHan.Text;

                // Kiểm tra hình thức gia hạn
                if (cboxHinhThucGiaHan.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn hình thức gia hạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                double laiSuat = kyHanText switch
                {
                    "Không kỳ hạn" => 5.0,
                    "3 tháng" => 3.5,
                    "6 tháng" => 4.2,
                    _ => 0.0 // Mặc định nếu không khớp
                };

                // Hiển thị lãi suất vào lblLaiSuat
                lblLaiSuat.Text = $"{laiSuat}%";
                dynamic selectedHinhThucGiaHan = cboxHinhThucGiaHan.SelectedItem;
                int hinhThucGiaHan = selectedHinhThucGiaHan.Value;
                string hinhThucGiaHanText = selectedHinhThucGiaHan.Text;

                // Lấy giá trị ngày gửi và số tiền gửi
                DateTime ngayGoi = DTPNgayGoi.Value;
                if (!double.TryParse(txtTongTienGui.Text, out double tongTienGoc) || tongTienGoc <= 0)
                {
                    MessageBox.Show("Vui lòng nhập số tiền gửi hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo đối tượng DTO
                PhieuGoiTien phieuGoiTien = new PhieuGoiTien
                {
                    SoTaiKhoanThanhToan = soTaiKhoanThanhToan,
                    NgayGoi = ngayGoi,
                    TongTienGoc = tongTienGoc,
                    HinhThucGiaHan = hinhThucGiaHan
                };

                // Xử lý thêm phiếu gửi tiền qua BUS
                PhieuGoiTienBUS bus = new PhieuGoiTienBUS();
                double laiSuatApDung = bus.GetLaiSuatByKyHan(kyHan);

                phieuGoiTien.LaiSuatApDung = laiSuatApDung;
                phieuGoiTien.LaiSuatPhatSinh = laiSuatApDung;
                phieuGoiTien.TongTienLaiPhatSinh = Math.Round(tongTienGoc * (1 + laiSuatApDung / 100), 2);

                string chiTietGuiTien = $"Chi tiết gửi tiền:\n" +
                                        $"- Số tài khoản thanh toán: {soTaiKhoanThanhToan}\n" +
                                        $"- Kỳ hạn: {kyHanText}\n" +
                                        $"- Hình thức gia hạn: {hinhThucGiaHanText}\n" +
                                        $"- Ngày gửi: {ngayGoi}\n" +
                                        $"- Tổng tiền gửi: {tongTienGoc}\n" +
                                        $"- Lãi suất áp dụng: {laiSuatApDung}%\n" +
                                        $"- Tổng tiền lãi phát sinh: {phieuGoiTien.TongTienLaiPhatSinh}";

                MessageBox.Show(chiTietGuiTien, "Chi Tiết Gửi Tiền");

                if (bus.ThemPhieuGoiTien(phieuGoiTien, soTaiKhoanThanhToan, kyHan))
                {
                    MessageBox.Show("Thêm phiếu gửi tiền thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Đóng form sau khi thêm thành công
                }
                else
                {
                    MessageBox.Show("Thêm phiếu gửi tiền thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
