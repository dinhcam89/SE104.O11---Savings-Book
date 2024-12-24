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
