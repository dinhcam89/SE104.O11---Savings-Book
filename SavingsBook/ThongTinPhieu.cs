using BUS;
using DTO;
using GUI;

namespace SavingsBook
{
    public partial class ThongTinPhieu : Form
    {
        private string maPhieu;
        private PhieuGoiTienBUS phieuGoiTienBUS = new PhieuGoiTienBUS();
        public ThongTinPhieu(string maPhieu)
        {
            InitializeComponent();
            // Thiet lap khong thay doi kich thuoc form
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            this.maPhieu = maPhieu;
        }


        private void ThongTinPhieu_Load1(object sender, EventArgs e)
        {
            // Load thong tin phieu
            LoadThongTinPhieu();
        }
        private void LoadThongTinPhieu()
        {
            PhieuGoiTien phieuGoiTien = phieuGoiTienBUS.GetPhieuGoiTienBySoTaiKhoanTienGoi(maPhieu);
            // Load thong tin phieu tu database
            // Ma phieu
            lblSTKTienGoi.Text = phieuGoiTien.SoTaiKhoanTienGoi;
            // Lai suat phat sinh
            lblSTKThanhToan.Text = phieuGoiTien.SoTaiKhoanThanhToan;

            lblNgayGoi.Text = phieuGoiTien.NgayGoi.ToString();

            // Lai suat ap dung
            lblLaiSuatApDung.Text = phieuGoiTien.LaiSuatApDung.ToString();
            lblLaiSuatPhatSinh.Text = phieuGoiTien.LaiSuatPhatSinh.ToString();
            lblNgayDaoHanKeTiep.Text = phieuGoiTien.NgayDaoHanKeTiep.ToString();

            lblTongTienGoc.Text = phieuGoiTien.TongTienGoc.ToString();
            lblTongTienLaiPhatSinh.Text = phieuGoiTien.TongTienLaiPhatSinh.ToString();
            switch (phieuGoiTien.HinhThucGiaHan)
            {
                case 1:
                    lblHinhThucGiaHan.Text = "Không gia hạn";
                    break;
                case 2:
                    lblHinhThucGiaHan.Text = "Xoay vòng gốc";
                    break;
                case 3:
                    lblHinhThucGiaHan.Text = "Xoay vòng gốc lẫn lãi";
                    break;
                default:
                    break;
            }


        }



        private void ToggleToEditMode(Label lbl, Control editor)
        {
            lbl.Visible = false;
            editor.Visible = true;

            if (editor is Guna.UI2.WinForms.Guna2TextBox txt)
            {
                txt.Text = lbl.Text;
                txt.Focus();
            }
            else if (editor is ComboBox cbox)
            {
                cbox.Text = lbl.Text;
                cbox.Focus();
            }
        }



        private void SaveFromEditor(Label lbl, Control editor)
        {
            if (editor is Guna.UI2.WinForms.Guna2TextBox txt)
            {
                lbl.Text = txt.Text;
            }
            else if (editor is ComboBox cbox)
            {
                lbl.Text = cbox.Text;
            }

            editor.Visible = false;
            lbl.Visible = true;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ThongTinPhieu_Load(object sender, EventArgs e)
        {
            LoadThongTinPhieu();

        }
    }
}
