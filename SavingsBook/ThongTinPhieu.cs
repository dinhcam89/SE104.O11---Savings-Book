using BUS;
using DTO;
using GUI;

namespace SavingsBook
{
    public partial class ThongTinPhieu : Form
    {
        private string maPhieu;
        private PhieuGoiTienBUS phieuGoiTienBUS = new PhieuGoiTienBUS();
        private LoaiTietKiemBUS loaiTietKiemBUS = new LoaiTietKiemBUS();
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

            lblNgayGoi.Text = phieuGoiTien.NgayGoi.ToString("dd/MM/yyyy");

            // Lai suat ap dung
            lblLaiSuatApDung.Text = phieuGoiTien.LaiSuatApDung.ToString();
            lblLaiSuatPhatSinh.Text = phieuGoiTien.LaiSuatPhatSinh.ToString();
            lblNgayDaoHanKeTiep.Text = phieuGoiTien.NgayDaoHanKeTiep.ToString("dd/MM/yyyy");
            lblTongTienGoc.Text = formatSoTien(phieuGoiTien.TongTienGoc);
            lblTongTienLaiPhatSinh.Text = formatSoTien(phieuGoiTien.TongTienLaiPhatSinh);
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
            LoaiTietKiem maLoaiTietKiem = loaiTietKiemBUS.getLoaiTietKiem(phieuGoiTien.MaLoaiTietKiem);
            lbKyHan.Text = maLoaiTietKiem.KyHan + " tháng";
        }
        string formatSoTien(double sotien)
        {
            string formatedText;
            if (sotien == 0)
            {
                formatedText = sotien + " VND";
            }
            else
            {
                formatedText = sotien.ToString("#,#.##") + " VND";
            }
            return formatedText;
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
