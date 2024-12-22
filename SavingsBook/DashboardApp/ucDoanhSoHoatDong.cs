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

namespace GUI.DashboardApp
{

    public partial class ucDoanhSoHoatDong : UserControl
    {
<<<<<<< HEAD
        private BieuDoBUS bieuDoBUS = new BieuDoBUS();
=======
      
>>>>>>> b9113d9 (Initial commit)

        public ucDoanhSoHoatDong()
        {
            InitializeComponent();
            UpdateDetailChart();
        }

        private void chartRevenue_Load(object sender, EventArgs e)
        {
<<<<<<< HEAD
            // Cấu hình kiểu biểu đồ, nếu cần
            //chart_DoanhThuTheoKyHan.Type = Guna.Charts.WinForms.ChartType.Line; // Đặt biểu đồ là Line

            // Đặt thuộc tính chung cho biểu đồ (nếu chưa làm ở nơi khác)
            //chart_DoanhThuTheoKyHan.YAxes.GridLines.Display = true; // Hiển thị lưới ngang
            //chart_DoanhThuTheoKyHan.XAxes.GridLines.Display = false; // Ẩn lưới dọc
            //chart_DoanhThuTheoKyHan.Legend.Display = true; // Hiển thị chú thích
            //chart_DoanhThuTheoKyHan.Title.Text = "Doanh thu theo tháng của từng kỳ hạn";

            // Gọi hàm cập nhật dữ liệu
=======
           
>>>>>>> b9113d9 (Initial commit)
        }

        private void chartExpenditure_Load(object sender, EventArgs e)
        {
<<<<<<< HEAD
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
=======
            
>>>>>>> b9113d9 (Initial commit)
        }



        private void chartDifference_Load(object sender, EventArgs e)
        {
<<<<<<< HEAD
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
            chartChenhLech.Datasets.Add(differenceSeries);
            chartChenhLech.Update();
=======
           
>>>>>>> b9113d9 (Initial commit)
        }

        private void ucDoanhSoHoatDong_Load(object sender, EventArgs e)
        {

<<<<<<< HEAD
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
                lbl_TongTienGui.Text = totalSavingsAmount.ToString("C") + " VNĐ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
=======
           
>>>>>>> b9113d9 (Initial commit)
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
<<<<<<< HEAD
            // Giá trị kỳ hạn mặc định
            int kyHanValue = 0;

            // Sử dụng switch hoặc nếu bạn muốn có cách dễ dàng, chỉ cần chuyển trực tiếp
            switch (kyHan)
            {
                case "Tất cả kỳ hạn":
                    kyHanValue = -1;  // Tất cả kỳ hạn
                    break;

                case "Không kỳ hạn":
                    kyHanValue = 0;  // Không kỳ hạn
                    break;

                case "Kỳ hạn 30 ngày":
                    kyHanValue = 30;  // Kỳ hạn 30 ngày
                    break;

                case "Kỳ hạn 60 ngày":
                    kyHanValue = 60;  // Kỳ hạn 60 ngày
                    break;

                case "Kỳ hạn 90 ngày":
                    kyHanValue = 90;  // Kỳ hạn 90 ngày
                    break;

                case "Kỳ hạn 120 ngày":
                    kyHanValue = 120;  // Kỳ hạn 120 ngày
                    break;

                default:
                    break;
            }

            // Lấy dữ liệu tổng tiền gửi theo tháng và kỳ hạn
            var savingsData = bieuDoBUS.GetSavingsByMonthAndTerm(kyHanValue.ToString()); // Gọi hàm với giá trị số kỳ hạn

            // Tạo một dataset mới cho biểu đồ
            var barSeries = new Guna.Charts.WinForms.GunaBarDataset();
            barSeries.Label = "Tổng Tiền Gửi";

            // Duyệt qua dữ liệu và thêm điểm dữ liệu vào biểu đồ
            foreach (var monthData in savingsData)
            {
                string month = monthData.Key;

                // Tổng tiền gửi cho mỗi tháng
                decimal totalAmount = monthData.Value.Values.Sum();  // Tính tổng cho tất cả các kỳ hạn trong tháng
                int totalAmountInt = Convert.ToInt32(totalAmount);

                // Thêm dữ liệu vào dataset
                barSeries.DataPoints.Add(month, totalAmountInt);
            }

            // Xóa dữ liệu cũ trên biểu đồ
            chart_TongTienGuiTheoThang.Datasets.Clear();

            // Thêm dataset vào biểu đồ
            chart_TongTienGuiTheoThang.Datasets.Add(barSeries);

            // Cập nhật biểu đồ
            chart_TongTienGuiTheoThang.Update();
=======
           

            
>>>>>>> b9113d9 (Initial commit)
        }

        private void chart_TienGuiNgayTheoKyHan_Load(object sender, EventArgs e)
        {

        }
        private void UpdateChartDataByDay(DateTime selectedDate)
        {
<<<<<<< HEAD
            // Lấy dữ liệu tổng tiền gửi theo ngày và kỳ hạn
            var savingsData = bieuDoBUS.GetSavingsByDateAndTerm(selectedDate);

            // Kiểm tra xem savingsData có dữ liệu không
            if (savingsData == null || savingsData.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu cho ngày này.");
                return;
            }

            // Danh sách các kỳ hạn
            var kyHanList = new List<int> { 0, 30, 60, 90, 120 }; // Không kỳ hạn, 30, 60, 90, 120 ngày

            // Xóa dữ liệu cũ trên biểu đồ
            chart_TienGuiNgayTheoKyHan.Datasets.Clear();

            // Lấy phần ngày của selectedDate
            DateTime selectedDateOnly = selectedDate.Date; // Chỉ lấy phần ngày, bỏ giờ, phút, giây

            foreach (int kyHan in kyHanList)
            {
                // Tạo một dataset mới cho từng kỳ hạn
                var barSeries = new Guna.Charts.WinForms.GunaBarDataset
                {
                    Label = $"Kỳ hạn {kyHan} ngày",
                    BorderWidth = 2 // Độ dày cột
                };

                // Kiểm tra dữ liệu cho kỳ hạn
                if (savingsData.ContainsKey(kyHan))
                {
                    var dailyData = savingsData[kyHan]; // Lấy dữ liệu cho kỳ hạn này

                    // Kiểm tra nếu có dữ liệu cho ngày người dùng chọn (chỉ so sánh phần ngày)
                    bool foundData = false;
                    foreach (var date in dailyData.Keys)
                    {
                        if (date.Date == selectedDateOnly) // So sánh chỉ phần ngày
                        {
                            decimal totalAmount = dailyData[date]; // Số tiền gửi cho ngày này

                            // Thêm dữ liệu vào dataset (cột cho ngày này)
                            barSeries.DataPoints.Add(date.ToString("yyyy/MM/dd"), Convert.ToDouble(totalAmount));
                            foundData = true;
                            break; // Dừng vòng lặp khi đã tìm thấy dữ liệu cho ngày
                        }
                    }

                    if (foundData)
                    {
                        // Thêm dataset vào biểu đồ
                        chart_TienGuiNgayTheoKyHan.Datasets.Add(barSeries);
                    }
                    else
                    {
                        // Debug: In ra thông báo nếu không có dữ liệu cho ngày chọn
                        //MessageBox.Show($"Không có dữ liệu cho ngày {selectedDateOnly} và kỳ hạn {kyHan} ngày");
                    }
                }
                else
                {
                    // Debug: In ra thông báo nếu không có dữ liệu cho kỳ hạn này
                    //MessageBox.Show($"Không có dữ liệu cho kỳ hạn {kyHan} ngày");
                }
            }

            // Cập nhật biểu đồ
            chart_TienGuiNgayTheoKyHan.Update();
            chart_TienGuiNgayTheoKyHan.Invalidate();
=======
            
>>>>>>> b9113d9 (Initial commit)
        }



        private void DTPDoanhSoHoatDong_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = DTPDoanhSoHoatDong.Value;

            // Cập nhật biểu đồ với ngày đã chọn
            UpdateChartDataByDay(selectedDate);
        }
        private void UpdateDetailChart()
        {
<<<<<<< HEAD
            lb_SoPhieu0KyHan.Text = bieuDoBUS.GetTotalSavingsAccountsByTerm(1).ToString();
            lb_SoPhieu3Thang.Text = bieuDoBUS.GetTotalSavingsAccountsByTerm(2).ToString();
            lb_SoPhieu6Thang.Text = bieuDoBUS.GetTotalSavingsAccountsByTerm(3).ToString();
            
            lb_TongTienGui0KyHan.Text = bieuDoBUS.GetTotalSavingsAmountByTerm(1).ToString("C") + " VNĐ"; // Gọi hàm với giá trị số kỳ hạn
            lb_TongTienGui3Thang.Text = bieuDoBUS.GetTotalSavingsAmountByTerm(2).ToString("C") + " VNĐ"; ; // Gọi hàm với giá trị số kỳ hạn
            lb_TongTienGui6Thang.Text = bieuDoBUS.GetTotalSavingsAmountByTerm(3).ToString("C") + " VNĐ"; ; // Gọi hàm với giá trị số kỳ hạn
=======
           
>>>>>>> b9113d9 (Initial commit)
        }
    }

}
