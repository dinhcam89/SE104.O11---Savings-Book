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
    public partial class ThemPhieu : Form
    {
        public ThemPhieu()
        {
            InitializeComponent();
            // Thiết lập không cho phép thay đổi kích thước Form
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            string[] hinhThucGiaHan = { "Không gia hạn", "Xoay vòng gốc", "Xoay vòng gốc lẫn lãi" };
            cboxHinhThucGiaHan.Items.AddRange(hinhThucGiaHan);

            string[] kyHan = { "Không kỳ hạn", "3 tháng", "6 tháng" };
            cboxKyHan.Items.AddRange(kyHan);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTao_Click(object sender, EventArgs e)
        {

        }
    }
}
