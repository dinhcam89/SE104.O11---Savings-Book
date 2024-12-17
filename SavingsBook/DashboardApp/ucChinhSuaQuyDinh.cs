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
        public ucChinhSuaQuyDinh()
        {
            InitializeComponent();
            ThamSo? thamSo = _thamSoBUS.getThamSo();
            if (thamSo != null)
            {
                tbSoTienBanDauToiThieu.Text = thamSo.SoTienBanDauToiThieu.ToString();
                tbSoTienGoiThemToiThieu.Text = thamSo.SoTienGoiThemToiThieu.ToString();
            } else
            {
                MessageBox.Show("Không thể lấy dữ liệu từ database");
                tbSoTienBanDauToiThieu.Text = "0";
                tbSoTienGoiThemToiThieu.Text = "0";
            }
        }
    }
}
