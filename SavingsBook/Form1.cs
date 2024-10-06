using MySql.Data.MySqlClient;
using System.Data;

namespace SavingsBook
{
    public partial class Form1 : Form
    {
        // Chú ý: Code này chỉ dùng để kiểm tra kết nối với database MySQL
        /**
         * Trước khi kết nối với database, cần tạo bảng user trong database saving_books_management
         * Bảng user có cấu trúc như sau:
         * - id: int, primary key, auto increment
         * - name: varchar(255) (hoặc text)
         * - birthday: date
         * - age: int
         */

        // Username và password mặc định của MySQL là root và "" (rỗng)
        string connectionString = "Server=127.0.0.1;Database=saving_books_management;User Id=root;Password=;";
        string queryString = "SELECT * FROM user";

        MySqlConnection connection;

        MySqlCommandBuilder cmdBuilder;

        MySqlDataAdapter dataAdapter;

        DataTable dt;

        public Form1()
        {
            InitializeComponent();
            connection = new MySqlConnection(connectionString);

            connection.Open();

            dataAdapter = new MySqlDataAdapter(queryString, connection);
            cmdBuilder = new MySqlCommandBuilder(dataAdapter); // Initialize dataAdapter
            dt = new DataTable(); // Initialize dt
            dataAdapter.Fill(dt);

            connection.Close();

            dataGridView.DataSource = dt;
        }

        void ReadDatabase()
        {
            connection.Open();

            dataAdapter = new MySqlDataAdapter(queryString, connection);
            cmdBuilder = new MySqlCommandBuilder(dataAdapter);
            dt = new DataTable();
            dataAdapter.Fill(dt);

            connection.Close();

            dataGridView.DataSource = dt;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Kiểm tra id, tên và ngày sinh có rỗng không
            if (tbNameAdd.Text == "" || dtpAdd.Text == "")
            {
                MessageBox.Show("Tên và ngày sinh không được để trống");
                return;
            }

            // Kiểm tra id và tên có tồn tại không
            if (dt.Select("name = '" + tbNameAdd.Text + "'").Length > 0)
            {
                MessageBox.Show("Tên đã tồn tại");
                return;
            }
            if (tbIdAdd.Text != "")
            {
                if (dt.Select("id = " + tbIdAdd.Text).Length > 0)
                {
                    MessageBox.Show("Id đã tồn tại");
                    return;
                }
            }

            // Kiểm tra ngày sinh có nhỏ hơn ngày hiện tại không
            if (DateTime.Parse(dtpAdd.Text) > DateTime.Now)
            {
                MessageBox.Show("Ngày sinh không hợp lệ");
                return;
            }

            // Tính tuổi
            int age = DateTime.Now.Year - DateTime.Parse(dtpAdd.Text).Year;

            // Thêm vào database
            string birthday = DateTime.Parse(dtpAdd.Text).ToString("yyyy-MM-dd");
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO user (name, birthday, age) VALUES ('" + tbNameAdd.Text + "', '" + birthday + "','" + age + "')";
            cmd.ExecuteNonQuery();
            connection.Close();
            ReadDatabase();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Kiểm tra id và tên có bỏ trống không
            if (tbIdUpdate.Text == "" || tbNameUpdate.Text == "")
            {
                MessageBox.Show("Id và tên không được để trống");
                return;
            }

            // Kiểm tra id
            // có tồn tại không
            if (tbIdUpdate.Text != "")
            {
                if (dt.Select("id = " + tbIdUpdate.Text).Length == 0)
                {
                    MessageBox.Show("Id không tồn tại");
                    return;
                }
            }

            // Kiểm tra sinh nhật có hợp lý không
            if (dtpUpdate.Text != "")
            {
                if (DateTime.Parse(dtpUpdate.Text) > DateTime.Now)
                {
                    MessageBox.Show("Ngày sinh không hợp lệ");
                    return;
                }
            }

            // Tính tuổi
            int age = DateTime.Now.Year - DateTime.Parse(dtpUpdate.Text).Year;

            // Cập nhật vào database
            string birthday = dtpUpdate.Text == "" ? "" : DateTime.Parse(dtpUpdate.Text).ToString("yyyy-MM-dd");
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE user SET name = '" + tbNameUpdate.Text + "', birthday = '" + birthday + "', age = '" + age + "' WHERE id = " + tbIdUpdate.Text;
            cmd.ExecuteNonQuery();
            connection.Close();
            ReadDatabase();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Kiểm tra id có bỏ trống không và có tồn tại không

            if (tbIdDelete.Text == "")
            {
                MessageBox.Show("Id không được để trống");
                return;
            }

            if (dt.Select("id = " + tbIdDelete.Text).Length == 0)
            {
                MessageBox.Show("Id không tồn tại");
                return;
            }

            // Xóa khỏi database
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE FROM user WHERE id = " + tbIdDelete.Text;
            cmd.ExecuteNonQuery();
            connection.Close();
            ReadDatabase();
        }
    }
}
