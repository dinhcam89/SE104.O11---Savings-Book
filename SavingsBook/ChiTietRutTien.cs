using BUS;
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
    public partial class ChiTietRutTien : Form
    {
        public ChiTietRutTien()
        {
            InitializeComponent();
        }

        private void ChiTietRutTien_Load(object sender, EventArgs e)
        {
            populateItems();
        }

        private void populateItems()
        {
            /*ListItem[] listItems = new ListItem[20];

            for (int i = 0; i < listItems.Length; i++)
            {
                listItems[i] = new ListItem();
                listItems[i].Ten1 = "Ngày rút " + i;
                listItems[i].Ten2 = "Số tiền " + i;
                listItems[i].Ten3 = "";
                listItems[i].Ten4 = "";
                    
                listItems[i].FormType = ObjectType.PhieuGoiTien;

                listItems[i].IsButtonVisible = false; // Ẩn nút

                flowLayoutPanel1.Controls.Add(listItems[i]);
            }

            flowLayoutPanel1.Resize += (s, e) =>
            {
                foreach (ListItem item in flowLayoutPanel1.Controls)
                {
                    item.Width = flowLayoutPanel1.ClientSize.Width;
                }
            };*/
            // Xóa các mục hiện có
            string maPhieu = lbMaPhieu.Text;
            flowLayoutPanel1.Controls.Clear();

            List<DTO.ChiTietRutTien> listChiTiet;

            try
            {
                // Tạo đối tượng BUS
                var hienthiBUS = new HienThiChiTietRutTienBUS();

                // Kiểm tra và lấy thông tin theo mã phiếu
                var chiTiet = hienthiBUS.GetChiTietGuiTienByMaPhieu(maPhieu);
                listChiTiet = chiTiet != null ? new List<DTO.ChiTietRutTien> { chiTiet } : new List<DTO.ChiTietRutTien>();

                if (listChiTiet.Count > 0)
                {
                    foreach (var item in listChiTiet)
                    {
                        var listItem = new ListItem
                        {
                            Ten1 = $"{item.NgayRut:dd/MM/yyyy}",
                            Ten2 = $"{item.SoTienRut:C}",
                            Ten3 = "",
                            Ten4 = "",
                            FormType = ObjectType.PhieuGoiTien,
                            IsButtonVisible = false

                        };

                        flowLayoutPanel1.Controls.Add(listItem);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy dữ liệu phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
