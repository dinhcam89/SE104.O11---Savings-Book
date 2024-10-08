using System.Data;
using System.Data.SqlClient;

namespace SavingsBook
{
    public partial class Form1 : Form
    {
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
