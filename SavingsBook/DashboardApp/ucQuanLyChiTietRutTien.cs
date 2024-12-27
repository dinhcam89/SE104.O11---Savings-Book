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
        List<DTO.ChiTietRutTien> chiTietRutTiens;

        public ucQuanLyChiTietRutTien()
        {
            InitializeComponent();
            chiTietRutTiens = hienThiBUS.GetAllChiTietRutTien();
        }

        private void ucQuanLyChiTietRutTien_Load(object sender, EventArgs e)
        {
            populateItems(chiTietRutTiens);
        }
        private void dtpTuNgay_ValueChanged(object sender, EventArgs e)
        {
            if (dtpTuNgay.Value.Date > dtpDenNgay.Value.Date)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpTuNgay.Value = dtpDenNgay.Value;
            }
            else
            {
                LocTheoNgay();
            }
        }

        private void dtpDenNgay_ValueChanged(object sender, EventArgs e)
        {
            if (dtpDenNgay.Value.Date < dtpTuNgay.Value.Date)
            {
                MessageBox.Show("Ngày kết thúc không được nhỏ hơn ngày bắt đầu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpDenNgay.Value = dtpTuNgay.Value;
            }
            else
            {
                LocTheoNgay();
            }
        }

        private void populateItems(List<DTO.ChiTietRutTien> ctrts)
        {
            flowLayoutPanel1.Controls.Clear();

            foreach (var item in ctrts)
            {
                ListItem listItem = new ListItem
                {
                    Ten1 = item.SoTaiKhoanTienGoi,
                    Ten2 = item.NgayRut.ToString("dd/MM/yyyy"),
                    Ten3 = formatSoTien(item.SoTienRut),
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
        private void LocTheoNgay()
        {
            DateTime startDate = dtpTuNgay.Value.Date;
            DateTime endDate = dtpDenNgay.Value.Date;

            // Lấy danh sách phiếu trong khoảng thời gian
            List<DTO.ChiTietRutTien> filteredItems = hienThiBUS.GetNgay(startDate, endDate);

            // Cập nhật giao diện
            flowLayoutPanel1.Controls.Clear();

            foreach (var item in filteredItems)
            {
                ListItem listItem = new ListItem
                {
                    Ten1 = item.SoTaiKhoanTienGoi,
                    Ten2 = item.NgayRut.ToString("dd/MM/yyyy"),
                    Ten3 = formatSoTien(item.SoTienRut),
                    Ten4 = "",
                    FormType = ObjectType.PhieuGoiTien,
                    IsButtonVisible = false
                };

                flowLayoutPanel1.Controls.Add(listItem);
            }
        }
        private void btnXuatBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel files (*.xlsx)|*.xlsx",
                    FileName = "BaoCaoChiTietRutTien.xlsx"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    DateTime tuNgay = dtpTuNgay.Value.Date;
                    DateTime denNgay = dtpDenNgay.Value.Date;

                    // Lấy danh sách ChiTietRutTien đã lọc theo ngày
                    List<DTO.ChiTietRutTien> filteredItems = hienThiBUS.GetNgay(tuNgay, denNgay);

                    // Lấy danh sách tên khách hàng
                    List<DTO.ChiTietRutTien> customerNames = hienThiBUS.GetTenKhachHang();

                    using (var workbook = new ClosedXML.Excel.XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("ChiTietGuiTien");

                        // Tiêu đề cột
                        worksheet.Cell(1, 1).Value = "Số Tài Khoản";
                        worksheet.Cell(1, 2).Value = "Tên Khách Hàng";
                        worksheet.Cell(1, 3).Value = "Ngày Rút";
                        worksheet.Cell(1, 4).Value = "Số Tiền Rút";

                        var headerRange = worksheet.Range(1, 1, 1, 4);
                        headerRange.Style.Font.Bold = true;
                        headerRange.Style.Alignment.Horizontal = ClosedXML.Excel.XLAlignmentHorizontalValues.Center;

                        for (int i = 0; i < filteredItems.Count; i++)
                        {
                            var item = filteredItems[i];

                            var customer = customerNames.FirstOrDefault(c => c.SoTaiKhoanTienGoi == item.SoTaiKhoanTienGoi);

                            worksheet.Cell(i + 2, 1).Value = item.SoTaiKhoanTienGoi;
                            worksheet.Cell(i + 2, 2).Value = customer != null ? customer.TenKhachHang : "Không tìm thấy";
                            worksheet.Cell(i + 2, 3).Value = item.NgayRut;
                            worksheet.Cell(i + 2, 4).Value = item.SoTienRut;

                            worksheet.Cell(i + 2, 3).Style.DateFormat.Format = "dd/MM/yyyy";
                            worksheet.Cell(i + 2, 4).Style.NumberFormat.Format = "#,##0.00";
                        }

                        var tableRange = worksheet.Range(1, 1, filteredItems.Count + 1, 4);
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

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            populateItems(hienThiBUS.SearchChiTietRutTien(txtTimKiem.Text));
        }
    }

}
