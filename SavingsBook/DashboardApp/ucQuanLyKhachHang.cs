using DAO;
using DTO;
using SavingsBook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.DashboardApp
{
    public partial class ucQuanLyKhachHang : UserControl
    {
        public ucQuanLyKhachHang()
        {
            InitializeComponent();
        }


        private void ucManageCustomers_Load(object sender, EventArgs e)
        {
            populateItems();

        }

        private void populateItems()
        {
            // Tạo instance của DAO
            KhachHangDAO khachHangDAO = new KhachHangDAO();

            // Lấy danh sách khách hàng từ cơ sở dữ liệu
            List<KhachHang> danhSachKhachHang = khachHangDAO.LayDanhSachKhachHang();

            // Thêm từng khách hàng vào giao diện
            foreach (KhachHang kh in danhSachKhachHang)
            {
                ListItem item = new ListItem
                {
                    Ten1 = kh.TenKhachHang,
                    Ten2 = kh.SoTaiKhoanThanhToan, // Hiển thị số tài khoản
                    Ten3 = kh.CCCD,
                    Ten4 = kh.SoDuHienCo.ToString()
                };

                flowLayoutPanel1.Controls.Add(item);
            }


            // Cập nhật lại kích thước các item khi thay đổi kích thước của flow layout panel
            flowLayoutPanel1.Resize += (s, e) =>
            {
                foreach (ListItem item in flowLayoutPanel1.Controls)
                {
                    item.Width = flowLayoutPanel1.ClientSize.Width;
                }
            };
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            ThemKhachHang addSavingBooks = new ThemKhachHang();
            addSavingBooks.OnKhachHangAdded += populateItems;

            addSavingBooks.Show();
        }
        public void RefreshCustomerList()
        {
            flowLayoutPanel1.Controls.Clear(); // Xóa các item hiện tại
            populateItems(); // Gọi lại phương thức để thêm lại các khách hàng
        }
        private void btn_Click(object sender, EventArgs e)
        {
            ThongTinKhachHang customerInfor = new ThongTinKhachHang();
            customerInfor.Show();
        }

        private void lblMaPhieuTietKiem0_Click(object sender, EventArgs e)
        {

        }
    }
}
