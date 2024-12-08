using GUI;

namespace SavingsBook
{
    public partial class SlotInfor : Form
    {
        public SlotInfor()
        {
            InitializeComponent();
            // Thiet lap khong thay doi kich thuoc form
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            string[] loaiTietKiem = { "Không kỳ hạn", "Kỳ hạn 3 tháng", "Kỳ hạn 6 tháng" };
            cboxLoaiTietKiem.Items.AddRange(loaiTietKiem);

            string[] stkThanhToan = { "123456789", "987654321", "456123789" };
            cboxSTKThanhToan.Items.AddRange(stkThanhToan);
        }




        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text == "Sửa")
            {
                ToggleToEditMode(lblTongTienGoc, txtTongTienGoc);
                ToggleToEditMode(lblLaiSuatPhatSinh, txtLaiSuatPhatSinh);
                ToggleToEditMode(lblLaiSuatApDung, txtLaiSuatApDung);
                ToggleToEditMode(lblSTKThanhToan, cboxSTKThanhToan); 
                ToggleToEditMode(lblLoaiTietKiem, cboxLoaiTietKiem);

                btnEdit.Text = "Cập nhật";
            }
            else
            {
                SaveFromEditor(lblTongTienGoc, txtTongTienGoc);
                SaveFromEditor(lblLaiSuatPhatSinh, txtLaiSuatPhatSinh);
                SaveFromEditor(lblLaiSuatApDung, txtLaiSuatApDung);
                SaveFromEditor(lblSTKThanhToan, cboxSTKThanhToan);
                SaveFromEditor(lblLoaiTietKiem, cboxLoaiTietKiem);

                btnEdit.Text = "Sửa";
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
