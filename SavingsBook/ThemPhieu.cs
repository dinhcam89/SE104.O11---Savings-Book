using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
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

            // Gọi hàm tải dữ liệu từ database
            LoadLoaiTietKiemToComboBox();

            // Thêm các mục hình thức gia hạn với Text và Value
            cboxHinhThucGiaHan.Items.Add(new { Text = "Không gia hạn", Value = 0 });
            cboxHinhThucGiaHan.Items.Add(new { Text = "Xoay vòng gốc", Value = 1 });
            cboxHinhThucGiaHan.Items.Add(new { Text = "Xoay vòng gốc lẫn lãi", Value = 2 });

            cboxHinhThucGiaHan.DisplayMember = "Text";
            cboxHinhThucGiaHan.ValueMember = "Value";
            cboxHinhThucGiaHan.SelectedIndex = 0; // Mặc định chọn mục đầu tiên
            DTPNgayGoi.Format = DateTimePickerFormat.Custom;
            DTPNgayGoi.CustomFormat = "MM/dd/yyyy";
            DTPNgayGoi.Value = DateTime.Now; //
        }

        public ThemPhieu(string soTaiKhoanThanhToan) : this()
        {
            this.soTaiKhoanThanhToan = soTaiKhoanThanhToan;
            txtMaKhachHang.Text = soTaiKhoanThanhToan; // Tự động điền số tài khoản thanh toán
            txtMaKhachHang.Enabled = false; // Không cho phép sửa
        }

        private void LoadLoaiTietKiemToComboBox()
        {
            try
            {
                // Gọi từ BUS để lấy danh sách LoaiTietKiem
                LoaiTietKiemBUS loaiTietKiemBUS = new LoaiTietKiemBUS();
                List<LoaiTietKiem> dsLoaiTietKiem = loaiTietKiemBUS.getListLoaiTietKiem();

                // Gán dữ liệu vào ComboBox
                cboxKyHan.DataSource = dsLoaiTietKiem;
                cboxKyHan.DisplayMember = "KyHan"; // Hiển thị kỳ hạn
                cboxKyHan.ValueMember = "MaLoaiTietKiem"; // Giá trị là mã loại tiết kiệm
                cboxKyHan.SelectedIndexChanged += cboxKyHan_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboxKyHan_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboxKyHan.SelectedItem is LoaiTietKiem selectedLoaiTietKiem)
                {
                    // Cập nhật lãi suất hiển thị
                    txtLaiSuatApDung.Text = $"Lãi suất: {selectedLoaiTietKiem.LaiSuat}%";
                }
            }
            catch
            {
                txtLaiSuatApDung.Text = "Lãi suất: 0%"; // Mặc định nếu không khớp
            }
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            ThamSo thamSo = new ThamSoBUS().getThamSo();
            try
            {
                if (cboxKyHan.SelectedItem is not LoaiTietKiem selectedLoaiTietKiem)
                {
                    MessageBox.Show("Vui lòng chọn kỳ hạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                dynamic selectedHinhThucGiaHan = cboxHinhThucGiaHan.SelectedItem;
                int hinhThucGiaHan = selectedHinhThucGiaHan.Value;

                DateTime ngayGoi = DTPNgayGoi.Value;
                if (!double.TryParse(txtTongTienGoc.Text, out double tongTienGoc) || tongTienGoc < thamSo.SoTienBanDauToiThieu)
                {
                    MessageBox.Show("Vui lòng nhập số tiền gửi hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                PhieuGoiTien phieuGoiTien = new PhieuGoiTien
                {
                    SoTaiKhoanThanhToan = soTaiKhoanThanhToan,
                    MaLoaiTietKiem = selectedLoaiTietKiem.MaLoaiTietKiem,
                    NgayGoi = ngayGoi,
                    TongTienGoc = Convert.ToSingle(tongTienGoc),
                    HinhThucGiaHan = hinhThucGiaHan,
                    LaiSuatApDung = Convert.ToSingle(selectedLoaiTietKiem.LaiSuat),
                    LaiSuatPhatSinh = Convert.ToSingle(selectedLoaiTietKiem.LaiSuat),
                    TongTienLaiPhatSinh = Convert.ToSingle(Math.Round(tongTienGoc * (1 + selectedLoaiTietKiem.LaiSuat / 100), 2))
                };

                PhieuGoiTienBUS bus = new PhieuGoiTienBUS();
                if (bus.ThemPhieuGoiTien(phieuGoiTien))
                {
                    MessageBox.Show("Thêm phiếu gửi tiền thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Đóng form
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

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close(); // Đóng form
        }
    }
}
