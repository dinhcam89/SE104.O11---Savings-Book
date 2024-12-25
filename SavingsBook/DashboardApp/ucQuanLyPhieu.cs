using BUS;
using DTO;
using SavingsBook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.DashboardApp
{
    public partial class ucQuanLyPhieu : UserControl
    {
        List<PhieuGoiTien> phieuGoiTiens;
        private PhieuGoiTienBUS _phieuGoiTienBUS;
        public ucQuanLyPhieu()
        {
            InitializeComponent();
            _phieuGoiTienBUS = new PhieuGoiTienBUS();
            phieuGoiTiens = new List<PhieuGoiTien>();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ThemPhieu editCustomerInfor = new ThemPhieu();
            editCustomerInfor.Show();
        }

        private void ucManageSavingBooks_Load(object sender, EventArgs e)
        {
            loadItems();

        }
        private void loadItems()
        {
            phieuGoiTiens = _phieuGoiTienBUS.GetPhieuGoiTien();
            populateItems(phieuGoiTiens);
        }
        private void populateItems(List<PhieuGoiTien> phieuGoiTiens)
        {
            ListItem[] listItems = new ListItem[phieuGoiTiens.Count];

            for (int i = 0; i < listItems.Length; i++)
            {
                // Lấy loại kỳ hạn của loại tiết kiệm
                LoaiTietKiem? ltk = new LoaiTietKiemBUS().getLoaiTietKiemById(phieuGoiTiens[i].MaLoaiTietKiem);

                if (ltk == null)
                {
                    continue;
                }

                listItems[i] = new ListItem();
                listItems[i].Ten1 = phieuGoiTiens[i].SoTaiKhoanTienGoi;
                listItems[i].Ten2 = phieuGoiTiens[i].TongTienGoc.ToString();
                listItems[i].Ten3 = ltk.KyHan.ToString();
                listItems[i].Ten4 = "";
                listItems[i].FormType = ObjectType.PhieuGoiTien;

                flowLayoutPanel1.Controls.Add(listItems[i]);
            }

            flowLayoutPanel1.Resize += (s, e) =>
            {
                foreach (ListItem item in flowLayoutPanel1.Controls)
                {
                    item.Width = flowLayoutPanel1.ClientSize.Width;
                }
            };

        }
    }
}
