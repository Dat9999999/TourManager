using TourManagerment.Models;
using TourManagerment.Services;

namespace TourManagerment.Forms.ScheduleManagement
{
    public partial class PayForm : Form
    {
        private readonly int _tourOrderId;
        private readonly TourOrderService _tourOrderService;
        private readonly InvoiceService _invoiceService;
        private TourOrder _tourOrder;

        public PayForm(int tourOrderId)
        {
            InitializeComponent();
            _tourOrderId = tourOrderId;
            _tourOrderService = new TourOrderService();
            _invoiceService = new InvoiceService();
            LoadTourOrderData();
        }

        private async void LoadTourOrderData()
        {
            try
            {
                _tourOrder = await _tourOrderService.GetByIdWithDetailsAsync(_tourOrderId);
                if (_tourOrder == null)
                {
                    MessageBox.Show("Không tìm thấy đơn hàng tour!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                if (_tourOrder.Invoice != null)
                {
                    MessageBox.Show("Đơn hàng này đã được thanh toán!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    return;
                }

                if (_tourOrder.Tour != null)
                {
                    nudAmount.Value = _tourOrder.Tour.Cost;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private async void btnPay_Click(object sender, EventArgs e)
        {
            try
            {
                if (_tourOrder == null || _tourOrder.Tour == null)
                {
                    MessageBox.Show("Không có thông tin tour để thanh toán!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Tạo invoice mới
                Invoice invoice = new Invoice
                {
                    amount = (long)nudAmount.Value,
                    createdAt = DateTime.Now,
                    TourOrderID = _tourOrderId
                };

                // Lưu invoice
                await _invoiceService.AddInvoiceAsync(invoice);

                // Cập nhật trạng thái tour order
                _tourOrder.Status = "Complete";
                await _tourOrderService.UpdateTourOrderAsync(_tourOrder);

                MessageBox.Show("Thanh toán thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xử lý thanh toán: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}