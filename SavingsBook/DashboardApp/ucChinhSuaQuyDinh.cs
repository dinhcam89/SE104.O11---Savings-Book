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
    public partial class ucChinhSuaQuyDinh : UserControl
    {
        private ThamSoBUS _thamSoBUS = new ThamSoBUS();
        private ThamSo? thamSo;
        public ucChinhSuaQuyDinh()
        {
            InitializeComponent();
        }
        private void loadThamSo()
        {
            thamSo = _thamSoBUS.getThamSo();
            if (thamSo != null)
            {
                tbSoTienBanDauToiThieu.Text = thamSo.SoTienBanDauToiThieu.ToString();
                tbSoTienGoiThemToiThieu.Text = thamSo.SoTienGoiThemToiThieu.ToString();
            }
            else
            {
                MessageBox.Show("Không thể lấy thông tin quy định từ cơ sở dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbSoTienBanDauToiThieu.Text = "";
                tbSoTienGoiThemToiThieu.Text = "";
            }
        }
        private void ucChinhSuaQuyDinh_Layout(object sender, LayoutEventArgs e)
        {
            loadThamSo();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (tbSoTienBanDauToiThieu.Text == "" || tbSoTienGoiThemToiThieu.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _thamSoBUS.updateThamSo(new ThamSo(double.Parse(tbSoTienBanDauToiThieu.Text), double.Parse(tbSoTienGoiThemToiThieu.Text)));
            loadThamSo();
        }

        private void btnDatLai_Click(object sender, EventArgs e)
        {
            ThamSo defaultThamSo = new ThamSo(100000, 0);
            _thamSoBUS.updateThamSo(defaultThamSo);
            loadThamSo();
        }
    }
}
