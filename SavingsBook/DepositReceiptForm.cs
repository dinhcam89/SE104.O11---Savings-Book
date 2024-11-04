using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using BUS;
using DTO;

namespace GUI
{
    public partial class DepositReceiptForm : Form
    {
        private DepositSlipBUS depositSlipBUS;
        //string connectionString = "Data Source=CONALNGUYEN\\NGUYENCHAU;Initial Catalog=saving_books_management;Integrated Security=True;Trust Server Certificate=True";
        //string query = "SELECT * FROM SoTietKiem";

        //SqlConnection connection;
        //SqlCommand command;
        //DataTable dataTable;

        public DepositReceiptForm(string savingsBookID)
        {
            InitializeComponent();
            // Thiết lập không cho phép thay đổi kích thước Form
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            depositSlipBUS = new DepositSlipBUS();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            lblID.Text = lblID.Text;
            //lblID.ReadOnly = true;
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMoney.Text) || string.IsNullOrEmpty(txtDate.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            try
            {
                var depositReceipt = new DepositSlipDTO
                {

                    DepositDate = DateOnly.Parse(txtDate.Text),
                    DepositAmount = double.Parse(txtMoney.Text)
                };

                bool isAdded = depositSlipBUS.AddDepositReceipt(depositReceipt);

                if (isAdded)
                {
                    MessageBox.Show("Thêm phiếu gửi tiền thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm phiếu gửi tiền thất bại. Kiểm tra lại thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
