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
    public partial class CustomerInfor : Form
    {
        public CustomerInfor()
        {
            InitializeComponent();
            //customizeDesign();
            // Thiết lập không cho phép thay đổi kích thước Form
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text == "Sửa")
            {
                ToggleToEditMode(lblSTKThanhToan, txtSTKThanhToan);
                ToggleToEditMode(lblDiaChi, txtDiaChi);;

                btnEdit.Text = "Cập nhật";
            }
            else
            {
                SaveFromEditor(lblSTKThanhToan, txtSTKThanhToan);
                SaveFromEditor(lblDiaChi, txtDiaChi);

                btnEdit.Text = "Sửa";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
