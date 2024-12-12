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
