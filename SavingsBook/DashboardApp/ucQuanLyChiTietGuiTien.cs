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
    public partial class ucQuanLyChiTietGuiTien : UserControl
    {
        private HienThiChiTietGuiTienBUS hienThiBUS = new HienThiChiTietGuiTienBUS();
        public ucQuanLyChiTietGuiTien()
        {
            InitializeComponent();
        }

        private void ucQuanLyChiTietGuiTien_Load(object sender, EventArgs e)
        {
            populateItems();
        }

        private void populateItems()
        {
            // Lấy dữ liệu từ BUS, đảm bảo kiểu trả về là List<DTO.ChiTietGuiTien>
            List<DTO.ChiTietGuiTien> listItems = hienThiBUS.GetAllChiTietGuiTien(); // Chú ý kiểu DTO.ChiTietGuiTien

            // Xóa các item cũ trong flowLayoutPanel trước khi thêm mới
            flowLayoutPanel1.Controls.Clear();

            // Duyệt qua danh sách và thêm item vào FlowLayoutPanel
            foreach (var item in listItems)
            {
                ListItem listItem = new ListItem
                {
                    Ten1 = item.SoTaiKhoanTienGoi,
                    Ten2 = item.NgayGui.ToString("dd/MM/yyyy"),
                    Ten3 = item.SoTienGui.ToString("C"), // Hiển thị số tiền theo định dạng tiền tệ
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
