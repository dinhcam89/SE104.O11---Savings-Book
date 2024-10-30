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
    public partial class EditAdjustRateForm : Form
    {
        public EditAdjustRateForm()
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ToggleToEditMode(lblMoney, txtMoney);
            ToggleToEditMode(lblAdjustRate, txtAdjustRate);
            ToggleToEditMode(lblMinimumTime, txtMinimumTime);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFromTextBox(lblMoney, txtMoney);
            SaveFromTextBox(lblAdjustRate, txtAdjustRate);
            SaveFromTextBox(lblMinimumTime, txtMinimumTime);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
