using TourManagerment.Models;
using TourManagerment.Services;

namespace TourManagerment.Forms.Booking
{
    public partial class UpdateTourOrder : Form
    {
        private readonly TourOrderService _tourOrderService;
        private readonly CustomerService _customerService;
        private readonly TourService _tourService;
        private TourOrder? _tourOrder;
        private Customer? _existingCustomer = null;
        private int _tourOrderId;

        public UpdateTourOrder(int tourOrderId)
        {
            InitializeComponent();
            _tourOrderService = new TourOrderService();
            _customerService = new CustomerService();
            _tourService = new TourService();
            _tourOrderId = tourOrderId;
        }

        private async void UpdateTourOrder_Load(object sender, EventArgs e)
        {
            _tourOrder = await _tourOrderService.GetByIdWithDetailsAsync(_tourOrderId);
            if (_tourOrder == null)
            {
                MessageBox.Show("Không tìm thấy đơn đặt tour.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            var tours = await _tourService.GetAllToursAsync();
            comboBoxTours.DataSource = tours;
            comboBoxTours.DisplayMember = "Name";
            comboBoxTours.ValueMember = "Id";

            if (_tourOrder.TourID.HasValue)
                comboBoxTours.SelectedValue = _tourOrder.TourID.Value;

            txtPhone.Text = _tourOrder.Customer?.Phone;
            txtName.Text = _tourOrder.Customer?.Name;
            txtAddress.Text = _tourOrder.Customer?.Address;
            comboBoxStatus.Text = _tourOrder.Status;
        }

        private async void txtPhone_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                _existingCustomer = await _customerService.GetCustomerByPhoneAsync(txtPhone.Text);
                if (_existingCustomer != null)
                {
                    txtName.Text = _existingCustomer.Name;
                    txtAddress.Text = _existingCustomer.Address;
                    lblId.Visible = true;
                    lblId.Text = $"Id: {_existingCustomer.Id}";
                }
                else
                {
                    txtName.Text = "";
                    txtAddress.Text = "";
                    lblId.Visible = false;
                    lblId.Text = $"Id:";
                }
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (_tourOrder == null)
                return;

            int tourId = (int)comboBoxTours.SelectedValue;
            string phone = txtPhone.Text;
            string name = txtName.Text;
            string address = txtAddress.Text;

            if (string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(address))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Customer customer;
            if (_existingCustomer != null && _existingCustomer.Phone == phone)
            {
                if (_existingCustomer.Name != name || _existingCustomer.Address != address)
                {
                    var result = MessageBox.Show("Thông tin khách hàng đã thay đổi. Bạn có muốn cập nhật không?", "Xác nhận", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        _existingCustomer.Name = name;
                        _existingCustomer.Address = address;
                        await _customerService.UpdateCustomerAsync(_existingCustomer);
                    }
                }
                customer = _existingCustomer;
            }
            else
            {
                customer = new Customer { Name = name, Phone = phone, Address = address };
                await _customerService.AddCustomerAsync(customer);
            }

            _tourOrder.TourID = tourId;
            _tourOrder.CustomerID = customer.Id;
            _tourOrder.Status = comboBoxStatus.Text;
            await _tourOrderService.UpdateTourOrderAsync(_tourOrder);

            MessageBox.Show("Cập nhật đơn đặt tour thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
    }
}