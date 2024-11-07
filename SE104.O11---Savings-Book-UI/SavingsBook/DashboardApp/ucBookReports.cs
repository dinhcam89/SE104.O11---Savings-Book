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
    public partial class ucBookReports : UserControl
    {
        public ucBookReports()
        {
            InitializeComponent();
            string[] timePeriods = { "Hôm nay", "7 ngày", "1 tháng", "1 năm" };
            cboxDateType.Items.AddRange(timePeriods);
        }

        private void chartBookOpen_Load(object sender, EventArgs e)
        {
            var barSeries = new Guna.Charts.WinForms.GunaBarDataset();
            barSeries.Label = "Số sổ mở";

            // Thêm 3 thanh với giá trị tương ứng
            barSeries.DataPoints.Add("Không kỳ hạn", 10);
            barSeries.DataPoints.Add("Kỳ hạn 3 tháng", 20);
            barSeries.DataPoints.Add("Kỳ hạn 6 tháng", 30);

            // Thêm dataset vào biểu đồ
            chartBookOpen.Datasets.Add(barSeries);
            chartBookOpen.Update();
        }

        private void chartBookClose_Load(object sender, EventArgs e)
        {
            var barSeries = new Guna.Charts.WinForms.GunaBarDataset();
            barSeries.Label = "Số sổ đóng";

            // Thêm 3 thanh với giá trị tương ứng
            barSeries.DataPoints.Add("Không kỳ hạn", 15);
            barSeries.DataPoints.Add("Kỳ hạn 3 tháng", 30);
            barSeries.DataPoints.Add("Kỳ hạn 6 tháng", 6);

            // Thêm dataset vào biểu đồ
            chartBookClose.Datasets.Add(barSeries);
            chartBookClose.Update();
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
            chartDifference.Datasets.Add(differenceSeries);
            chartDifference.Update();
        }
    }
}
