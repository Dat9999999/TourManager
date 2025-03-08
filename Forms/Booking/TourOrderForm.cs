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
            // Load dữ liệu vào DataGridView
            await LoadTourOrdersAsync();
            AddActionButtons();
            SetupDataGridView();
        }

        private async Task LoadTourOrdersAsync()
        {
            var tourOrders = await _tourOrderService.GetAllTourOrdersAsync();
            dataGridViewTourOrders.DataSource = tourOrders;
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
    }
}
