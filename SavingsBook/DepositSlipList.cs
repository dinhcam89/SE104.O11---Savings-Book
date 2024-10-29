using BUS;

namespace GUI
{
    public partial class DepositSlipList : Form
    {
        public DepositSlipList()
        {
            InitializeComponent();
        }
        DepositSlipBUS depositSlipBUS = new();

        private void btnLoad_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = depositSlipBUS.getAllDepositSlip();
            dataGridView1.Refresh();
        }
    }
}
