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
using BUS;
using DTO;

namespace GUI.DashboardApp
{
    public partial class ucQuanLyKhachHang : UserControl
    {
        private DSKhachHangBUS dsKhachHangBUS = new DSKhachHangBUS();
        List<KhachHang> danhSachKhachHang = new List<KhachHang>();

        public ucQuanLyKhachHang()
        {
            InitializeComponent();
        }


        private void ucManageCustomers_Load(object sender, EventArgs e)
        {
            danhSachKhachHang = dsKhachHangBUS.GetAllCustomers();
            populateItems(danhSachKhachHang);

        }

        private void populateItems(List<KhachHang> khachHangList)
        {
            // Xóa tất cả control cũ
            flowLayoutPanelKhachHang.Controls.Clear();

            foreach (var kh in khachHangList)
            {
                var listItem = new ListItem
                {
                    Ten1 = kh.HoTenKH,
                    Ten2 = kh.MaKH,
                    Ten3 = kh.SoDuHienCo.ToString("C"),
                    Ten4 = kh.SDT
                };

                flowLayoutPanelKhachHang.Controls.Add(listItem);
            }
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            ThemKhachHang addSavingBooks = new ThemKhachHang();
            addSavingBooks.Show();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            ThongTinKhachHang customerInfor = new ThongTinKhachHang();
            customerInfor.Show();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtTimKiem.Text.Trim();

            // Gọi hàm tìm kiếm trong database
            var danhSachKhachHang = dsKhachHangBUS.SearchKhachHang(searchText);

            // Hiển thị danh sách khách hàng lên FlowLayoutPanel
            populateItems(danhSachKhachHang);
        }
    }
}
