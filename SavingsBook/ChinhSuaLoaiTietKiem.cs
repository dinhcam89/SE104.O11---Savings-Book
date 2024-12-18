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
    public partial class ChinhSuaLoaiTietKiem : Form
    {
        public ChinhSuaLoaiTietKiem(LoaiTietKiem ltk)
        {
            InitializeComponent();

            // Gán các giá trị từ DTO vào các Label
            if (ltk.KyHan == 0)
            {
                lblLoaiKyHan.Text = "Không kỳ hạn";
            }
            else
            {
                var formatedKyHan = formatDaysToMonths(ltk.KyHan);
                if (formatedKyHan.days == 0)
                {
                    lblLoaiKyHan.Text = $"{formatedKyHan.months} tháng";
                }
                else
                {
                    lblLoaiKyHan.Text = $"{ltk.KyHan} ngày";
                }
            }
            lblLaiSuat.Text = ltk.LaiSuat.ToString();
            lblThoiGianGuiToiThieu.Text = ltk.SoNgayToiThieuDuocRutTien.ToString();
            if (ltk.QuyDinhSoTienRut != null)
            {
                if (ltk.QuyDinhSoTienRut == "=")
                {
                    lblInputQuyDinhSoTienRut.Text = "Toàn phần";
                }
                else
                {
                    lblInputQuyDinhSoTienRut.Text = "Một phần hoặc toàn phần";
                }
            }
        }
        (int months, int days) formatDaysToMonths(int days)
        {
            return (days / 30, days % 30);
        }


        // Chuyển Label thành TextBox
        private void ToggleToEditMode(Label lbl, Guna.UI2.WinForms.Guna2TextBox txt)
        {
            lbl.Visible = false;
            txt.Visible = true;
            txt.Text = lbl.Text;
            txt.Focus();
        }

        // Lưu nội dung từ TextBox vào Label và ẩn TextBox
        private void SaveFromTextBox(Label lbl, Guna.UI2.WinForms.Guna2TextBox txt)
        {
            lbl.Text = txt.Text;
            txt.Visible = false;
            lbl.Visible = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (btnSua.Text == "Sửa")
            {
                ToggleToEditMode(lblLaiSuat, txtLaiSuat);
                ToggleToEditMode(lblThoiGianGuiToiThieu, txtThoiGianGuiToiThieu);
                ToggleToEditMode(lblInputQuyDinhSoTienRut, txtSoTienRutToiThieu);

                btnSua.Text = "Cập nhật";
            }

            else
            {

                SaveFromTextBox(lblLaiSuat, txtLaiSuat);
                SaveFromTextBox(lblThoiGianGuiToiThieu, txtThoiGianGuiToiThieu);
                SaveFromTextBox(lblInputQuyDinhSoTienRut, txtSoTienRutToiThieu);

                btnSua.Text = "Sửa";
            }

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtAdjustRate_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
