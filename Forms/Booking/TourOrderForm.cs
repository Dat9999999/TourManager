using TourManagerment.DTO;
using TourManagerment.Services;

namespace TourManagerment.Forms.Booking
{
    public partial class TourOrderForm : Form
    {
        private readonly TourOrderService _tourOrderService;

        public TourOrderForm()
        {
            InitializeComponent();
            _tourOrderService = new TourOrderService(); // Khởi tạo dịch vụ TourOrder
        }

        private async void TourOrderForm_Load(object sender, EventArgs e)
        {
            // Khởi tạo ComboBox trạng thái

            cbStatusFilter.Items.Add("Tất cả");
            cbStatusFilter.Items.Add("Complete");
            cbStatusFilter.Items.Add("Pending");
            cbStatusFilter.SelectedItem = "Tất cả"; // Mặc định chọn tất cả
            cbStatusFilter.SelectedIndexChanged += cbStatusFilter_SelectedIndexChanged;

            // Thêm ComboBox vào form
            this.Controls.Add(cbStatusFilter);

            // Load dữ liệu vào DataGridView
            await LoadTourOrdersAsync();
            AddActionButtons();
            SetupDataGridView();
        }

        private async void cbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedStatus = cbStatusFilter.SelectedItem.ToString();
            dataGridViewTourOrders.DataSource = await FilterTourOrdersByStatusAsync(selectedStatus);
        }

        public async Task<List<TourOrderDTO>> FilterTourOrdersByStatusAsync(string status)
        {
            var tourOrders = await _tourOrderService.GetAllTourOrdersAsync();

            // Lọc theo trạng thái nếu người dùng chọn
            if (status != "Tất cả")
            {
                tourOrders = tourOrders.Where(to => to.Status.Equals(status, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            // Chuyển đổi TourOrder sang TourOrderDTO
            return tourOrders.Select(to => new TourOrderDTO
            {
                Id = to.Id,
                CustomerName = to.Customer != null ? to.Customer.Name : "Không có thông tin khách hàng",
                Phone = to.Customer != null ? to.Customer.Phone : "Không có số điện thoại",
                TourName = to.Tour != null ? to.Tour.Name : "Không có thông tin tour",
                Address = to.Customer != null ? to.Customer?.Address : "Không có thông tin địa chỉ",
                Status = to.Status,
                CreationTime = to.CreationTime.ToString("dd/MM/yyyy HH:mm"),
            }).ToList();



        }



        private async Task LoadTourOrdersAsync()
        {
            string selectedStatus = cbStatusFilter.SelectedItem.ToString();
            dataGridViewTourOrders.DataSource = await FilterTourOrdersByStatusAsync(selectedStatus);
        }


        private void AddActionButtons()
        {
            // Xóa cột cũ nếu đã tồn tại
            if (dataGridViewTourOrders.Columns["View"] != null)
                dataGridViewTourOrders.Columns.Remove("View");
            if (dataGridViewTourOrders.Columns["Edit"] != null)
                dataGridViewTourOrders.Columns.Remove("Edit");
            if (dataGridViewTourOrders.Columns["Delete"] != null)
                dataGridViewTourOrders.Columns.Remove("Delete");

            // Cột "Xem"
            DataGridViewButtonColumn btnView = new DataGridViewButtonColumn()
            {
                Name = "View",
                HeaderText = "Xem",
                Text = "👁",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            // Cột "Sửa"
            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn()
            {
                Name = "Edit",
                HeaderText = "Sửa",
                Text = "✏",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            // Cột "Xóa"
            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn()
            {
                Name = "Delete",
                HeaderText = "Xóa",
                Text = "🗑",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            // Thêm các cột vào DataGridView
            dataGridViewTourOrders.Columns.AddRange(new DataGridViewColumn[] { btnView, btnEdit, btnDelete });

            // Căn giữa nội dung trong cột
            foreach (DataGridViewColumn col in dataGridViewTourOrders.Columns)
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // Xử lý sự kiện click
            dataGridViewTourOrders.CellClick += DataGridViewTourOrders_CellClick;
        }

        private void SetupDataGridView()
        {
            dataGridViewTourOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewTourOrders.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewTourOrders.ScrollBars = ScrollBars.Both;
            dataGridViewTourOrders.AllowUserToAddRows = false;

            // Căn giữa header
            dataGridViewTourOrders.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Thêm tên cột cho DataGridView
            dataGridViewTourOrders.Columns["Id"].HeaderText = "Id";
            dataGridViewTourOrders.Columns["CustomerName"].HeaderText = "Tên";
            dataGridViewTourOrders.Columns["Phone"].HeaderText = "Số Điện Thoại";
            dataGridViewTourOrders.Columns["TourName"].HeaderText = "Tên Tour";
            dataGridViewTourOrders.Columns["Address"].HeaderText = "Địa Chỉ";
            dataGridViewTourOrders.Columns["Status"].HeaderText = "Trạng Thái";
            dataGridViewTourOrders.Columns["CreationTime"].HeaderText = "Ngày Tạo";

            // Căn trái nội dung (trừ cột chứa nút)
            foreach (DataGridViewColumn col in dataGridViewTourOrders.Columns)
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

        private async void DataGridViewTourOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int orderId = (int)dataGridViewTourOrders.Rows[e.RowIndex].Cells["Id"].Value;

                if (dataGridViewTourOrders.Columns[e.ColumnIndex].Name == "View")
                {
                    ViewTourOrder f = new ViewTourOrder(orderId);
                    f.ShowDialog();
                    await LoadTourOrdersAsync();
                }
                else if (dataGridViewTourOrders.Columns[e.ColumnIndex].Name == "Edit")
                {
                    UpdateTourOrder f = new UpdateTourOrder(orderId);
                    f.ShowDialog();
                    await LoadTourOrdersAsync();
                }
                else if (dataGridViewTourOrders.Columns[e.ColumnIndex].Name == "Delete")
                {
                    var confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa đơn đặt tour này?", "Xác nhận", MessageBoxButtons.YesNo);
                    if (confirm == DialogResult.Yes)
                    {
                        await _tourOrderService.DeleteTourOrderAsync(orderId);
                        await LoadTourOrdersAsync();
                    }
                }
            }
        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            CreateOrderForm f = new CreateOrderForm();
            f.ShowDialog();
            await LoadTourOrdersAsync();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            string statusFilter = cbStatusFilter.SelectedItem.ToString();

            // Lọc theo trạng thái trước tiên
            var results = await FilterTourOrdersByStatusAsync(statusFilter);

            // Kiểm tra nếu từ khóa là một số để tìm kiếm theo ID
            if (int.TryParse(keyword, out int orderId))
            {
                // Nếu tìm thấy ID, lọc theo ID
                results = results.Where(r => r.Id == orderId).ToList();
            }
            else if (!string.IsNullOrEmpty(keyword))
            {
                // Nếu không phải là số, tìm kiếm theo tên khách hàng hoặc tên tour
                results = results.Where(r => r.CustomerName.Contains(keyword, StringComparison.OrdinalIgnoreCase)
                                           || r.TourName.Contains(keyword, StringComparison.OrdinalIgnoreCase)
                                           || r.Phone.Contains(keyword, StringComparison.OrdinalIgnoreCase)
                                           || r.Address.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // Cập nhật lại DataGridView với kết quả tìm kiếm
            dataGridViewTourOrders.DataSource = results;
        }


    }
}
