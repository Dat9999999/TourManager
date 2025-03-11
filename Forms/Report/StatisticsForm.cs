using Microsoft.EntityFrameworkCore;
using System.Windows.Forms.DataVisualization.Charting;
using TourManagerment.Data;

namespace TourManagerment.Forms.Report
{
    public partial class StatisticsForm : Form
    {
        protected readonly MTourContext _context;
        public StatisticsForm()
        {
            _context = new MTourContext();
            InitializeComponent();
        }

        private void RenderLineChart1(Dictionary<int, long> data, string title)
        {
            Chart lineChart = new Chart();
            lineChart.Dock = DockStyle.Fill;

            ChartArea chartArea = new ChartArea();

            // Cấu hình trục X từ 1 đến 12
            chartArea.AxisX.Minimum = 1;  // Gốc tọa độ X là 1
            chartArea.AxisX.Maximum = 12; // Max tọa độ X là 12
            chartArea.AxisX.Interval = 1; // Hiển thị từng tháng (1, 2, 3, ..., 12)
            chartArea.AxisX.Title = "Tháng";

            // Cấu hình trục Y
            chartArea.AxisY.Title = "Doanh thu (VNĐ)";
            chartArea.AxisY.LabelStyle.Format = "N0"; // Hiển thị số có dấu phân cách (1,000,000)

            lineChart.ChartAreas.Add(chartArea);

            Series series = new Series();
            series.ChartType = SeriesChartType.Line;
            series.BorderWidth = 3;
            series.Color = Color.Blue;

            // Đảm bảo đủ 12 tháng trên trục X, tháng nào không có thì có giá trị 0
            for (int i = 1; i <= data.Count; i++)
            {
                long revenue = data.ContainsKey(i) ? data[i] : 0;
                series.Points.AddXY(i, revenue);
            }

            lineChart.Series.Add(series);
            lineChart.Titles.Add(new Title(title, Docking.Top, new Font("Arial", 12, FontStyle.Bold), Color.Black));

            pnlLeft.Controls.Clear();
            pnlLeft.Controls.Add(lineChart);
        }

        private void RenderLineChart2(Dictionary<int, long> data, string title)
        {
            Chart lineChart = new Chart();
            lineChart.Dock = DockStyle.Fill;

            ChartArea chartArea = new ChartArea();

            if (data.Any()) // Kiểm tra nếu data không rỗng
            {
                int minX = data.Keys.Min(); // Lấy key nhỏ nhất
                int maxX = data.Keys.Max(); // Lấy key lớn nhất

                chartArea.AxisX.Minimum = minX;
                chartArea.AxisX.Maximum = maxX;
                chartArea.AxisX.Interval = 1; // Đảm bảo hiển thị từng giá trị trên trục X
                chartArea.AxisX.Title = "Thời gian (năm)";

                chartArea.AxisY.Title = "Doanh thu (VNĐ)";
                chartArea.AxisY.LabelStyle.Format = "N0"; // Hiển thị số có dấu phân cách
            }

            lineChart.ChartAreas.Add(chartArea);

            Series series = new Series();
            series.ChartType = SeriesChartType.Line;
            series.BorderWidth = 3;
            series.Color = Color.Blue;

            foreach (var item in data)
            {
                series.Points.AddXY(item.Key, item.Value);
            }

            lineChart.Series.Add(series);
            lineChart.Titles.Add(new Title(title, Docking.Top, new Font("Arial", 12, FontStyle.Bold), Color.Black));

            pnlLeft.Controls.Clear();
            pnlLeft.Controls.Add(lineChart);
        }


        public async Task<Dictionary<string, int>> GetTourCountByTypeAsync(DateTime startDate, DateTime endDate)
        {
            using (var context = new MTourContext())
            {
                return await context.Tours
                    .Where(t => t.StartDate >= startDate && t.StartDate <= endDate)
                    .GroupBy(t => t.Type)
                    .Select(g => new { Type = g.Key, Count = g.Count() })
                    .ToDictionaryAsync(x => x.Type, x => x.Count);
            }
        }




        private async Task RenderPieChart(DateTime startDate, DateTime endDate)
        {

            // Tạo biểu đồ
            Chart pieChart = new Chart();
            pieChart.Dock = DockStyle.Fill;
            ChartArea pieChartArea = new ChartArea("PieChartArea");
            pieChart.ChartAreas.Add(pieChartArea);

            // Tạo series cho biểu đồ tròn
            Series pieSeries = new Series("Loại tour");
            pieSeries.ChartType = SeriesChartType.Pie;


            Dictionary<string, int> tourData = await GetTourCountByTypeAsync(startDate, endDate);


            // Tính tổng số lượng
            double total = tourData.Values.Sum();
            if (total == 0) return;

            // Thêm dữ liệu vào biểu đồ
            foreach (var tour in tourData)
            {
                DataPoint point = new DataPoint();
                point.SetValueXY(tour.Key, tour.Value);
                point.Label = "#PERCENT{P0} (#VALY)"; // Hiển thị phần trăm và số lượng
                point.LegendText = tour.Key; // Hiển thị đúng tên tour trong Legend
                pieSeries.Points.Add(point);
            }


            // Thêm series vào biểu đồ
            pieChart.Series.Add(pieSeries);

            // Thêm chú thích (Legend)
            Legend legend = new Legend();
            legend.Name = "Legend1";
            legend.Docking = Docking.Bottom;
            legend.Alignment = StringAlignment.Center;
            pieChart.Legends.Add(legend);

            pnlRight.Controls.Clear();

            // Thêm biểu đồ vào form
            pnlRight.Controls.Add(pieChart);



        }

        public async Task<Dictionary<int, long>> GetRevenueByMonthAsync(int year)
        {
            int currentYear = DateTime.Now.Year;
            int currentMonth = (year == currentYear) ? DateTime.Now.Month : 12; // Nếu là năm hiện tại, lấy đến tháng hiện tại; nếu là năm quá khứ, lấy đủ 12 tháng.

            DateTime startDate = new DateTime(year, 1, 1);
            DateTime endDate = new DateTime(year, currentMonth, DateTime.DaysInMonth(year, currentMonth));

            using (var context = new MTourContext()) // Tạo mới DbContext
            {
                var revenueData = await context.Invoices
                    .Where(i => i.createdAt.Year == year) // Chỉ lọc theo năm
                    .GroupBy(i => i.createdAt.Month) // Nhóm theo tháng
                    .Select(g => new
                    {
                        Month = g.Key,
                        Revenue = g.Sum(i => i.amount)
                    })
                    .ToDictionaryAsync(x => x.Month, x => x.Revenue);

                // Đảm bảo đủ 12 tháng hoặc đến tháng hiện tại nếu là năm hiện tại
                var completeData = Enumerable.Range(1, currentMonth)
                    .ToDictionary(m => m, m => revenueData.ContainsKey(m) ? revenueData[m] : 0);

                return completeData;
            }
        }



        public async Task<Dictionary<int, long>> GetRevenueByYearAsync(int startYear, int endYear)
        {
            using (var context = new MTourContext()) // Tạo mới DbContext
            {
                return await context.Invoices
                    .Where(i => i.createdAt.Year >= startYear && i.createdAt.Year <= endYear)
                    .GroupBy(i => i.createdAt.Year)
                    .Select(g => new { Year = g.Key, Revenue = g.Sum(i => i.amount) })
                    .ToDictionaryAsync(x => x.Year, x => x.Revenue);
            }
        }





        private async void btnLoadChart_Click(object sender, EventArgs e)
        {
            await RenderPieChart(dtpStartDate.Value, dtpEndDate.Value);
        }

        private async void StatisticsForm_Load(object sender, EventArgs e)
        {
            await RenderPieChart(dtpStartDate.Value, dtpEndDate.Value);


            CboReportType.Items.AddRange(new string[] { "Thống kê theo tháng", "Thống kê theo năm" });
            CboReportType.SelectedIndex = 0;
            CboReportType.SelectedIndexChanged += CboReportType_SelectedIndexChanged;





            // Thay đổi format dựa theo loại báo cáo
            if (CboReportType.SelectedIndex == 0) // Thống kê theo tháng
            {
                dtpStart.CustomFormat = "yyyy"; // Chỉ hiển thị năm
                dtpEnd.Visible = false;
                dtpStart.ShowUpDown = true; // Hiển thị dạng cuộn
                dtpEnd.ShowUpDown = true;
            }
            else // Thống kê theo năm
            {
                dtpStart.CustomFormat = "yyyy"; // Chỉ hiển thị năm
                dtpEnd.CustomFormat = "yyyy";
                dtpStart.ShowUpDown = true;
                dtpEnd.ShowUpDown = true;
            }

            // Button để hiển thị biểu đồ


            //BtnGenerateReport_Click(null, null);

            BtnGenerateReport_Click(null, null);
            dtpEndDate.Value = DateTime.Now;
            dtpStartDate.Value = DateTime.Now.AddYears(-1);
            RenderPieChart(dtpStartDate.Value, dtpEndDate.Value);

        }

        private void CboReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CboReportType.SelectedIndex == 0) // Thống kê theo tháng
            {
                dtpStart.CustomFormat = "yyyy"; // Chỉ hiển thị năm
                dtpEnd.Visible = false;
                //dtpStart.ShowUpDown = true; // Hiển thị dạng cuộn
                //dtpEnd.ShowUpDown = true;
            }
            else // Thống kê theo năm
            {
                dtpStart.CustomFormat = "yyyy"; // Chỉ hiển thị năm
                dtpEnd.CustomFormat = "yyyy";
                dtpEnd.Visible = true;
                //dtpStart.ShowUpDown = true;
                //dtpEnd.ShowUpDown = true;
            }
        }


        // Xử lý khi bấm nút "Hiển thị báo cáo"
        private async void BtnGenerateReport_Click(object sender, EventArgs e)
        {

            if (CboReportType.SelectedIndex == 0) // Thống kê theo tháng
            {
                int startYear = dtpStart.Value.Year;
                int startMonth = dtpStart.Value.Month;

                int endYear = dtpEnd.Value.Year;
                int endMonth = dtpEnd.Value.Month;

                var revenueData = await GetRevenueByMonthAsync(startYear);
                RenderLineChart1(revenueData, "Doanh thu theo tháng");
            }
            else // Thống kê theo năm
            {
                int startYear = dtpStart.Value.Year;
                int endYear = dtpEnd.Value.Year;

                var revenueData = await GetRevenueByYearAsync(startYear, endYear);
                RenderLineChart2(revenueData, "Doanh thu theo năm");
            }
        }



    }
}