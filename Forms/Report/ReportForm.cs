using System.Data;
using TourManagerment.Services;

namespace TourManagerment.Forms.Report
{
    public partial class ReportForm : Form
    {
        private readonly TourOrderService _tourOrderService;
        private readonly TourService _tourService;
        private readonly InvoiceService _invoiceService;

        public ReportForm()
        {
            InitializeComponent();
            _tourOrderService = new TourOrderService();
            _tourService = new TourService();
            _invoiceService = new InvoiceService();

            // Thiết lập giá trị mặc định cho DateTimePicker
            DateTime now = DateTime.Today;
            startDatePicker.Value = new DateTime(now.Year, now.Month, 1); // Đầu tháng hiện tại
            endDatePicker.Value = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month)); // Cuối tháng hiện tại

            // Gắn sự kiện
            reportTypeComboBox.SelectedIndexChanged += ReportTypeComboBox_SelectedIndexChanged;
            generateButton.Click += GenerateButton_Click;

            // Thiết lập reportTypeComboBox
            reportTypeComboBox.Items.AddRange(new[] { "Theo loại tour", "Theo thời gian đặt" });
            reportTypeComboBox.SelectedIndex = 0;

            // Thiết lập tourTypeComboBox
            tourTypeComboBox.Items.Add("Tất cả");
            LoadTourTypes();
            tourTypeComboBox.SelectedIndex = 0;

            SetupDataGridView();

            // Thiết lập mặc định cho Label
            totalOrdersLabel.Text = "Tổng số lượng đặt: 0";
            totalRevenueLabel.Text = "Tổng doanh thu: 0 VNĐ";
        }

        private void SetupDataGridView()
        {
            reportGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            reportGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            reportGrid.ScrollBars = ScrollBars.Both;
            reportGrid.AllowUserToAddRows = false;

            reportGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewColumn col in reportGrid.Columns)
            {
                if (col is DataGridViewButtonColumn)
                {
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else
                {
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
            }
        }

        private async void LoadTourTypes()
        {
            var tours = await _tourService.GetAllToursAsync();
            var tourTypes = tours.Select(t => t.Type).Distinct().ToList();
            tourTypeComboBox.Items.AddRange(tourTypes.ToArray());
        }

        private void ReportTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            startDatePicker.Visible = true;
            endDatePicker.Visible = true;
            tourTypeComboBox.Visible = reportTypeComboBox.SelectedIndex == 1;
        }

        private async void GenerateButton_Click(object sender, EventArgs e)
        {
            if (!IsDateRangeValid())
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            GenerateReport(reportTypeComboBox.SelectedIndex, startDatePicker.Value, endDatePicker.Value);
        }

        private bool IsDateRangeValid()
        {
            return startDatePicker.Value <= endDatePicker.Value;
        }

        private async void GenerateReport(int reportType, DateTime startDate, DateTime endDate)
        {
            try
            {
                if (reportType == 0) // Theo loại tour
                {
                    await GenerateReportByTourType(reportGrid, startDate, endDate);
                }
                else // Theo thời gian đặt
                {
                    await GenerateReportByTime(reportGrid, startDate, endDate);
                }
            }
            catch (Exception ex)
            {
                totalOrdersLabel.Visible = false;
                totalRevenueLabel.Visible = false;
                MessageBox.Show($"Lỗi khi tạo báo cáo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            totalOrdersLabel.Visible = true;
            totalRevenueLabel.Visible = true;
        }

        private async Task GenerateReportByTourType(DataGridView reportGrid, DateTime startDate, DateTime endDate)
        {
            var tours = await _tourService.GetAllToursAsync();
            var tourOrders = await _tourOrderService.GetAllTourOrdersAsync();
            var invoices = await _invoiceService.GetAllInvoicesAsync();

            var filteredOrders = tourOrders
                .Where(o => o.CreationTime >= startDate && o.CreationTime <= endDate)
                .ToList();

            var reportData = tours
                .GroupJoin(filteredOrders,
                    tour => tour.Id,
                    order => order.TourID,
                    (tour, orders) => new { tour, orders })
                .SelectMany(x => x.orders.DefaultIfEmpty(), (tour, order) => new { tour.tour, order })
                .Join(invoices,
                    t => t.order?.Id,
                    invoice => invoice.TourOrderID,
                    (t, invoice) => new
                    {
                        TourType = t.tour.Type,
                        Order = t.order,
                        InvoiceAmount = invoice?.amount ?? 0
                    })
                .GroupBy(x => x.TourType)
                .Select(g => new
                {
                    TourType = g.Key,
                    TotalOrders = g.Count(x => x.Order != null),
                    TotalRevenue = g.Sum(x => x.InvoiceAmount)
                })
                .ToList();

            reportGrid.Columns.Clear();
            reportGrid.Columns.Add("TourType", "Loại Tour");
            reportGrid.Columns.Add("TotalOrders", "Số lượng đơn");
            reportGrid.Columns.Add("TotalRevenue", "Doanh thu (VNĐ)");

            foreach (var item in reportData)
            {
                reportGrid.Rows.Add(item.TourType, item.TotalOrders, item.TotalRevenue.ToString("N0"));
            }

            // Tính tổng và hiển thị vào Label
            int totalOrders = reportData.Sum(x => x.TotalOrders);
            decimal totalRevenue = reportData.Sum(x => x.TotalRevenue);
            totalOrdersLabel.Text = $"Tổng số lượng đặt: {totalOrders}";
            totalRevenueLabel.Text = $"Tổng doanh thu: {totalRevenue:N0} VNĐ";
        }

        private async Task GenerateReportByTime(DataGridView reportGrid, DateTime startDate, DateTime endDate)
        {
            var tours = await _tourService.GetAllToursAsync();
            var tourOrders = await _tourOrderService.GetAllTourOrdersAsync();
            var invoices = await _invoiceService.GetAllInvoicesAsync();

            string selectedTourType = tourTypeComboBox.SelectedItem?.ToString();
            if (selectedTourType != "Tất cả")
            {
                tours = tours.Where(t => t.Type == selectedTourType).ToList();
            }

            var reportData = tours
                .GroupJoin(tourOrders.Where(o => o.CreationTime >= startDate && o.CreationTime <= endDate),
                    tour => tour.Id,
                    order => order.TourID,
                    (tour, orders) => new { tour, orders })
                .SelectMany(x => x.orders.DefaultIfEmpty(), (t, order) => new { t.tour, order })
                .Join(invoices,
                    t => t.order?.Id,
                    invoice => invoice.TourOrderID,
                    (t, invoice) => new
                    {
                        TourId = t.tour.Id,
                        TourName = t.tour.Name,
                        TourType = t.tour.Type, // Thêm TourType
                        Order = t.order,
                        InvoiceAmount = invoice?.amount ?? 0
                    })
                .GroupBy(x => new { x.TourId, x.TourName, x.TourType }) // Nhóm thêm TourType
                .Select(g => new
                {
                    TourId = g.Key.TourId,
                    TourName = g.Key.TourName,
                    TourType = g.Key.TourType, // Thêm vào reportData
                    TotalOrders = g.Count(x => x.Order != null),
                    TotalRevenue = g.Sum(x => x.InvoiceAmount)
                })
                .OrderBy(x => x.TourId)
                .ToList();

            reportGrid.Columns.Clear();
            reportGrid.Columns.Add("TourId", "ID Tour");
            reportGrid.Columns.Add("TourName", "Tên Tour");
            reportGrid.Columns.Add("TourType", "Loại Tour"); // Thêm cột TourType
            reportGrid.Columns.Add("TotalOrders", "Số lượng đặt");
            reportGrid.Columns.Add("TotalRevenue", "Doanh thu (VNĐ)");

            foreach (var item in reportData)
            {
                reportGrid.Rows.Add(item.TourId, item.TourName, item.TourType, item.TotalOrders, item.TotalRevenue.ToString("N0"));
            }

            // Tính tổng và hiển thị vào Label
            int totalOrders = reportData.Sum(x => x.TotalOrders);
            decimal totalRevenue = reportData.Sum(x => x.TotalRevenue);
            totalOrdersLabel.Text = $"Tổng số lượng đặt: {totalOrders}";
            totalRevenueLabel.Text = $"Tổng doanh thu: {totalRevenue:N0} VNĐ";
        }
    }
}