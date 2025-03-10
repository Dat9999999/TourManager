using Microsoft.Data.SqlClient;
using TourManagerment.Data;
using TourManagerment.Forms.TourManagerment;
using TourManagerment.Services;

namespace TourManagerment.Forms
{
    public partial class TourForm : Form
    {
        private TourService _tourService;
        public TourForm()
        {
            InitializeComponent();
            _tourService = new TourService();

        }

        private void TourForm_Load(object sender, EventArgs e)
        {
            using (var context = new MTourContext())
            {
                var tours = context.Tours
                    .Select(t => new
                    {
                        t.Id, // Thêm ID để thao tác
                        t.Name,
                        t.Cost,
                        t.Duration,
                        t.StartDate,
                        t.EndDate,
                        t.Type,
                        t.TransportationMethod
                    })
                    .ToList();

                dgvTourList.DataSource = tours;
            }

            dgvTourList.Columns["Id"].Visible = false; // Ẩn cột ID (chỉ dùng nội bộ)
            dgvTourList.Columns["Name"].HeaderText = "Tên Tour";
            dgvTourList.Columns["Cost"].HeaderText = "Giá";
            dgvTourList.Columns["Duration"].HeaderText = "Thời gian (ngày)";
            dgvTourList.Columns["StartDate"].HeaderText = "Ngày bắt đầu";
            dgvTourList.Columns["EndDate"].HeaderText = "Ngày kết thúc";
            dgvTourList.Columns["Type"].HeaderText = "Loại Tour";
            dgvTourList.Columns["TransportationMethod"].HeaderText = "Phương tiện";

            AddActionButtons();

            // Gán sự kiện click cho DataGridView
            dgvTourList.CellClick += DgvTourList_CellClick;
        }
        private void DgvTourList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string columnName = dgvTourList.Columns[e.ColumnIndex].Name;
                int tourId = Convert.ToInt32(dgvTourList.Rows[e.RowIndex].Cells["Id"].Value);

                if (columnName == "Edit")
                {
                    //EditTour(tourId);
                }
                else if (columnName == "Delete")
                {
                    DeleteTour(tourId);
                }
            }
        }
        private void EditTour(int tourId)
        {
            using (var context = new MTourContext())
            {
                var tour = context.Tours.Find(tourId);
                if (tour != null)
                {
                    //EditTourForm form = new EditTourForm(tour);
                    EditTourForm form = new EditTourForm();

                    form.ShowDialog();

                    // Sau khi sửa, load lại danh sách
                    TourForm_Load(null, null);
                }
            }
        }
        private async void DeleteTour(int tourId)
        {
            var confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa tour này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                
                    var res = await _tourService.DeleteTourAsync(tourId);
                    if (!res)
                    {
                        MessageBox.Show("Không thể xóa vì tour này có trong đơn đặt tour của khách hàng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Reload danh sách
                    TourForm_Load(null, null);
            }
        }




        private void AddActionButtons()
        {
            // Xóa cột cũ nếu đã tồn tại
            if (dgvTourList.Columns["View"] != null)
                dgvTourList.Columns.Remove("View");
            if (dgvTourList.Columns["Edit"] != null)
                dgvTourList.Columns.Remove("Edit");
            if (dgvTourList.Columns["Delete"] != null)
                dgvTourList.Columns.Remove("Delete");

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
            dgvTourList.Columns.AddRange(new DataGridViewColumn[] { btnView, btnEdit, btnDelete });

            // Căn giữa nội dung trong cột
            foreach (DataGridViewColumn col in dgvTourList.Columns)
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // Xử lý sự kiện click
            //dgvTourList.CellClick += DgvTourList_CellClick;
        }



        private void btnAddTour_Click(object sender, EventArgs e)
        {
            AddTourForm form = new AddTourForm();
            form.ShowDialog();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            TourForm_Load(sender, e);
        }

        private void dgvTourList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
