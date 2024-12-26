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
                    Ten1 = item.SoTaiKhoanTienGui,
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

        private void btnXuatBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel files (*.xlsx)|*.xlsx",
                    FileName = "BaoCaoChiTietGuiTien.xlsx"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Lấy dữ liệu từ danh sách
                    List<DTO.ChiTietGuiTien> listItems = hienThiBUS.GetTenKhachHang();

                    using (var workbook = new ClosedXML.Excel.XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("ChiTietGuiTien");

                        // Tiêu đề cột
                        worksheet.Cell(1, 1).Value = "Số Tài Khoản";
                        worksheet.Cell(1, 2).Value = "Tên Khách Hàng";
                        worksheet.Cell(1, 3).Value = "Ngày Gửi";
                        worksheet.Cell(1, 4).Value = "Số Tiền Gửi";

                        // Định dạng tiêu đề
                        var headerRange = worksheet.Range(1, 1, 1, 4);
                        headerRange.Style.Font.Bold = true;
                        headerRange.Style.Alignment.Horizontal = ClosedXML.Excel.XLAlignmentHorizontalValues.Center;

                        // Dữ liệu
                        for (int i = 0; i < listItems.Count; i++)
                        {
                            var item = listItems[i];

                            worksheet.Cell(i + 2, 1).Value = item.SoTaiKhoanTienGui;
                            worksheet.Cell(i + 2, 2).Value = item.TenKhachHang;
                            worksheet.Cell(i + 2, 3).Value = item.NgayGui;
                            worksheet.Cell(i + 2, 4).Value = item.SoTienGui;

                            // Định dạng dữ liệu
                            worksheet.Cell(i + 2, 3).Style.DateFormat.Format = "dd/MM/yyyy";
                            worksheet.Cell(i + 2, 4).Style.NumberFormat.Format = "$#,##0.00";
                        }

                        // Định dạng bảng
                        var tableRange = worksheet.Range(1, 1, listItems.Count + 1, 4);
                        tableRange.Style.Border.OutsideBorder = ClosedXML.Excel.XLBorderStyleValues.Thin;
                        tableRange.Style.Border.InsideBorder = ClosedXML.Excel.XLBorderStyleValues.Thin;

                        // Tự động căn chỉnh độ rộng cột
                        worksheet.Columns().AdjustToContents();

                        // Lưu file
                        workbook.SaveAs(saveFileDialog.FileName);
                    }

                    MessageBox.Show("Xuất báo cáo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi xuất báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
