using System.Data;
using System.Data.SqlClient;

namespace SavingsBook
{
    public partial class Form1 : Form
    {
        /**
         * Trước khi chạy chương trình, cần đảm bảo các yêu cầu sau:
         * - SQL Server đang chạy.
         * - Có cơ sở dữ liệu có tên "master".
         * - Có bảng có tên "SoTietKiem" trong cơ sở dữ liệu "master".
         * - Bảng "SoTietKiem" có cấu trúc như sau:
         * + MaSo: int, primary key, identity(1, 1)
         * + DiaChi: varchar(255), not null
         * + SoTienGoi: decimal(15, 2), not null
         * + NgayMoSo: datetime, not null
         */

        // Mẫu connection string: "Server=[tên máy chủ];Database=[tên cơ sở dữ liệu];Integrated Security=[hình thức xác thực];"
        // Hình thức xác thực: "Integrated Security=sspi" (Windows Authentication)
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
            dataTable.Load(command.ExecuteReader());
            connection.Close();
            dataGridView.DataSource = dataTable;
        }
    }
}
