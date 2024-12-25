using BUS;
using DTO;
using GUI;

namespace SavingsBook
{
    public partial class ThongTinPhieu : Form
    {
        public ThongTinPhieu()
        {
            InitializeComponent();
            // Thiet lap khong thay doi kich thuoc form
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            string[] hinhThucGiaHan = { "Không gia hạn", "Xoay vòng gốc", "Xoay vòng gốc lẫn lãi" };
            cboxHinhThucGiaHan.Items.AddRange(hinhThucGiaHan);

            string[] kyHan = { "Không kỳ hạn", "3 tháng", "6 tháng" };
            cboxKyHan.Items.AddRange(kyHan);
        }

        public void HienThiThongTinPhieu(string soTaiKhoanTienGoi)
        {
            var phieuGoiTienBUS = new PhieuGoiTienBUS();
            var phieu = phieuGoiTienBUS.LayPhieuGoiTien(soTaiKhoanTienGoi);

            if (phieu != null)
            {
                lblSTKTienGoi.Text = phieu.SoTaiKhoanTienGoi;
                lblSTKThanhToan.Text = phieu.SoTaiKhoanThanhToan;
                lblKyHan.Text = phieu.MaLoaiTietKiem switch
                {
                    "LTK0000000" => "3 tháng",
                    "LTK0000001" => "6 tháng",
                    "LTK0000002" => "9 tháng",
                    _ => "Không xác định"
                };
                lblLaiSuatApDung.Text = $"{Math.Round(phieu.LaiSuatApDung * 100, 2):N2}%"; // Làm tròn 2 chữ số thập phân
                lblLaiSuatPhatSinh.Text = $"{Math.Round(phieu.LaiSuatPhatSinh * 100, 2):N2}%"; // Làm tròn 2 chữ số thập phân
                lblNgayGoi.Text = phieu.NgayGoi.ToString("dd/MM/yyyy");
                lblNgayDaoHanKeTiep.Text = phieu.NgayDaoHanKeTiep.ToString("dd/MM/yyyy");
                lblTongTienGoc.Text = $"{phieu.TongTienGoc:N0}";
                lblTongTienLaiPhatSinh.Text = $"{phieu.TongTienLaiPhatSinh:N0}";
                lblHinhThucGiaHan.Text = phieu.HinhThucGiaHan == 0
                    ? "Không gia hạn"
                    : "Xoay vòng cả gốc lẫn lãi";
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin phiếu gửi tiền!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnSua.Text == "Sửa")
            {
                //ToggleToEditMode(lblLaiSuatPhatSinh, txtLaiSuatPhatSinh);
                //ToggleToEditMode(lblLaiSuatApDung, txtLaiSuatApDung);
                ToggleToEditMode(lblKyHan, cboxKyHan);
                ToggleToEditMode(lblHinhThucGiaHan, cboxHinhThucGiaHan);

                btnSua.Text = "Cập nhật";
            }
            else
            {
                //SaveFromEditor(lblLaiSuatPhatSinh, txtLaiSuatPhatSinh);
                //SaveFromEditor(lblLaiSuatApDung, txtLaiSuatApDung);
                SaveFromEditor(lblKyHan, cboxKyHan);
                SaveFromEditor(lblHinhThucGiaHan, cboxHinhThucGiaHan);

                btnSua.Text = "Sửa";
            }
        }



        private void ToggleToEditMode(Label lbl, Control editor)
        {
            lbl.Visible = false;
            editor.Visible = true;

            if (editor is Guna.UI2.WinForms.Guna2TextBox txt)
            {
                txt.Text = lbl.Text;
                txt.Focus();
            }
            else if (editor is ComboBox cbox)
            {
                cbox.Text = lbl.Text;
                cbox.Focus();
            }
        }



        private void SaveFromEditor(Label lbl, Control editor)
        {
            if (editor is Guna.UI2.WinForms.Guna2TextBox txt)
            {
                lbl.Text = txt.Text;
            }
            else if (editor is ComboBox cbox)
            {
                lbl.Text = cbox.Text;
            }

            editor.Visible = false;
            lbl.Visible = true;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
