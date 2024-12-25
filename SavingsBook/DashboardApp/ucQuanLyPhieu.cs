using SavingsBook;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DTO;
using BUS;
using DAO;

namespace GUI.DashboardApp
{
    public partial class ucQuanLyPhieu : UserControl
    {
        private PhieuGoiTienBUS phieuGoiTienBUS;

        public ucQuanLyPhieu()
        {
            InitializeComponent();
            phieuGoiTienBUS = new PhieuGoiTienBUS();
        }

        public List<(string TenKhachHang, string SoTaiKhoanTienGoi, string MaLoaiTietKiem)> LayThongTinPhieuGoiTien()
        {
            PhieuGoiTienDAO phieuGoiTienDAO = new PhieuGoiTienDAO();
            KhachHangDAO khachHangDAO = new KhachHangDAO();

            var danhSachPhieu = phieuGoiTienDAO.LayDanhSachPhieuGoiTien();
            var danhSachKhachHang = khachHangDAO.LayDanhSachKhachHang();

            // Chuyển danh sách khách hàng sang dạng Dictionary
            Dictionary<string, string> khachHangDict = new Dictionary<string, string>();
            foreach (var kh in danhSachKhachHang)
            {
                khachHangDict[kh.SoTaiKhoanThanhToan] = kh.TenKhachHang;
            }

            List<(string TenKhachHang, string SoTaiKhoanTienGoi, string MaLoaiTietKiem)> ketQua = new();

            foreach (var phieu in danhSachPhieu)
            {
                string tenKhachHang = khachHangDict.ContainsKey(phieu.SoTaiKhoanTienGoi)
                    ? khachHangDict[phieu.SoTaiKhoanTienGoi]
                    : "Không xác định";

                ketQua.Add((tenKhachHang, phieu.SoTaiKhoanTienGoi, phieu.MaLoaiTietKiem));
            }

            return ketQua;
        }

        private void populateItems()
        {
            var danhSachPhieu = LayThongTinPhieuGoiTien();

            flowLayoutPanel1.Controls.Clear();

            foreach (var phieu in danhSachPhieu)
            {
                ListItem item = new ListItem
                {
                    FormType = ObjectType.PhieuGoiTien, // Loại dữ liệu
                    Ten1 = phieu.TenKhachHang,         // Hiển thị tên khách hàng
                    Ten2 = phieu.SoTaiKhoanTienGoi,   // Hiển thị số tài khoản tiền gửi
                    Ten3 = phieu.MaLoaiTietKiem ,
                    Ten4 = ""
                };

                flowLayoutPanel1.Controls.Add(item);
            }

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
            ThemPhieu editCustomerInfor = new ThemPhieu();
            editCustomerInfor.Show();
        }

        private void ucManageSavingBooks_Load(object sender, EventArgs e)
        {
            populateItems();
        }
    }
}
