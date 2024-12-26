using BUS;
using DTO;

namespace GUI
{
    public partial class ChinhSuaLoaiTietKiem : Form
    {
        private LoaiTietKiemBUS _loaiTietKiemBUS = new LoaiTietKiemBUS();
        private LoaiTietKiem _loaiTietKiem;
        private Action reload;
        public ChinhSuaLoaiTietKiem(LoaiTietKiem ltk, Action reload)
        {
            InitializeComponent();
            _loaiTietKiem = ltk;

            // Gán các giá trị từ DTO vào các Label
            if (ltk.KyHan == 0)
            {
                lblLoaiKyHan.Text = "Không kỳ hạn";
            }
            else
            {
                var formatedKyHan = formatDaysToMonths(ltk.KyHan);
                if (formatedKyHan.days == 0)
                {
                    lblLoaiKyHan.Text = $"{formatedKyHan.months} tháng";
                }
                else
                {
                    lblLoaiKyHan.Text = $"{ltk.KyHan} ngày";
                }
            }
            lblLaiSuat.Text = ltk.LaiSuat.ToString();
            var formatedThoiGianGuiToiThieu = formatDaysToMonths(ltk.SoNgayToiThieuDuocRutTien);
            if (formatedThoiGianGuiToiThieu.days == 0)
            {
                lblThoiGianGuiToiThieu.Text = $"{formatedThoiGianGuiToiThieu.months} tháng";
            }
            else
            {
                lblThoiGianGuiToiThieu.Text = $"{ltk.SoNgayToiThieuDuocRutTien} ngày";
            }
            if (ltk.QuyDinhSoTienRut != null)
            {
                if (ltk.QuyDinhSoTienRut == "=")
                {
                    lblInputQuyDinhSoTienRut.Text = "Toàn phần";
                }
                else
                {
                    lblInputQuyDinhSoTienRut.Text = "Một phần hoặc toàn phần";
                }
            }

            this.reload = reload;
        }
        (int months, int days) formatDaysToMonths(int days)
        {
            return (days / 30, days % 30);
        }


        // Chuyển Label thành TextBox
        private void ToggleToEditMode(Label lbl, Guna.UI2.WinForms.Guna2TextBox txt)
        {
            lbl.Visible = false;
            txt.Visible = true;
            txt.Text = lbl.Text;
            txt.Focus();
        }

        // Lưu nội dung từ TextBox vào Label và ẩn TextBox
        private void SaveFromTextBox(Label lbl, Guna.UI2.WinForms.Guna2TextBox txt)
        {
            lbl.Text = txt.Text;
            txt.Visible = false;
            lbl.Visible = true;
        }

        bool isQuyDinhTienRutValid(string quyDinhTienRut)
        {
            if (quyDinhTienRut != "Toàn phần" && quyDinhTienRut != "Một phần hoặc toàn phần")
            {
                MessageBox.Show("Quy định số tiền rút không hợp lệ");
                return false;
            }
            return true;
        }
        bool isLaiSuatValid(string laiSuat)
        {
            
            if (double.TryParse(laiSuat, out double result) == false || result <= 0)
            {
                MessageBox.Show("Lãi suất không hợp lệ");
                return false;
            }
            return true;
        }
        bool isThoiGianGuiToiThieuValid(string thoiGianGuiToiThieu)
        {
            if (int.TryParse(thoiGianGuiToiThieu, out int result) == false || result < 0)
            {
                MessageBox.Show("Thời gian gửi tối thiểu không hợp lệ");
                return false;
            }
            return true;
        }
        string getNumberFromDateString(string dateString)
        {
            /// Lấy số từ chuỗi "x ngày" hoặc "x tháng"
            string[] phanTach = dateString.Split(' ');
            string so = phanTach[0];
            int soInt = int.Parse(so);
            return soInt.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (btnSua.Text == "Sửa")
            {
                ToggleToEditMode(lblLaiSuat, txtLaiSuat);
                ToggleToEditMode(lblThoiGianGuiToiThieu, txtThoiGianGuiToiThieu);

                // Hiện TextBox nhập lãi suất
                lblThoiGianGuiToiThieu.Visible = false;
                txtThoiGianGuiToiThieu.Visible = true;
                txtThoiGianGuiToiThieu.Text = getNumberFromDateString(lblThoiGianGuiToiThieu.Text);

                // Hiện combox chọn Quy định tiền rút
                lblInputQuyDinhSoTienRut.Visible = false;
                cboxQuyDinhTienRut.Visible = true;
                cboxQuyDinhTienRut.SelectedIndex = cboxQuyDinhTienRut.Items.IndexOf(lblInputQuyDinhSoTienRut.Text);

                btnSua.Text = "Cập nhật";
            }
            else
            {
                if (!isLaiSuatValid(txtLaiSuat.Text) || !isThoiGianGuiToiThieuValid(txtThoiGianGuiToiThieu.Text) || !isQuyDinhTienRutValid(cboxQuyDinhTienRut.Text)) {
                    return;
                }
                string formatedQuyDinhTienRut = "";
                if (cboxQuyDinhTienRut.Text == "Toàn phần")
                {
                    formatedQuyDinhTienRut = "=";
                }
                else
                {
                    formatedQuyDinhTienRut = "<=";
                }
                bool response = _loaiTietKiemBUS.updateLoaiTietKiem(new LoaiTietKiem()
                {
                    MaLoaiTietKiem = _loaiTietKiem.MaLoaiTietKiem,
                    KyHan = _loaiTietKiem.KyHan,
                    LaiSuat = float.Parse(txtLaiSuat.Text),
                    SoNgayToiThieuDuocRutTien = int.Parse(txtThoiGianGuiToiThieu.Text) * 30,
                    QuyDinhSoTienRut = formatedQuyDinhTienRut
                });
                if (response)
                {
                    MessageBox.Show("Cập nhật thành công");
                    reload();
                    Close();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại");
                    SaveFromTextBox(lblLaiSuat, txtLaiSuat);
                    SaveFromTextBox(lblThoiGianGuiToiThieu, txtThoiGianGuiToiThieu);

                    // Ẩn TextBox nhập lãi suất
                    lblThoiGianGuiToiThieu.Text = txtThoiGianGuiToiThieu.Text + " tháng";
                    lblThoiGianGuiToiThieu.Visible = true;
                    txtThoiGianGuiToiThieu.Visible = false;

                    // Ẩn combox chọn Quy định tiền rút
                    lblInputQuyDinhSoTienRut.Text = cboxQuyDinhTienRut.Text;
                    lblInputQuyDinhSoTienRut.Visible = true;
                    cboxQuyDinhTienRut.Visible = false;

                    btnSua.Text = "Sửa";
                }
            }

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtAdjustRate_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
