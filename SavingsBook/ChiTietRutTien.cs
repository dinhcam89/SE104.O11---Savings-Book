using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class ChiTietRutTien : Form
    {
        private string maPhieuGoiTien;
        private string tenKhachHang;
        public ChiTietRutTien(string maPhieuGoiTien, string tenKhachHang)

        {
            InitializeComponent();
            this.maPhieuGoiTien = maPhieuGoiTien;
            this.tenKhachHang = tenKhachHang;
        }
        public ChiTietRutTien(string maPhieuGoiTien) 
        {
            this.maPhieuGoiTien = maPhieuGoiTien;
             // Tự động điền số tài khoản thanh toán

        }
        private void ChiTietRutTien_Load(object sender, EventArgs e)
        {
            populateItems(maPhieuGoiTien, tenKhachHang);
            lbMaPhieu.Text = maPhieuGoiTien;
            lblTenKhachHang.Text = tenKhachHang;

        }

        private void populateItems(string maPhieu, string tenKhachHang)
        {
            flowLayoutPanel1.Controls.Clear();

            List<DTO.ChiTietRutTien> listChiTiet;

            try
            {
                // Tạo đối tượng BUS
                var hienthiBUS = new HienThiChiTietRutTienBUS();

                // Kiểm tra và lấy thông tin theo mã phiếu
                var chiTiet = hienthiBUS.GetChiTietGuiTienByMaPhieu(maPhieu);
                listChiTiet = chiTiet != null ? new List<DTO.ChiTietRutTien> { chiTiet } : new List<DTO.ChiTietRutTien>();

                if (listChiTiet.Count > 0)
                {
                    foreach (var item in listChiTiet)
                    {
                        var listItem = new ListItem
                        {
                            Ten1 = $"{item.NgayRut:dd/MM/yyyy}",
                            Ten2 = $"{item.SoTienRut:C}",
                            Ten3 = "",
                            Ten4 = "",
                            FormType = ObjectType.PhieuGoiTien,
                            IsButtonVisible = false

                        };

                        flowLayoutPanel1.Controls.Add(listItem);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy dữ liệu phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
