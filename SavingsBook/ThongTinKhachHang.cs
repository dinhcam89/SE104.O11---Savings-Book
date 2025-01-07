using DTO;
using BUS;
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
    public partial class ThongTinKhachHang : Form
    {
        private Action _reload;
        public ThongTinKhachHang(Action reload)
        {
            InitializeComponent();
            //customizeDesign();
            // Thiết lập không cho phép thay đổi kích thước Form
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            _reload = reload;

        }
        public void LoadThongTinKhachHang(KhachHang khachHang)
        {
            lblHoTen.Text = khachHang.TenKhachHang;
            lblSDT.Text = khachHang.SoDienThoai;
            lblCMND.Text = khachHang.CCCD;
            lblNgaySinh.Text = khachHang.NgaySinh.ToString("dd/MM/yyyy") ?? "Chưa cập nhật";
            lblDiaChi.Text = khachHang.DiaChi ?? "Chưa cập nhật";
            lblSTKThanhToan.Text = khachHang.SoTaiKhoanThanhToan;
            lblSoDuHienCo.Text = khachHang.SoDuHienCo.ToString("N0");
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

        private void btnSua_Click(object sender, EventArgs e)
        {

            if (btnSua.Text == "Sửa")
            {
                ToggleToEditMode(lblHoTen, txtHoTen);
                ToggleToEditMode(lblSDT, txtSoDienThoai);
                ToggleToEditMode(lblCMND, txtCCCD);
                ToggleToEditMode(lblNgaySinh, dtpNgaySinh);
                ToggleToEditMode(lblDiaChi, txtDiaChi);
                ToggleToEditMode(lblSoDuHienCo, txtSoDuHienCo);

                btnSua.Text = "Cập nhật";
            }
            else
            {
                SaveFromEditor(lblHoTen, txtHoTen);
                SaveFromEditor(lblSDT, txtSoDienThoai);
                SaveFromEditor(lblCMND, txtCCCD);
                SaveFromEditor(lblNgaySinh, dtpNgaySinh);
                SaveFromEditor(lblDiaChi, txtDiaChi);
                SaveFromEditor(lblSoDuHienCo, txtSoDuHienCo);

                // Cập nhật thông tin khách hàng vào db
                bool res = new KhachHangBUS().CapNhatKhachHang(new KhachHang
                {
                    SoTaiKhoanThanhToan = lblSTKThanhToan.Text,
                    TenKhachHang = lblHoTen.Text,
                    SoDienThoai = lblSDT.Text,
                    CCCD = lblCMND.Text,
                    NgaySinh = DateTime.Parse(lblNgaySinh.Text),
                    DiaChi = lblDiaChi.Text,
                    SoDuHienCo = double.Parse(lblSoDuHienCo.Text)
                });

                if (res)
                {
                    MessageBox.Show("Cập nhật thông tin khách hàng thành công");
                    _reload();
                    Close();
                }
                else
                {
                    MessageBox.Show("Cập nhật thông tin khách hàng thất bại");
                }

                btnSua.Text = "Sửa";
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblMaKhachHang_Click(object sender, EventArgs e)
        {

        }
    }
}