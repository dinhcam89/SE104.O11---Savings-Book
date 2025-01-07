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
    public partial class ChiTietGuiTien : Form
    {
        private string maPhieu;
        private string tenKhachHang;

        public ChiTietGuiTien(string maPhieu, string tenKhachHang)
        {
            InitializeComponent();
            this.maPhieu = maPhieu;
            this.tenKhachHang = tenKhachHang;
        }

        private void ChiTietGuiTien_Load(object sender, EventArgs e)
        {
            populateItems(maPhieu);
            lbMaPhieu.Text = maPhieu;
            lblTenKhachHang.Text = tenKhachHang;
            try
            {
                var hienthiBUS = new HienThiChiTietGuiTienBUS();
                double tongTienGoc = hienthiBUS.GetTongTien(maPhieu);
                lblSoTienGocCopy.Text = formatSoTien(tongTienGoc);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải tổng tiền gốc: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        private void populateItems(string maPhieu)
        {
            flowLayoutPanel1.Controls.Clear();

            try
            {
                // Tạo đối tượng BUS
                var hienthiBUS = new HienThiChiTietGuiTienBUS();

                // Kiểm tra và lấy thông tin theo mã phiếu
                var chiTiet = hienthiBUS.GetChiTietGuiTienByMaPhieu(maPhieu);

                if (chiTiet.Count > 0)
                {
                    foreach (var item in chiTiet)
                    {
                        var listItem = new ListItem
                        {
                            Ten1 = $"{item.NgayGui:dd/MM/yyyy}",
                            Ten2 = formatSoTien(item.SoTienGui),
                            Ten3 = "",
                            Ten4 = "",
                            FormType = ObjectType.PhieuGoiTien,
                            IsButtonVisible = false

                        };
                        listItem.Width = flowLayoutPanel1.ClientSize.Width - 30;
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
