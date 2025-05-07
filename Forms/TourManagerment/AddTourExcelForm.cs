using OfficeOpenXml;
using TourManagerment.Models;
using TourManagerment.Services;

namespace TourManagerment.Forms.TourManagerment
{
    public partial class AddTourExcelForm : Form
    {
        private readonly TourService _tourService;
        private List<Tour> _toursFromExcel;

        public AddTourExcelForm()
        {
            InitializeComponent();
            _tourService = new TourService();
            _toursFromExcel = new List<Tour>();

        }


        private void BtnSelectFile_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files|*.xlsx;*.xls";
                openFileDialog.Title = "Chọn file Excel chứa danh sách tour";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _toursFromExcel.Clear();
                        ReadExcelFile(openFileDialog.FileName);
                        DisplayToursInGrid();
                        // Enable nút Thêm nếu có dữ liệu hợp lệ
                        var btnAdd = this.Controls.Find("btnAdd", true).FirstOrDefault() as Button;
                        if (btnAdd != null)
                            btnAdd.Enabled = _toursFromExcel.Any();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi đọc file Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ReadExcelFile(string filePath)
        {
            ExcelPackage.License.SetNonCommercialPersonal("My Name");
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[0]; // Lấy worksheet đầu tiên
                int rowCount = worksheet.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++) // Bắt đầu từ hàng 2 (bỏ header)
                {
                    try
                    {
                        // Đọc dữ liệu từ Excel
                        var name = worksheet.Cells[row, 1].Value?.ToString();
                        var durationStr = worksheet.Cells[row, 2].Value?.ToString();
                        var startDateStr = worksheet.Cells[row, 3].Value?.ToString();
                        var type = worksheet.Cells[row, 4].Value?.ToString();
                        var costStr = worksheet.Cells[row, 5].Value?.ToString();
                        var transportationMethod = worksheet.Cells[row, 6].Value?.ToString();

                        // Kiểm tra dữ liệu rỗng hoặc không hợp lệ
                        if (string.IsNullOrEmpty(name) ||
                            string.IsNullOrEmpty(type) ||
                            string.IsNullOrEmpty(transportationMethod) ||
                            string.IsNullOrEmpty(durationStr) ||
                            string.IsNullOrEmpty(startDateStr) ||
                            string.IsNullOrEmpty(costStr))
                        {
                            continue; // Bỏ qua dòng không hợp lệ
                        }

                        // Chuyển đổi dữ liệu
                        int duration = Convert.ToInt32(durationStr);
                        int cost = Convert.ToInt32(costStr); // Sử dụng int như AddTourForm
                        DateTime startDate = DateTime.ParseExact(startDateStr, "dd/MM/yyyy", null);

                        // Kiểm tra dữ liệu tương tự AddTourForm
                        if (cost <= 0 || duration <= 0)
                        {
                            continue; // Bỏ qua dòng không hợp lệ
                        }

                        // Tính EndDate
                        DateTime endDate = startDate.AddDays(duration);

                        // Tạo đối tượng Tour
                        var tour = new Tour
                        {
                            Name = name,
                            Duration = duration,
                            StartDate = startDate,
                            EndDate = endDate,
                            Type = type,
                            Cost = cost,
                            TransportationMethod = transportationMethod
                        };

                        _toursFromExcel.Add(tour);
                    }
                    catch
                    {
                        // Bỏ qua dòng dữ liệu lỗi
                        continue;
                    }
                }
            }
        }

        private void DisplayToursInGrid()
        {
            var dataGridView = this.Controls.Find("dgvTours", true).FirstOrDefault() as DataGridView;
            if (dataGridView != null)
            {
                dataGridView.DataSource = null;
                dataGridView.DataSource = _toursFromExcel;
                // Tùy chỉnh hiển thị cột
                dataGridView.Columns["Name"].HeaderText = "Tên Tour";
                dataGridView.Columns["Duration"].HeaderText = "Thời Gian (ngày)";
                dataGridView.Columns["StartDate"].HeaderText = "Ngày Bắt Đầu";
                dataGridView.Columns["EndDate"].HeaderText = "Ngày Kết Thúc";
                dataGridView.Columns["Type"].HeaderText = "Loại Tour";
                dataGridView.Columns["Cost"].HeaderText = "Chi Phí (VND)";
                dataGridView.Columns["TransportationMethod"].HeaderText = "Phương Tiện";
                // Ẩn các cột không cần thiết nếu có
                if (dataGridView.Columns.Contains("Id"))
                    dataGridView.Columns["Id"].Visible = false;
                if (dataGridView.Columns.Contains("Pics"))
                    dataGridView.Columns["Pics"].Visible = false;
                if (dataGridView.Columns.Contains("TourGuideId"))
                    dataGridView.Columns["TourGuideId"].Visible = false;
                if (dataGridView.Columns.Contains("TourGuide"))
                    dataGridView.Columns["TourGuide"].Visible = false;
                if (dataGridView.Columns.Contains("TourOrders"))
                    dataGridView.Columns["TourOrders"].Visible = false;
            }
        }

        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int successCount = 0;
                foreach (var tour in _toursFromExcel)
                {
                    try
                    {
                        await _tourService.CreateTourAsync(tour);
                        successCount++;
                    }
                    catch
                    {
                        // Bỏ qua tour bị lỗi, tiếp tục với tour tiếp theo
                        continue;
                    }
                }

                MessageBox.Show($"Thêm {successCount} tour thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Xóa dữ liệu hiển thị sau khi thêm thành công
                _toursFromExcel.Clear();
                DisplayToursInGrid();
                var btnAdd = this.Controls.Find("btnAdd", true).FirstOrDefault() as Button;
                if (btnAdd != null)
                    btnAdd.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Thêm tour thất bại: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}