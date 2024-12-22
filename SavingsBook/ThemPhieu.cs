<<<<<<< HEAD
﻿using System;
=======
﻿using BUS;
using DTO;
using System;
>>>>>>> b9113d9 (Initial commit)
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
    public partial class ThemPhieu : Form
    {
        public ThemPhieu()
        {
            InitializeComponent();
            // Thiết lập không cho phép thay đổi kích thước Form
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

<<<<<<< HEAD
            string[] hinhThucGiaHan = { "Không gia hạn", "Xoay vòng gốc", "Xoay vòng gốc lẫn lãi" };
            cboxHinhThucGiaHan.Items.AddRange(hinhThucGiaHan);

            string[] kyHan = { "Không kỳ hạn", "3 tháng", "6 tháng" };
            cboxKyHan.Items.AddRange(kyHan);
=======


            // Thêm các mục kỳ hạn với Text và Value
            cboxKyHan.Items.Add(new { Text = "Không kỳ hạn", Value = 1 });
            cboxKyHan.Items.Add(new { Text = "3 tháng", Value = 7 });
            cboxKyHan.Items.Add(new { Text = "6 tháng", Value = 8 });

            // Cấu hình để hiển thị Text và xử lý Value
            cboxKyHan.DisplayMember = "Text";
            cboxKyHan.ValueMember = "Value";
            // Đặt mục mặc định cho kỳ hạn
            if (cboxKyHan.Items.Count > 0)
                cboxKyHan.SelectedIndex = 0;

            // Thêm các mục hình thức gia hạn với Text và Value
            cboxHinhThucGiaHan.Items.Add(new { Text = "Không gia hạn", Value = 0 }); // Không gia hạn: 0
            cboxHinhThucGiaHan.Items.Add(new { Text = "Xoay vòng gốc", Value = 1 });  // Xoay vòng gốc: 1
            cboxHinhThucGiaHan.Items.Add(new { Text = "Xoay vòng gốc lẫn lãi", Value = 2 }); // Xoay vòng gốc lẫn lãi: 2

            // Cấu hình ComboBox để hiển thị Text và sử dụng Value
            cboxHinhThucGiaHan.DisplayMember = "Text";
            cboxHinhThucGiaHan.ValueMember = "Value";

            // Đặt mục mặc định cho hình thức gia hạn
            if (cboxHinhThucGiaHan.Items.Count > 0)
                cboxHinhThucGiaHan.SelectedIndex = 0;
>>>>>>> b9113d9 (Initial commit)
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD

        }
    }
}
=======
            try
            {
                // Lấy Mã Loại Tiết Kiệm từ ComboBox Kỳ hạn
                if (cboxKyHan.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn kỳ hạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                dynamic selectedKyHan = cboxKyHan.SelectedItem;
                int kyHan = selectedKyHan.Value;
                string kyHanText = selectedKyHan.Text; // Lấy text để hiển thị (VD: "3 tháng")

                // Lấy Hình Thức Gia Hạn từ ComboBox
                if (cboxHinhThucGiaHan.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn hình thức gia hạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                dynamic selectedHinhThucGiaHan = cboxHinhThucGiaHan.SelectedItem;
                int hinhThucGiaHan = selectedHinhThucGiaHan.Value;
                string hinhThucGiaHanText = selectedHinhThucGiaHan.Text; // Lấy text để hiển thị (VD: "Không gia hạn")

                // Lấy các giá trị khác từ giao diện
                int maKhachHang = int.Parse(txtMaKhachHang.Text);

                DateTime ngayGoi = DTPNgayGoi.Value;
                double tongTienGoc = double.Parse(txtTongTienGui.Text);

                // Tạo đối tượng DTO
                PhieuGoiTienDTO phieuGoiTien = new PhieuGoiTienDTO
                {
                    NgayGoi = ngayGoi,
                    TongTienGoc = tongTienGoc,
                    HinhThucGiaHan = hinhThucGiaHan
                };

                // Gọi BUS để xử lý
                PhieuGoiTienBUS bus = new PhieuGoiTienBUS();
                double laiSuatApDung = bus.GetLaiSuatByKyHan(kyHan);
                phieuGoiTien.LaiSuatApDung = laiSuatApDung;
                phieuGoiTien.LaiSuatPhatSinh = laiSuatApDung;
                phieuGoiTien.TongTienLaiPhatSinh = Math.Round(tongTienGoc * (1 + laiSuatApDung / 100), 2); // Làm tròn 2 chữ số thập phân

                // Debug thông tin chi tiết
                string chiTietGuiTien = $"Chi tiết gửi tiền:\n" +
                                        $"- Mã khách hàng: {maKhachHang}\n" +
                                        $"- Kỳ hạn: {kyHanText}\n" +
                                        $"- Hình thức gia hạn: {hinhThucGiaHanText}\n" +
                                        $"- Ngày gửi: {ngayGoi}\n" +
                                        $"- Tổng tiền gửi: {tongTienGoc}\n" +
                                        $"- Lãi suất phát sinh: {laiSuatApDung}%\n" +
                                        $"- Tổng tiền lãi phát sinh: {phieuGoiTien.TongTienLaiPhatSinh}";
                MessageBox.Show(chiTietGuiTien, "Chi Tiết Gửi Tiền");

                bool isAdded = bus.ThemPhieuGoiTien(phieuGoiTien, maKhachHang, kyHan);

                if (isAdded)
                {
                    MessageBox.Show("Thêm phiếu gửi tiền thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm phiếu gửi tiền thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Dữ liệu nhập không đúng định dạng. Vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    }

>>>>>>> b9113d9 (Initial commit)
