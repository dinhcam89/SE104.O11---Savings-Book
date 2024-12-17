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

namespace GUI.DashboardApp
{
    public partial class ucQuanLyLoaiTietKiem : UserControl
    {
        private List<LoaiTietKiem> _loaiTietKiemList;
        private LoaiTietKiemBUS _loaiTietKiemBUS;
        public ucQuanLyLoaiTietKiem()
        {
            InitializeComponent();
            _loaiTietKiemBUS = new LoaiTietKiemBUS();
            _loaiTietKiemList = new List<LoaiTietKiem>();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ThemLoaiTietKiem addForm = new ThemLoaiTietKiem();
            addForm.ShowDialog();
        }

        private void ucEditAdjustRate_Load(object sender, EventArgs e)
        {
        }

        private void populateItems(List<LoaiTietKiem> loaiTietKiem)
        {
            ListItem[] listItems = new ListItem[loaiTietKiem.Count];
            flowLayoutPanel1.Controls.Clear();

            for (int i = 0; i < listItems.Length; i++)
            {
                listItems[i] = new ListItem();
                listItems[i].Ten1 = loaiTietKiem[i].MaLoaiTietKiem.ToString() ?? "";
                listItems[i].Ten2 = loaiTietKiem[i].KyHan.ToString() ?? "";
                listItems[i].Ten3 = loaiTietKiem[i].LaiSuat.ToString() ?? "";
                listItems[i].Ten4 = loaiTietKiem[i].SoNgayToiThieuDuocRutTien.ToString() ?? "";
                listItems[i].FormType = ObjectType.LoaiTietKiem;

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

        private void ucQuanLyLoaiTietKiem_Layout(object sender, LayoutEventArgs e)
        {
            _loaiTietKiemList = _loaiTietKiemBUS.getListLoaiTietKiem();
            populateItems(_loaiTietKiemList);
        }
    }
}
