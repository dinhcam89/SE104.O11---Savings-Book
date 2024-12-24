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

namespace GUI
{
    public partial class RutTienForm : Form
    {
        private readonly ChiTietRutTienBUS rutTienBUS = new ChiTietRutTienBUS();
        public RutTienForm()
        {
            InitializeComponent();
            // Thiết lập không cho phép thay đổi kích thước Form
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Load += new System.EventHandler(this.RutTienForm_Load);

        }

        public void RutTienForm_Load(object sender, EventArgs e)
        {
            string soTaiKhoanTienGoi = lblSTKTienGoi.Text;
            double tongTien = rutTienBUS.GetTongTien(soTaiKhoanTienGoi);
            bool isKyHan = rutTienBUS.IsKyHan(soTaiKhoanTienGoi);

            if (tongTien > 0)
            {
                txtSoTienRut.Text = tongTien.ToString("N2"); // Hiển thị số tiền với định dạng hai chữ số thập phân
            }
            else
            {
                txtSoTienRut.Text = "0.00";
            }

            if (isKyHan)
            {
                // Nếu là loại tiết kiệm có kỳ hạn
                txtSoTienRut.Enabled = false; // Không cho phép nhập
                txtSoTienRut.Text = tongTien.ToString("N2"); // Hiển thị toàn bộ số tiền
            }
            else
            {
                // Nếu là loại tiết kiệm không kỳ hạn
                txtSoTienRut.Enabled = true; // Cho phép nhập
                //txtSoTienRut.Clear(); // Để trống TextBox
            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRutTien_Click(object sender, EventArgs e)
        {
            string soTaiKhoanTienGoi = lblSTKTienGoi.Text;
            if (string.IsNullOrWhiteSpace(soTaiKhoanTienGoi))
            {
                MessageBox.Show("Số tài khoản tiền gửi không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!double.TryParse(txtSoTienRut.Text, out double soTienRut) || soTienRut <= 0)
            {
                MessageBox.Show("Số tiền rút phải là một số hợp lệ và lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime ngayRut = DTPNgayGiaoDich.Value;

            if (ngayRut.Date != DateTime.Today)
            {
                MessageBox.Show("Ngày giao dịch phải là ngày hôm nay.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string result = rutTienBUS.RutTien(soTaiKhoanTienGoi, ngayRut, soTienRut);
            MessageBox.Show(result);

        }
    }
}
