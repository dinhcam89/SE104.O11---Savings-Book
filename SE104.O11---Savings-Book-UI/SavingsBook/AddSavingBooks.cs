using System;
using System.Windows.Forms;
using DTO;
using BUS;

namespace GUI
{
    public partial class AddSavingBooks : Form
    {
        private SavingBookBUS savingBookBUS = new SavingBookBUS();

        public AddSavingBooks()
        {
            InitializeComponent();
            customizeDesign();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            btnSave.Click += BtnSave_Click;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo một đối tượng DTO với các giá trị từ form
                SavingBookDTO savingBook = new SavingBookDTO
                {
                    TenKhachHang = txtUsername.Text,
                    CCCD_CMND = guna2TextBox1.Text,
                    DiaChi = guna2TextBox2.Text,
                    SoDienThoai = txtSDT.Text,
                    SoTienGoi = float.Parse(txtSoTienGui.Text),
                    NgayMoSo = dateTimePicker1.Value
                };

                // Xác định loại kỳ hạn và tính ngày đóng sổ
                switch (btnTypeMenu.Text)
                {
                    case "Kỳ hạn 1":
                        savingBook.MSLoaiTietKiem = 1;
                        savingBook.NgayDongSo = savingBook.NgayMoSo.AddYears(1);
                        break;
                    case "Kỳ hạn 2":
                        savingBook.MSLoaiTietKiem = 2;
                        savingBook.NgayDongSo = savingBook.NgayMoSo.AddYears(2);
                        break;
                    case "Kỳ hạn 3":
                        savingBook.MSLoaiTietKiem = 3;
                        savingBook.NgayDongSo = savingBook.NgayMoSo.AddYears(3);
                        break;
                    default:
                        MessageBox.Show("Vui lòng chọn loại kỳ hạn hợp lệ.");
                        return;
                }

                // Gọi BUS để thêm dữ liệu
                if (savingBookBUS.AddSavingBook(savingBook))
                {
                    MessageBox.Show("Lưu thông tin thành công!");
                }
                else
                {
                    MessageBox.Show("Không thể lưu thông tin. Vui lòng thử lại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        private void customizeDesign()
        {
            panelTypeMenu.Visible = false;
        }

        private void btnTypeMenu_Click(object sender, EventArgs e)
        {
            showSubMenu(panelTypeMenu);
        }

        private void btnType1_Click(object sender, EventArgs e)
        {
            btnTypeMenu.Text = "Kỳ hạn 1";
            hideSubMenu();
        }

        private void btnType2_Click(object sender, EventArgs e)
        {
            btnTypeMenu.Text = "Kỳ hạn 2";
            hideSubMenu();
        }

        private void btnType3_Click(object sender, EventArgs e)
        {
            btnTypeMenu.Text = "Kỳ hạn 3";
            hideSubMenu();
        }

        private void showSubMenu(Panel subMenu)
        {
            subMenu.Visible = !subMenu.Visible;
        }

        private void hideSubMenu()
        {
            panelTypeMenu.Visible = false;
        }
    }
}
