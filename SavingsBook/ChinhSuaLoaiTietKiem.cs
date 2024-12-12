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
        public ChinhSuaLoaiTietKiem()
        {
            InitializeComponent();
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
                ToggleToEditMode(lblSoTienGuiToiThieu, txtSoTienGuiToiThieu);
                ToggleToEditMode(lblLaiSuat, txtLaiSuat);
                ToggleToEditMode(lblThoiGianGuiToiThieu, txtThoiGianGuiToiThieu);
                ToggleToEditMode(lblSoTienRutToiThieu, txtSoTienRutToiThieu);

                btnSua.Text = "Cập nhật";
            }

            else
            {

                SaveFromTextBox(lblSoTienGuiToiThieu, txtSoTienGuiToiThieu);
                SaveFromTextBox(lblLaiSuat, txtLaiSuat);
                SaveFromTextBox(lblThoiGianGuiToiThieu, txtThoiGianGuiToiThieu);
                SaveFromTextBox(lblSoTienRutToiThieu, txtSoTienRutToiThieu);

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
