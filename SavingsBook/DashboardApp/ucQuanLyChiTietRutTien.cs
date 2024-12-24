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
using DTO;

namespace GUI.DashboardApp
{
    public partial class ucQuanLyChiTietRutTien : UserControl
    {
        private HienThiChiTietRutTienBUS hienThiBUS = new HienThiChiTietRutTienBUS();
        public ucQuanLyChiTietRutTien()
        {
            InitializeComponent();
        }

        private void ucQuanLyChiTietRutTien_Load(object sender, EventArgs e)
        {
            populateItems();
        }

        private void populateItems()
        {
            // Lấy dữ liệu từ BUS, đảm bảo kiểu trả về là List<DTO.ChiTietGuiTien>
            List<DTO.ChiTietRutTien> listItems = hienThiBUS.GetAllChiTietRutTien();

            // Xóa các item cũ trong flowLayoutPanel trước khi thêm mới
            flowLayoutPanel1.Controls.Clear();

            // Duyệt qua danh sách và thêm item vào FlowLayoutPanel
            foreach (var item in listItems)
            {
                ListItem listItem = new ListItem
                {
                    Ten1 = item.MaChiTietRutTien,
                    Ten2 = item.NgayRut.ToString("dd/MM/yyyy"),
                    Ten3 = item.SoTienRut.ToString("C"), // Hiển thị số tiền theo định dạng tiền tệ
                    Ten4 = "", // Nếu có dữ liệu khác cần hiển thị, bạn có thể gán ở đây
                    FormType = ObjectType.PhieuGoiTien,
                    IsButtonVisible = false // Ẩn nút nếu cần
                };

                flowLayoutPanel1.Controls.Add(listItem);
            }

            // Đảm bảo các item trong flowLayoutPanel có độ rộng phù hợp khi resize form
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
