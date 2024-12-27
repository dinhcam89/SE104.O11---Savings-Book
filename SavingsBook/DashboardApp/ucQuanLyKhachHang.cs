using BUS;
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
        List<KhachHang> khachHangs;
        KhachHangBUS khachHangBUS = new KhachHangBUS();
        public ucQuanLyKhachHang()
        {
            InitializeComponent();
            khachHangs = khachHangBUS.GetAllKhachHangWithPhieuGoiTienCount();
        }


        private void ucManageCustomers_Load(object sender, EventArgs e)
        {
            PopulateItems(khachHangs);

        }

        private void PopulateItems(List<KhachHang> khachHangList)
        {

            // Xóa các điều khiển cũ
            flowLayoutPanel1.Controls.Clear();

            // Tạo và thêm các ListItem
            foreach (var kh in khachHangList)
            {
                var listItem = new ListItem(kh, ReloadDanhSachKhachHang);

                // Thêm vào FlowLayoutPanel
                flowLayoutPanel1.Controls.Add(listItem);
            }

            // Điều chỉnh kích thước các ListItem khi thay đổi kích thước FlowLayoutPanel
            flowLayoutPanel1.Resize += (s, e) =>
            {
                foreach (ListItem item in flowLayoutPanel1.Controls)
                {
                    item.Width = flowLayoutPanel1.ClientSize.Width;
                }
            };
        }
        string formatSoTien(double sotien)
        {
            string formatedText;
            if (sotien == 0)
            {
                formatedText = sotien + " VND";
            }
            else
            {
                formatedText = sotien.ToString("#,#.##") + " VND";
            }
            return formatedText;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ThemKhachHang addSavingBooks = new ThemKhachHang();
            addSavingBooks.OnKhachHangAdded += ReloadDanhSachKhachHang;
            addSavingBooks.Show();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            ThongTinKhachHang customerInfor = new ThongTinKhachHang(ReloadDanhSachKhachHang);
            customerInfor.Show();
        }
        private void ReloadDanhSachKhachHang()
        {
            // Cập nhật lại danh sách khách hàng
            // Ví dụ, reload lại dữ liệu từ cơ sở dữ liệu hoặc từ nguồn dữ liệu khác
            khachHangs = khachHangBUS.GetAllKhachHangWithPhieuGoiTienCount();
            PopulateItems(khachHangs);
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtTimKiem.Text.Trim();
            var searchKhachHang = khachHangBUS.SearchKhachHang(searchText);

            PopulateItems(searchKhachHang);
        }
    }
}
