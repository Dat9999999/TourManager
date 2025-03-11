using TourManagerment.DTO;
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
            // Thêm các giá trị vào cboTourStatus
            cboTourStatus.Items.Add("Tất cả");
            cboTourStatus.Items.Add("Chưa diễn ra");
            cboTourStatus.Items.Add("Đang diễn ra");
            cboTourStatus.Items.Add("Đã diễn ra");

            // Thêm các giá trị vào cboInvoiceInfo
            cboInvoiceInfo.Items.Add("Tất cả");
            cboInvoiceInfo.Items.Add("Chưa thanh toán");
            cboInvoiceInfo.Items.Add("Đã thanh toán");

            // Chọn mặc định (nếu cần)
            cboTourStatus.SelectedIndex = 0; // Ví dụ, mặc định là "Chưa bắt đầu"
            cboInvoiceInfo.SelectedIndex = 0; // Ví dụ, mặc định là "Chưa thanh toán"

            cboTourStatus.SelectedIndexChanged += cboTourStatus_SelectedIndexChanged;
            cboInvoiceInfo.SelectedIndexChanged += cboInvoiceInfo_SelectedIndexChanged;

            await LoadSchedulesAsync();
            AddActionButtons();
            SetupDataGridView();
        }


        void LoadDataGridView(List<ScheduleDTO> schedules)
        {
            // Lấy giá trị được chọn từ ComboBox
            string selectedTourStatus = cboTourStatus.SelectedItem?.ToString();
            string selectedInvoiceInfo = cboInvoiceInfo.SelectedItem?.ToString();

            // Lọc theo TourStatus
            if (!string.IsNullOrEmpty(selectedTourStatus) && selectedTourStatus.Equals("Chưa diễn ra"))
            {
                schedules = schedules.Where(s => s.TourStatus == selectedTourStatus).ToList();
            }
            else if (!string.IsNullOrEmpty(selectedTourStatus) && selectedTourStatus.Equals("Đang diễn ra"))
            {
                schedules = schedules.Where(s => s.TourStatus == selectedTourStatus).ToList();

            }
            else if (!string.IsNullOrEmpty(selectedTourStatus) && selectedTourStatus.Equals("Đã diễn ra"))
            {
                schedules = schedules.Where(s => s.TourStatus == selectedTourStatus).ToList();
            }

            // Lọc theo InvoiceInfo
            if (!string.IsNullOrEmpty(selectedInvoiceInfo) && selectedInvoiceInfo.Equals("Chưa thanh toán"))
            {
                schedules = schedules.Where(s => s.InvoiceInfo == selectedInvoiceInfo).ToList();
            }
            else if (!string.IsNullOrEmpty(selectedInvoiceInfo) && selectedInvoiceInfo.Equals("Đã thanh toán"))
            {
                string str = "Chưa thanh toán";
                schedules = schedules.Where(s => s.InvoiceInfo != str).ToList();
            }

            // Cập nhật lại DataGridView
            dataGridViewSchedules.DataSource = schedules;
        }



        private async Task LoadSchedulesAsync()
        {
            try
            {
                var schedules = await _scheduleService.GetAllSchedulesAsync();
                LoadDataGridView(schedules);
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

            // Đổi tên các cột trong DataGridView
            if (dataGridViewSchedules.Columns["CustomerInfo"] != null)
                dataGridViewSchedules.Columns["CustomerInfo"].HeaderText = "Khách hàng";
            if (dataGridViewSchedules.Columns["TourInfo"] != null)
                dataGridViewSchedules.Columns["TourInfo"].HeaderText = "Tour";
            if (dataGridViewSchedules.Columns["TourStatus"] != null)
                dataGridViewSchedules.Columns["TourStatus"].HeaderText = "Trạng thái tour";
            if (dataGridViewSchedules.Columns["TimeStatus"] != null)
                dataGridViewSchedules.Columns["TimeStatus"].HeaderText = "Thời gian";
            if (dataGridViewSchedules.Columns["TourOrderInfo"] != null)
                dataGridViewSchedules.Columns["TourOrderInfo"].HeaderText = "Thông tin đơn đặt";
            if (dataGridViewSchedules.Columns["InvoiceInfo"] != null)
                dataGridViewSchedules.Columns["InvoiceInfo"].HeaderText = "Hóa đơn";


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

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();  // Lấy nội dung ô tìm kiếm

            if (string.IsNullOrEmpty(keyword))
            {
                // Nếu không có từ khóa tìm kiếm, tải tất cả lịch trình
                await LoadSchedulesAsync();
            }
            else
            {
                // Tìm kiếm theo từ khóa
                try
                {
                    var schedules = await _scheduleService.SearchSchedulesAsync(keyword);
                    LoadDataGridView(schedules);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tìm kiếm lịch trình: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void cboTourStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var schedules = await _scheduleService.GetAllSchedulesAsync();
                LoadDataGridView(schedules);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void cboInvoiceInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var schedules = await _scheduleService.GetAllSchedulesAsync();
                LoadDataGridView(schedules);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}