using OfficeOpenXml;
using TourManagerment.Models;
using TourManagerment.Services;

namespace TourManagerment.Forms.CustomerManagement
{
    public partial class CustomerForm : Form
    {
        private readonly CustomerService _customerService;

        public CustomerForm()
        {
            InitializeComponent();
            _customerService = new CustomerService(); // Khởi tạo trực tiếp
        }

        private async void CustomerForm_Load(object sender, EventArgs e)
        {
            // Load dữ liệu vào DataGridView
            await LoadCustomersAsync();
            AddActionButtons();
            SetupDataGridView();
        }

        private async Task LoadCustomersAsync()
        {
            var customers = await _customerService.GetAllCustomersAsync();
            dataGridViewCustomers.DataSource = customers;
        }

        private void AddActionButtons()
        {
            // Xóa cột cũ nếu đã tồn tại
            if (dataGridViewCustomers.Columns["View"] != null)
                dataGridViewCustomers.Columns.Remove("View");
            if (dataGridViewCustomers.Columns["Edit"] != null)
                dataGridViewCustomers.Columns.Remove("Edit");
            if (dataGridViewCustomers.Columns["Delete"] != null)
                dataGridViewCustomers.Columns.Remove("Delete");

            // Cột "Xem"
            DataGridViewButtonColumn btnView = new DataGridViewButtonColumn()
            {
                Name = "View",
                HeaderText = "Xem",
                Text = "👁",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells // Khít nội dung
            };

            // Cột "Sửa"
            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn()
            {
                Name = "Edit",
                HeaderText = "Sửa",
                Text = "✏",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells // Khít nội dung
            };

            // Cột "Xóa"
            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn()
            {
                Name = "Delete",
                HeaderText = "Xóa",
                Text = "🗑",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells // Khít nội dung
            };

            // Thêm các cột vào DataGridView
            dataGridViewCustomers.Columns.AddRange(new DataGridViewColumn[] { btnView, btnEdit, btnDelete });

            // Căn giữa nội dung trong cột
            foreach (DataGridViewColumn col in dataGridViewCustomers.Columns)
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // Xử lý sự kiện click
            dataGridViewCustomers.CellClick += DataGridViewCustomers_CellClick;
        }
        private void SetupDataGridView()
        {
            dataGridViewCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Cột tự động giãn
            dataGridViewCustomers.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Hàng tự động giãn
            dataGridViewCustomers.ScrollBars = ScrollBars.Both; // Thanh cuộn khi cần
            dataGridViewCustomers.AllowUserToAddRows = false; // Ẩn dòng trống cuối

            // Căn giữa header
            dataGridViewCustomers.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            if (dataGridViewCustomers.Columns["Id"] != null)
                dataGridViewCustomers.Columns["Id"].HeaderText = "ID";
            if (dataGridViewCustomers.Columns["Name"] != null)
                dataGridViewCustomers.Columns["Name"].HeaderText = "Tên";
            if (dataGridViewCustomers.Columns["Phone"] != null)
                dataGridViewCustomers.Columns["Phone"].HeaderText = "Số điện thoại";
            if (dataGridViewCustomers.Columns["Address"] != null)
                dataGridViewCustomers.Columns["Address"].HeaderText = "Địa chỉ";

            // Ẩn cột TourOrder nếu tồn tại
            if (dataGridViewCustomers.Columns["TourOrders"] != null)
            {
                dataGridViewCustomers.Columns["TourOrders"].Visible = false;
            }

            // Căn trái nội dung của từng cột (trừ cột chứa nút)
            foreach (DataGridViewColumn col in dataGridViewCustomers.Columns)
            {
                if (col is DataGridViewButtonColumn)
                {
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Căn giữa nút
                }
                else
                {
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft; // Căn trái nội dung
                }
            }
        }

        private async void DataGridViewCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int customerId = (int)dataGridViewCustomers.Rows[e.RowIndex].Cells["Id"].Value;

                if (dataGridViewCustomers.Columns[e.ColumnIndex].Name == "View")
                {
                    ViewCustomer f = new ViewCustomer(customerId);
                    f.ShowDialog();
                    await LoadCustomersAsync();

                }
                else if (dataGridViewCustomers.Columns[e.ColumnIndex].Name == "Edit")
                {
                    UpdateCustomerForm f = new(customerId);
                    f.ShowDialog();
                    await LoadCustomersAsync();
                }
                else if (dataGridViewCustomers.Columns[e.ColumnIndex].Name == "Delete")
                {
                    var confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo);
                    if (confirm == DialogResult.Yes)
                    {
                        await _customerService.DeleteCustomerAsync(customerId);
                        await LoadCustomersAsync();
                    }
                }
            }
        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            CreateCustomerForm f = new CreateCustomerForm();
            f.ShowDialog();
            await LoadCustomersAsync();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            var customers = await _customerService.SearchCustomersAsync(keyword);
            dataGridViewCustomers.DataSource = customers;
        }


        private void BtnExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "Lưu danh sách khách hàng";
                saveFileDialog.FileName = "Customers_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ExportToExcel(saveFileDialog.FileName);
                        MessageBox.Show("Xuất file Excel thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xuất file Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        //ExcelPackage.License.SetNonCommercialPersonal("My Name");

        private void ExportToExcel(string filePath)
        {
            ExcelPackage.License.SetNonCommercialPersonal("My Name");
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Customers");
                var customers = dataGridViewCustomers.DataSource as List<Customer>; // Cast to List<Customer>

                if (customers == null)
                {
                    MessageBox.Show("Không có dữ liệu để xuất.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Thêm tiêu đề cột
                int colIndex = 1;
                foreach (DataGridViewColumn col in dataGridViewCustomers.Columns)
                {
                    if (!(col is DataGridViewButtonColumn) && col.Visible) // Bỏ qua cột nút và cột ẩn
                    {
                        worksheet.Cells[1, colIndex].Value = col.HeaderText;
                        worksheet.Cells[1, colIndex].Style.Font.Bold = true;
                        colIndex++;
                    }
                }

                // Thêm dữ liệu từ List<Customer>
                for (int row = 0; row < customers.Count; row++)
                {
                    colIndex = 1;
                    var customer = customers[row];
                    foreach (DataGridViewColumn col in dataGridViewCustomers.Columns)
                    {
                        if (!(col is DataGridViewButtonColumn) && col.Visible) // Bỏ qua cột nút và cột ẩn
                        {
                            // Lấy giá trị dựa trên tên cột
                            switch (col.Name)
                            {
                                case "Id":
                                    worksheet.Cells[row + 2, colIndex].Value = customer.Id;
                                    break;
                                case "Name":
                                    worksheet.Cells[row + 2, colIndex].Value = customer.Name;
                                    break;
                                case "Phone":
                                    worksheet.Cells[row + 2, colIndex].Value = customer.Phone;
                                    break;
                                case "Address":
                                    worksheet.Cells[row + 2, colIndex].Value = customer.Address;
                                    break;
                            }
                            colIndex++;
                        }
                    }
                }

                // Tự động điều chỉnh kích thước cột
                worksheet.Cells.AutoFitColumns();

                // Lưu file
                File.WriteAllBytes(filePath, package.GetAsByteArray());
            }
        }
    }
}
