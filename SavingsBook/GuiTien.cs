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
    public partial class GuiTien : Form
    {
        private string maPhieu;
        public GuiTien(string maPhieu)
        {
            InitializeComponent();
            // Thiết lập không cho phép thay đổi kích thước Form
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.maPhieu = maPhieu;
            lblSTKTienGoi.Text = maPhieu;
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string soTaiKhoanTienGoi = this.maPhieu;
                if (!float.TryParse(txtSoTienGoi.Text, out float soTienGuiThem) || soTienGuiThem <= 0)
                {
                    MessageBox.Show("Số tiền gửi thêm phải lớn hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime ngayGiaoDich = DTPNgayGiaoDich.Value.Date;

                // Gọi BUS để xử lý logic gửi tiền
                ChiTietGuiTienBUS bus = new ChiTietGuiTienBUS();
                string result = bus.GuiThemTien(soTaiKhoanTienGoi, soTienGuiThem, ngayGiaoDich);


                MessageBox.Show(result, "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
