using System.Data;
using System.Data.SqlClient;

namespace SavingsBook
{
    public partial class Form1 : Form
    {
        /**
         * Trước khi chạy chương trình, cần đảm bảo các yêu cầu sau:
         * - SQL Server đang chạy.
         * - Có cơ sở dữ liệu có tên "saving_books_management".
         * - Có bảng có tên "SoTietKiem" trong cơ sở dữ liệu "master".
         * - Bảng "SoTietKiem" có cấu trúc như sau:
         * + MaSo: int, primary key, identity(1, 1)
         * + DiaChi: varchar(255), not null
         * + SoTienGoi: decimal(15, 2), not null
         * + NgayMoSo: datetime, not null
         */

        // Mẫu connection string: "Server=[tên máy chủ];Database=[tên cơ sở dữ liệu];Integrated Security=[hình thức xác thực];"
        // - Nếu sử dụng Windows Authentication: "Integrated Security=sspi"
        // - Nếu sử dụng SQL Server Authentication: "User Id=[tên người dùng];Password=[mật khẩu];"
        string connectionString = "Server=LT49\\SQLEXPRESS;Database=master;Integrated Security=sspi;";
        string query = "SELECT * FROM SoTietKiem";

        SqlConnection connection;
        SqlCommand command;
        DataTable dataTable;

        public Form1()
        {
            InitializeComponent();
            connection = new SqlConnection(connectionString);
            command = new SqlCommand(query, connection);
            connection.Open();
            dataTable = new DataTable();
            dataTable.Load(command.ExecuteReader());
            connection.Close();
            dataGridView.DataSource = dataTable;
            ReadDatabase();
        }

        void ReadDatabase()
        {
            connection.Open();
            dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.Fill(dataTable);
            connection.Close();
            dataGridView.DataSource = dataTable;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Kiểm tra Số tiền gới có điền đầy đủ hay không
            if (tbDeposit.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra Số tiền gởi có phải là số thực không
            if (!decimal.TryParse(tbDeposit.Text, out decimal deposit))
            {
                MessageBox.Show("Số tiền gởi phải là số thực", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Thêm dữ liệu vào bảng
            connection.Open();
            string query = $"INSERT INTO SoTietKiem VALUES (N'{tbAddress.Text}', {deposit}, GETDATE())";
            command = new SqlCommand(query, connection);
            int numberOfRows = command.ExecuteNonQuery();
            connection.Close();
            ReadDatabase();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Kiểm tra Mã số có điền đầy đủ hay không
            if (!int.TryParse(tbId.Text, out int id))
            {
                MessageBox.Show("Vui lòng nhập mã số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra nếu Số điền được điền thì Số tiền gởi có phải là số thực không
            if (tbDeposit.Text != "")
            {
                if (!decimal.TryParse(tbDeposit.Text, out decimal deposit))
                {
                    MessageBox.Show("Số tiền gởi phải là số thực", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string queryAddress = "";
                if (tbAddress.Text != "")
                {
                    queryAddress = $"DiaChi = N'{tbAddress.Text}', ";
                }

                // Sửa dữ liệu trong bảng
                connection.Open();

                string query = $"UPDATE SoTietKiem SET {queryAddress} SoTienGoi = {deposit} WHERE MaSo = {id}";
                command = new SqlCommand(query, connection);
                int numberOfRows = command.ExecuteNonQuery();

                connection.Close();
                ReadDatabase();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Kiểm tra Mã số có điền đầy đủ hay không
            if (tbId.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra Mã số có phải là số nguyên không
            if (!int.TryParse(tbId.Text, out int id))
            {
                MessageBox.Show("Mã số phải là số nguyên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xóa dữ liệu trong bảng
            connection.Open();
            string query = $"DELETE FROM SoTietKiem WHERE MaSo = {id}";
            command = new SqlCommand(query, connection);
            int numberOfRows = command.ExecuteNonQuery();
            connection.Close();
            ReadDatabase();
        }
    }
}
