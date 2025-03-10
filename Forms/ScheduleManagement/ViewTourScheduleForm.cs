using TourManagerment.DTO;
using TourManagerment.Services;

namespace TourManagerment.Forms.ScheduleManagement
{
    public partial class ViewTourScheduleForm : Form
    {
        private readonly int _tourOrderId;
        private readonly TourOrderService _tourOrderService;
        private readonly ScheduleService _scheduleService;
        private ScheduleDTO _schedule;

        public ViewTourScheduleForm(int tourOrderId)
        {
            InitializeComponent();
            _tourOrderId = tourOrderId;
            _tourOrderService = new TourOrderService();
            _scheduleService = new ScheduleService();
            LoadScheduleData();
        }

        private async void LoadScheduleData()
        {
            try
            {
                var tourOrder = await _tourOrderService.GetByIdWithDetailsAsync(_tourOrderId);
                if (tourOrder == null)
                {
                    MessageBox.Show("Không tìm thấy đơn hàng tour!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                var schedules = await _scheduleService.GetAllSchedulesAsync();
                _schedule = schedules.FirstOrDefault(s =>
                    s.TourOrderInfo.Contains($"ID({_tourOrderId})"));

                if (_schedule == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin lịch trình!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                txtCustomer.Text = _schedule.CustomerInfo;
                txtTour.Text = _schedule.TourInfo;
                txtTourStatus.Text = _schedule.TourStatus;
                txtTimeStatus.Text = _schedule.TimeStatus;
                txtOrder.Text = _schedule.TourOrderInfo;
                txtInvoice.Text = _schedule.InvoiceInfo;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}