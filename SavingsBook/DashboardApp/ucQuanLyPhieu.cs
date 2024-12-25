using BUS;
using DAO;
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
using DTO;
namespace GUI.DashboardApp
{
    public partial class ucQuanLyPhieu : UserControl
    {
        private PhieuGoiTienBUS PhieuGoiTienBUS = new PhieuGoiTienBUS();
        // Danh sách các đối tượng DTO để lưu dữ liệu từ database
        private List<PhieuGoiTien> listPhieuGoiTien;

        // Lấy dữ liệu từ lớp BUS (nơi xử lý nghiệp vụ)
        public ucQuanLyPhieu()
        {
            InitializeComponent();
            listPhieuGoiTien = PhieuGoiTienBUS.GetAllPhieuGoiTien();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ThemPhieu editCustomerInfor = new ThemPhieu();
            editCustomerInfor.Show();
        }

        private void ucManageSavingBooks_Load(object sender, EventArgs e)
        {
            PopulateItems(listPhieuGoiTien);

        }
        

        private void PopulateItems(List<PhieuGoiTien> listPhieuGoiTien)
        {
            

            // Kiểm tra dữ liệu
            if (listPhieuGoiTien == null || listPhieuGoiTien.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu nào để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Xóa các điều khiển cũ nếu cần
            flowLayoutPanel1.Controls.Clear();

            // Hiển thị từng phiếu gửi tiền lên form
            foreach (var phieuGoiTien in listPhieuGoiTien)
            {
                var listItem = new ListItem
                {
                    Ten1 = phieuGoiTien.TenKhachHang,         // Tên khách hàng
                    Ten2 = phieuGoiTien.SoTaiKhoanTienGoi,    // Số tài khoản tiền gửi
                    Ten3 = phieuGoiTien.MaLoaiTietKiem,       // Mã loại tiết kiệm
                    Ten4 = phieuGoiTien.NgayGoi.ToString("dd/MM/yyyy"), // Ngày gửi (format dd/MM/yyyy)
                    FormType = ObjectType.PhieuGoiTien        // Loại đối tượng
                };

                // Gán sự kiện cho nút bấm nếu cần
                listItem.ButtonClick += (s, e) =>
                {
                    MessageBox.Show($"Xem chi tiết phiếu gửi tiền: {phieuGoiTien.SoTaiKhoanTienGoi}", "Thông tin");
                };

                // Thêm điều khiển vào FlowLayoutPanel
                flowLayoutPanel1.Controls.Add(listItem);
            }

            // Đảm bảo các ListItem tự động thay đổi kích thước theo FlowLayoutPanel
            flowLayoutPanel1.Resize += (s, e) =>
            {
                foreach (ListItem item in flowLayoutPanel1.Controls)
                {
                    item.Width = flowLayoutPanel1.ClientSize.Width;
                }
            };
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtTimKiem.Text.Trim();
            var listPhieuGoiTien = PhieuGoiTienBUS.SearchPhieuGoiTien(searchText);

            PopulateItems(listPhieuGoiTien);
        }
    }
}
