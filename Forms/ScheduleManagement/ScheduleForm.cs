using TourManagerment.Services;

namespace TourManagerment.Forms.ScheduleManagement
{
    public partial class ScheduleForm : Form
    {
        private readonly ScheduleService _scheduleService;

        public ScheduleForm()
        {
            InitializeComponent();
            _scheduleService = new ScheduleService();
        }

        private async void ScheduleForm_Load(object sender, EventArgs e)
        {
            await LoadSchedulesAsync();
            AddActionButtons();
            SetupDataGridView();
        }

        private async Task LoadSchedulesAsync()
        {
            try
            {
                var schedules = await _scheduleService.GetAllSchedulesAsync();
                dataGridViewSchedules.DataSource = schedules;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddActionButtons()
        {
            // Xóa cột cũ nếu đã tồn tại
            if (dataGridViewSchedules.Columns["View"] != null)
                dataGridViewSchedules.Columns.Remove("View");
            if (dataGridViewSchedules.Columns["Pay"] != null)
                dataGridViewSchedules.Columns.Remove("Pay");

            // Cột "Xem"
            DataGridViewButtonColumn btnView = new DataGridViewButtonColumn()
            {
                Name = "View",
                HeaderText = "Xem",
                Text = "👁",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            // Cột "Thanh toán"
            DataGridViewButtonColumn btnPay = new DataGridViewButtonColumn()
            {
                Name = "Pay",
                HeaderText = "Thanh toán",
                Text = "💳",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            // Thêm các cột vào DataGridView
            dataGridViewSchedules.Columns.AddRange(new DataGridViewColumn[] { btnView, btnPay });

            // Căn giữa nội dung trong cột nút
            foreach (DataGridViewColumn col in dataGridViewSchedules.Columns)
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // Xử lý sự kiện click
            dataGridViewSchedules.CellClick += DataGridViewSchedules_CellClick;
        }

        private void SetupDataGridView()
        {
            dataGridViewSchedules.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewSchedules.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewSchedules.ScrollBars = ScrollBars.Both;
            dataGridViewSchedules.AllowUserToAddRows = false;

            // Căn giữa header
            dataGridViewSchedules.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Căn trái nội dung (trừ cột nút)
            foreach (DataGridViewColumn col in dataGridViewSchedules.Columns)
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

        private async void DataGridViewSchedules_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var tourOrderInfo = dataGridViewSchedules.Rows[e.RowIndex].Cells["TourOrderInfo"].Value?.ToString();
                if (string.IsNullOrEmpty(tourOrderInfo)) return;

                // Lấy TourOrderId từ chuỗi TourOrderInfo (format: "ID({id}) - ...")
                int tourOrderId = int.Parse(tourOrderInfo.Split('-')[0].Replace("ID(", "").Replace(")", "").Trim());

                if (dataGridViewSchedules.Columns[e.ColumnIndex].Name == "View")
                {
                    ViewTourScheduleForm f = new ViewTourScheduleForm(tourOrderId);
                    f.ShowDialog();
                    await LoadSchedulesAsync();
                }
                else if (dataGridViewSchedules.Columns[e.ColumnIndex].Name == "Pay")
                {
                    var invoiceInfo = dataGridViewSchedules.Rows[e.RowIndex].Cells["InvoiceInfo"].Value?.ToString();
                    if (invoiceInfo != "Chưa thanh toán")
                    {
                        MessageBox.Show("Lịch trình này đã được thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        PayForm f = new PayForm(tourOrderId);
                        f.ShowDialog();
                        await LoadSchedulesAsync();
                    }
                }
            }
        }

    }
}