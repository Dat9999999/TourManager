using TourManagerment.Services;

namespace TourManagerment.Forms.Booking
{
    public partial class ViewTourOrder : Form
    {
        private readonly int _orderId;
        private readonly TourOrderService _tourOrderService;

        public ViewTourOrder(int orderId)
        {
            InitializeComponent();
            _orderId = orderId;
            _tourOrderService = new TourOrderService();
        }

        private async void ViewTourOrder_Load(object sender, EventArgs e)
        {
            await LoadTourOrderDetails();
        }

        private async Task LoadTourOrderDetails()
        {
            var order = await _tourOrderService.GetByIdWithDetailsAsync(_orderId);
            if (order == null)
            {
                MessageBox.Show("Không tìm thấy đơn đặt tour!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            // Hiển thị thông tin đơn hàng
            lblOrderId.Text = $"Id: {order.Id}";
            lblCreationDate.Text = $"Ngày tạo: {order.CreationTime:dd/MM/yyyy}";
            lblStatus.Text = $"Trạng thái: {order.Status}";

            // Hiển thị thông tin khách hàng
            if (order.Customer != null)
            {
                lblCustomerName.Text = $"Khách hàng: {order.CustomerID} - {order.Customer.Name}";
                lblPhone.Text = $"Số điện thoại: {order.Customer.Phone}";
                lblAddress.Text = $"Địa chỉ: {order.Customer.Address}";
            }
            else
            {
                lblCustomerName.Text = "Khách hàng: N/A";
                lblPhone.Text = "Số điện thoại: N/A";
                lblAddress.Text = "Địa chỉ: N/A";
            }

            // Hiển thị thông tin tour
            if (order.Tour != null)
            {
                lblTourName.Text = $"Tour: {order.Tour.Id} - {order.Tour.Name}";
                lblStartDate.Text = $"Ngày bắt đầu: {order.Tour.StartDate:dd/MM/yyyy}";
                lblEndDate.Text = $"Ngày kết thúc: {order.Tour.EndDate:dd/MM/yyyy}";
            }
            else
            {
                lblTourName.Text = "Tour: N/A";
                lblStartDate.Text = "Ngày bắt đầu: N/A";
                lblEndDate.Text = "Ngày kết thúc: N/A";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
