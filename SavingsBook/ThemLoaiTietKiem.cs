using BUS;
using DTO;
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
    public partial class ThemLoaiTietKiem : Form
    {
        private LoaiTietKiemBUS _loaiTietKiemBUS = new LoaiTietKiemBUS();
        private Action reload;
        public ThemLoaiTietKiem(Action reload)
        {
            InitializeComponent();
            this.reload = reload;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            if (txtKyHan.Text == "" || txtSoNgayToiThieuDuocRutTien.Text == "" || txtLaiSuat.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Format values to insert into database
            /// Kỳ hạn
            bool isKyHanValid = int.TryParse(txtKyHan.Text, out int formatedKyHan);
            if (isKyHanValid)
            {
                if (formatedKyHan <= 0)
                {
                    MessageBox.Show("Kỳ hạn phải lớn hơn 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Kỳ hạn không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            /// Lãi suất
            bool isLaiSuatValid = double.TryParse(txtLaiSuat.Text, out double formatedLaiSuat);
            if (isLaiSuatValid)
            {
                if (formatedLaiSuat <= 0)
                {
                    MessageBox.Show("Lãi suất phải lớn hơn 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            } else
            {
                MessageBox.Show("Lãi suất không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            /// Số ngày tối thiểu được rút tiền
            bool isSoNgayToiThieuDuocRutTienValid = int.TryParse(txtSoNgayToiThieuDuocRutTien.Text, out int formatedSoNgayToiThieuDuocRutTien);
            if (isSoNgayToiThieuDuocRutTienValid)
            {
                if (formatedSoNgayToiThieuDuocRutTien < 0)
                {
                    MessageBox.Show("Số ngày tối thiểu được rút tiền phải lớn hơn hoặc bằng 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Số ngày tối thiểu được rút tiền không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            /// Quy định số tiền rút
            string formatedQuyDinhTienRut = "";
            if (cboxQuyDinhTienRut.Text != "Toàn phần" && cboxQuyDinhTienRut.Text != "Một phần hoặc toàn phần")
            {
                MessageBox.Show("Quy định số tiền rút không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (cboxQuyDinhTienRut.Text == "Toàn phần")
                {
                    formatedQuyDinhTienRut = "=";
                }
                else
                {
                    formatedQuyDinhTienRut = "<=";
                }

            }
            _loaiTietKiemBUS.postLoaiTietKiem(formatedKyHan * 30, formatedLaiSuat, formatedSoNgayToiThieuDuocRutTien, formatedQuyDinhTienRut);
            MessageBox.Show("Thêm loại tiết kiệm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            reload();
            Close();
        }
    }
}
