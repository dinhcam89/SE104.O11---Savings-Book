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
            if (thamSo == null)
            {
                MessageBox.Show("Không thể lấy thông tin quy định từ cơ sở dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tbSoTienBanDauToiThieu.Text == "" || tbSoTienGoiThemToiThieu.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool res = _thamSoBUS.updateThamSo(new ThamSo(thamSo.MaThamSo, double.Parse(tbSoTienBanDauToiThieu.Text), double.Parse(tbSoTienGoiThemToiThieu.Text)));
            if (res) {
                MessageBox.Show("Cập nhật quy định thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadThamSo();
            }
            else
            {
                MessageBox.Show("Cập nhật quy định thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDatLai_Click(object sender, EventArgs e)
        {
            if (thamSo == null)
            {
                MessageBox.Show("Không thể lấy thông tin quy định từ cơ sở dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ThamSo? defaultThamSo = _thamSoBUS.getDefaultThamSo();
            if (defaultThamSo == null)
            {
                MessageBox.Show("Không thể lấy thông tin quy định mặc định từ cơ sở dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool res = _thamSoBUS.updateThamSo(new ThamSo(thamSo.MaThamSo, defaultThamSo.SoTienBanDauToiThieu, defaultThamSo.SoTienGoiThemToiThieu));
            if (!res)
            {
                MessageBox.Show("Đặt lại quy định thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Đặt lại quy định thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadThamSo();
            }
        }
    }
}
