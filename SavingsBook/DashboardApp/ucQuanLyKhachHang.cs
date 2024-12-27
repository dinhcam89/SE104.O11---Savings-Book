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
        public ucQuanLyKhachHang()
        {
            InitializeComponent();
        }


        private void ucManageCustomers_Load(object sender, EventArgs e)
        {
            PopulateItems();

        }

        private void PopulateItems()
        {
            // Lấy dữ liệu từ lớp BUS
            var khachHangBUS = new KhachHangBUS();
            List<KhachHang> danhSachKhachHang = khachHangBUS.GetAllKhachHangWithPhieuGoiTienCount();

            // Xóa các điều khiển cũ
            flowLayoutPanel1.Controls.Clear();

            // Tạo và thêm các ListItem
            foreach (var kh in danhSachKhachHang)
            {
                //var listItem = new ListItem
                //{
                //    Ten1 = kh.TenKhachHang,               // Tên khách hàng
                //    Ten2 = kh.SoTaiKhoanThanhToan,       // Mã khách hàng
                //    Ten3 = formatSoTien(kh.SoDuHienCo),  // Số dư (định dạng tiền tệ)
                //    Ten4 = kh.TongSoPhieuGoiTien.ToString() // Tổng số phiếu tiết kiệm
                //};

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
            ThongTinKhachHang customerInfor = new ThongTinKhachHang(PopulateItems);
            customerInfor.Show();
        }
        private void ReloadDanhSachKhachHang()
        {
            // Cập nhật lại danh sách khách hàng
            // Ví dụ, reload lại dữ liệu từ cơ sở dữ liệu hoặc từ nguồn dữ liệu khác
            PopulateItems();
        }
    }
}
