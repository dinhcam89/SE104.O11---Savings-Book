using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using BUS;
using System.Windows.Forms.DataVisualization.Charting;
using DTO;
using OfficeOpenXml;
using ExcelLicenseContext = OfficeOpenXml.LicenseContext;
using DAO;


namespace GUI.DashboardApp
{

    public partial class ucDoanhSoHoatDong : UserControl
    {
        private BieuDoBUS bieuDoBUS = new BieuDoBUS();
        private BaoCaoBUS baoCaoBUS = new BaoCaoBUS();
        public ucDoanhSoHoatDong()
        {
            InitializeComponent();
            UpdateDetailChart();
            HienThiDashBoardTongThu();
            ExcelPackage.LicenseContext = ExcelLicenseContext.NonCommercial;
            DTP_BieuDoTongChi.Format = DateTimePickerFormat.Custom;
            DTP_BieuDoTongChi.CustomFormat = "MM/yyyy";
            DTP_BieuDoTienGuiTheoThang.Format = DateTimePickerFormat.Custom;
            DTP_BieuDoTienGuiTheoThang.CustomFormat = "MM/yyyy";
            DTP_BieuDoTienGuiTheoThang.MaxDate = DateTime.Now;
            //DTP_BieuDoTienGuiTheoThang.ShowUpDown = true;
            guna2Panel19.Size = new System.Drawing.Size(220, 100);
            guna2Panel20.Size = new System.Drawing.Size(220, 100);
            guna2Panel21.Size = new System.Drawing.Size(220, 100);

        }

        #region CÁC HÀM XỬ LÝ XUẤT CHO DASHBOARD TỔNG QUAN VÀ TỔNG THU
        ////////////////////////////////////////////////////////////////////////////
        /**      CÁC HÀM XỬ LÝ XUẤT CHO DASHBOARD TỔNG QUAN VÀ TỔNG THU          **/
        ////////////////////////////////////////////////////////////////////////////
        private void chartRevenue_Load(object sender, EventArgs e)
        {
            // Cấu hình kiểu biểu đồ, nếu cần

            // Gọi hàm cập nhật dữ liệu
        }

        private void chartExpenditure_Load(object sender, EventArgs e)
        {
            // Thêm các lựa chọn kỳ hạn vào ComboBox
            cbbox_TuyChonBieuDo.Items.Add("Tất cả kỳ hạn");
            cbbox_TuyChonBieuDo.Items.Add("Không kỳ hạn");
            cbbox_TuyChonBieuDo.Items.Add("Kỳ hạn 30 ngày");
            cbbox_TuyChonBieuDo.Items.Add("Kỳ hạn 60 ngày");
            cbbox_TuyChonBieuDo.Items.Add("Kỳ hạn 90 ngày");
            cbbox_TuyChonBieuDo.Items.Add("Kỳ hạn 120 ngày");


            // Đặt lựa chọn mặc định
            cbbox_TuyChonBieuDo.SelectedIndex = 0;  // "Tất cả kỳ hạn"

            // Cập nhật biểu đồ khi tải
            UpdateChartData("Tất cả kỳ hạn");
        }



        private void chartDifference_Load(object sender, EventArgs e)
        {
            var differenceSeries = new Guna.Charts.WinForms.GunaBarDataset();
            differenceSeries.Label = "Mức chênh lệch";

            // Giá trị doanh thu và chi tiêu
            int revenueNoTerm = 10; // Giá trị từ chartRevenue
            int expenditureNoTerm = 15; // Giá trị từ chartExpenditure

            int revenue3Months = 20; // Giá trị từ chartRevenue
            int expenditure3Months = 30; // Giá trị từ chartExpenditure

            int revenue6Months = 30; // Giá trị từ chartRevenue
            int expenditure6Months = 6; // Giá trị từ chartExpenditure

            // Tính toán chênh lệch
            differenceSeries.DataPoints.Add("Không kỳ hạn", revenueNoTerm - expenditureNoTerm);
            differenceSeries.DataPoints.Add("Kỳ hạn 3 tháng", revenue3Months - expenditure3Months);
            differenceSeries.DataPoints.Add("Kỳ hạn 6 tháng", revenue6Months - expenditure6Months);

            // Thêm dataset vào biểu đồ chênh lệch
            chart_TongChiTheoKyHanVaThang.Datasets.Add(differenceSeries);
            chart_TongChiTheoKyHanVaThang.Update();
        }

        private void ucDoanhSoHoatDong_Load(object sender, EventArgs e)
        {

            try
            {
                // Lấy và hiển thị tổng số khách hàng
                int totalCustomers = bieuDoBUS.GetTotalCustomers();
                lbl_SoLuongKhachHang.Text = totalCustomers.ToString();

                // Lấy và hiển thị tổng số phiếu gửi tiền
                int totalSavingsAccounts = bieuDoBUS.GetTotalSavingsAccounts();
                lbl_SoLuongPhieuGuiTien.Text = totalSavingsAccounts.ToString();

                // Lấy và hiển thị tổng số tiền gửi
                decimal totalSavingsAmount = bieuDoBUS.GetTotalSavingsAmount();
                lbl_TongTienGui.Text = formatSoTien(((double)totalSavingsAmount));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
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

        private void cbbox_TuyChonBieuDo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy giá trị của lựa chọn trong ComboBox
            string selectedKyHan = cbbox_TuyChonBieuDo.SelectedItem.ToString();

            // Cập nhật dữ liệu và biểu đồ tương ứng với lựa chọn kỳ hạn
            UpdateChartData(selectedKyHan);
        }

        private void UpdateChartData(string kyHan)
        {
            // Giá trị kỳ hạn mặc định
            int kyHanValue = 0;

            // Sử dụng switch hoặc ánh xạ kỳ hạn
            switch (kyHan)
            {
                case "Tất cả kỳ hạn":
                    kyHanValue = -1;  // Tất cả kỳ hạn
                    break;

                case "Không kỳ hạn":
                    kyHanValue = 0;  // Không kỳ hạn
                    break;

                case "Kỳ hạn 30 ngày":
                    kyHanValue = 3;  // Kỳ hạn 30 ngày
                    break;

                case "Kỳ hạn 60 ngày":
                    kyHanValue = 6;  // Kỳ hạn 60 ngày
                    break;

                default:
                    break;
            }

            // Lấy dữ liệu tổng tiền gửi theo tháng và kỳ hạn
            var savingsData = bieuDoBUS.GetSavingsByMonthAndTerm(kyHanValue.ToString()); // Gọi hàm với giá trị số kỳ hạn

            // Tạo một dataset mới cho biểu đồ
            var barSeries = new Guna.Charts.WinForms.GunaBarDataset
            {
                Label = $"Tổng tiền gửi ({kyHan})", // Gán label cho cả dataset
                BorderWidth = 2,                  // Độ dày của cột
            };

            // Duyệt qua dữ liệu và thêm điểm dữ liệu vào dataset
            foreach (var monthData in savingsData)
            {
                string month = monthData.Key; // Tên tháng (ví dụ: "01/2024")
                decimal totalAmount = monthData.Value.Values.Sum(); // Tính tổng cho tất cả các kỳ hạn trong tháng

                // Thêm dữ liệu vào dataset (cột)
                barSeries.DataPoints.Add(month, Convert.ToDouble(totalAmount));
            }

            // Xóa dữ liệu cũ trên biểu đồ
            chart_TongTienGuiTheoThang.Datasets.Clear();

            // Thêm dataset vào biểu đồ
            chart_TongTienGuiTheoThang.Datasets.Add(barSeries);

            // Cập nhật biểu đồ
            chart_TongTienGuiTheoThang.Update();
        }
        private void chart_TienGuiNgayTheoKyHan_Load(object sender, EventArgs e)
        {
            DateTime thangDuocChon = DTP_BieuDoTongChi.Value; // Lấy giá trị tháng được chọn
            var tongTienTheoKyHan = bieuDoBUS.LayTongSoTienRutTheoKyHan(thangDuocChon); // Lấy dữ liệu từ cơ sở dữ liệu
            HienThiDuLieuLenGunaChart(chart_TongChiTheoKyHanVaThang, tongTienTheoKyHan); // Hiển thị lên biểu đồ
        }
        private void UpdateChartDataByMonth(DateTime selectedDate)
        {
            // Lấy dữ liệu tổng tiền gửi theo ngày và kỳ hạn
            var savingsData = bieuDoBUS.GetSavingsByDateAndTerm(selectedDate);

            // Kiểm tra xem savingsData có dữ liệu không
            if (savingsData == null || savingsData.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu cho tháng này.");
                return;
            }

            // Danh sách các kỳ hạn: 0 kỳ hạn, 3 tháng, 6 tháng
            var kyHanList = new List<int> { 0, 3, 6 };

            // Xóa dữ liệu cũ trên biểu đồ
            chart_TienGuiNgayTheoKyHan.Datasets.Clear();

            // Lấy phần năm và tháng của selectedDate
            int selectedYear = selectedDate.Year;
            int selectedMonth = selectedDate.Month;

            // Duyệt qua tất cả các kỳ hạn và kiểm tra xem có dữ liệu cho tháng/năm được chọn
            foreach (int kyHan in kyHanList)
            {
                if (savingsData.ContainsKey(kyHan))
                {
                    var monthlyData = savingsData[kyHan]; // Lấy dữ liệu cho kỳ hạn này

                    // Tính tổng số tiền gửi trong tháng được chọn
                    decimal totalAmountForMonth = 0;
                    foreach (var date in monthlyData.Keys)
                    {
                        if (date.Year == selectedYear && date.Month == selectedMonth)
                        {
                            totalAmountForMonth += monthlyData[date]; // Cộng dồn tổng số tiền gửi cho tháng này
                        }
                    }

                    // Nếu có dữ liệu cho tháng này thì hiển thị trên biểu đồ
                    if (totalAmountForMonth > 0)
                    {
                        // Tạo một dataset mới cho từng kỳ hạn
                        var barSeries = new Guna.Charts.WinForms.GunaBarDataset
                        {
                            Label = $"Kỳ hạn {kyHan} tháng",
                            BorderWidth = 2 // Độ dày cột
                        };

                        // Thêm dữ liệu vào dataset (cột cho kỳ hạn này)
                        barSeries.DataPoints.Add($"{selectedDate.ToString("MM/yyyy")}", Convert.ToDouble(totalAmountForMonth));

                        // Thêm dataset vào biểu đồ
                        chart_TienGuiNgayTheoKyHan.Datasets.Add(barSeries);
                    }
                }
            }

            // Cập nhật biểu đồ
            chart_TienGuiNgayTheoKyHan.Update();
            chart_TienGuiNgayTheoKyHan.Invalidate();
        }






        private void DTPDoanhSoHoatDong_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = DTP_BieuDoTienGuiTheoThang.Value;

            // Cập nhật biểu đồ với ngày đã chọn
            UpdateChartDataByMonth(selectedDate);
        }
        private void UpdateDetailChart()
        {
            lb_SoPhieu0KyHan.Text = bieuDoBUS.GetTotalSavingsAccountsByTerm("LTK0000000").ToString();
            lb_SoPhieu3Thang.Text = bieuDoBUS.GetTotalSavingsAccountsByTerm("LTK0000001").ToString();
            lb_SoPhieu6Thang.Text = bieuDoBUS.GetTotalSavingsAccountsByTerm("LTK0000002").ToString();

            lb_TongTienGui0KyHan.Text = formatSoTien((double)bieuDoBUS.GetTotalSavingsAmountByTerm("LTK0000000")); // Gọi hàm với giá trị số kỳ hạn
            lb_TongTienGui3Thang.Text = formatSoTien((double)bieuDoBUS.GetTotalSavingsAmountByTerm("LTK0000001")); // Gọi hàm với giá trị số kỳ hạn
            lb_TongTienGui6Thang.Text = formatSoTien((double)bieuDoBUS.GetTotalSavingsAmountByTerm("LTK0000002")); ; // Gọi hàm với giá trị số kỳ hạn
        }
        #endregion

        #region CÁC HÀM XỬ LÝ XUẤT CHO DASHBOARD TỔNG CHI
        /////////////////////////////////////////////////////////////////
        /**         CÁC HÀM XỬ LÝ XUẤT CHO DASHBOARD TỔNG CHI          **/
        /////////////////////////////////////////////////////////////////

        public void HienThiDashBoardTongThu()
        {
            // Lấy tổng số tiền đã chi
            float tongSoTienDaChi = bieuDoBUS.LayTongSoTienDaChi();
            lb_TONGTIENRUT.Text = formatSoTien(tongSoTienDaChi);

            var withdrawalsByTerm = bieuDoBUS.GetWithdrawalsByTerm();
            decimal totalWithdrawal0Month = withdrawalsByTerm.ContainsKey(0) ? withdrawalsByTerm[0] : 0;
            decimal totalWithdrawal3Month = withdrawalsByTerm.ContainsKey(3) ? withdrawalsByTerm[3] : 0;
            decimal totalWithdrawal6Month = withdrawalsByTerm.ContainsKey(6) ? withdrawalsByTerm[6] : 0;
            lb_TongChiKyHan0.Text = formatSoTien((double)totalWithdrawal0Month);
            lb_TongChiKyHan3Thang.Text = formatSoTien((double)totalWithdrawal3Month);
            lb_TongChiKyHan6Thang.Text = formatSoTien((double)totalWithdrawal6Month);
        }

        private void HienThiDuLieuLenGunaChart(Guna.Charts.WinForms.GunaChart chart, Dictionary<string, float> duLieu)
        {
            // Xóa dữ liệu cũ
            chart.Datasets.Clear();

            // Tạo dataset mới
            var dataset = new Guna.Charts.WinForms.GunaBarDataset
            {
                Label = "Tổng số tiền rút", // Nhãn của dữ liệu
                BorderWidth = 1
            };

            // Thêm dữ liệu vào dataset
            foreach (var item in duLieu)
            {
                dataset.DataPoints.Add(new Guna.Charts.WinForms.LPoint(item.Key, item.Value));
            }
            // Thêm dataset vào biểu đồ
            chart.Datasets.Add(dataset);

            // Cập nhật biểu đồ
            chart.Update();
        }


        private void DTP_BieuDoTongChi_ValueChanged(object sender, EventArgs e)
        {
            DateTime thangDuocChon = DTP_BieuDoTongChi.Value; // Lấy giá trị tháng được chọn
            var tongTienTheoKyHan = bieuDoBUS.LayTongSoTienRutTheoKyHan(thangDuocChon); // Lấy dữ liệu từ cơ sở dữ liệu
            HienThiDuLieuLenGunaChart(chart_TongChiTheoKyHanVaThang, tongTienTheoKyHan); // Hiển thị lên biểu đồ
        }

        #endregion
    }

}
