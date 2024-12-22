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
<<<<<<< HEAD
        private ThamSoBUS _thamSoBUS = new ThamSoBUS();
        private ThamSo? thamSo;
=======
        
>>>>>>> b9113d9 (Initial commit)
        public ucChinhSuaQuyDinh()
        {
            InitializeComponent();
        }
        private void loadThamSo()
        {
<<<<<<< HEAD
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
=======
            
>>>>>>> b9113d9 (Initial commit)
        }
        private void ucChinhSuaQuyDinh_Layout(object sender, LayoutEventArgs e)
        {
            loadThamSo();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            if (tbSoTienBanDauToiThieu.Text == "" || tbSoTienGoiThemToiThieu.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _thamSoBUS.updateThamSo(new ThamSo(double.Parse(tbSoTienBanDauToiThieu.Text), double.Parse(tbSoTienGoiThemToiThieu.Text)));
            loadThamSo();
=======
            
>>>>>>> b9113d9 (Initial commit)
        }

        private void btnDatLai_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            ThamSo defaultThamSo = new ThamSo(100000, 0);
            _thamSoBUS.updateThamSo(defaultThamSo);
            loadThamSo();
=======
            
>>>>>>> b9113d9 (Initial commit)
        }
    }
}
