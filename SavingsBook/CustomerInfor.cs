using GUI;

namespace SavingsBook
{
    public partial class CustomerInfor : Form
    {
        public CustomerInfor()
        {
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditCustomerInfor editCustomerInfor = new EditCustomerInfor();
            editCustomerInfor.Show();
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
