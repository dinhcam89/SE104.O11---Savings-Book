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
            EditSavingBook editSavingBook = new EditSavingBook();
            editSavingBook.Show();
        }

        private void btnAdd1_Click(object sender, EventArgs e)
        {
            WithdrawalReceiptForm form = new WithdrawalReceiptForm();
            form.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DepositReceiptForm form = new DepositReceiptForm();
            form.Show();
        }
    }
}
