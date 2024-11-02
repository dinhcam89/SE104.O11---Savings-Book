using GUI;

namespace SavingsBook
{
    public partial class CustomerInfor : Form
    {
        public CustomerInfor()
        {
            InitializeComponent();
            // Thiet lap khong thay doi kich thuoc form
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text == "Sửa")
            {
                ToggleToEditMode(lblName, txtName);
                ToggleToEditMode(lblID, txtID);
                ToggleToEditMode(lblCustomerID, txtCustomerID);
                ToggleToEditMode(lblAddress, txtAddress);
                ToggleToEditMode(lblPhone, txtPhone);
              
                btnEdit.Text = "Lưu";
            }
            else
            {
                SaveFromTextBox(lblName, txtName);
                SaveFromTextBox(lblID, txtID);
                SaveFromTextBox(lblCustomerID, txtCustomerID);
                SaveFromTextBox(lblAddress, txtAddress);
                SaveFromTextBox(lblPhone, txtPhone);

                btnEdit.Text = "Sửa";
            }
        }

        private void ToggleToEditMode(Label lbl, Guna.UI2.WinForms.Guna2TextBox txt)
        {
            lbl.Visible = false;
            txt.Visible = true;
            txt.Text = lbl.Text;
            txt.Focus();
        }

        private void SaveFromTextBox(Label lbl, Guna.UI2.WinForms.Guna2TextBox txt)
        {
            lbl.Text = txt.Text;
            txt.Visible = false;
            lbl.Visible = true;
        }

        //Tạo phiếu rút tiền
        private void btnAdd1_Click(object sender, EventArgs e)
        {
            WithdrawalReceiptForm form = new WithdrawalReceiptForm();
            form.Show();
        }

        //Tạo phiếu gửi tiền
        private void btnAdd_Click(object sender, EventArgs e)
        {
            DepositReceiptForm form = new DepositReceiptForm();
            form.Show();
        }

    }
}
