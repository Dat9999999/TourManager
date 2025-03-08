using TourManagerment.Models;
using TourManagerment.Services;

namespace TourManagerment.Forms.CustomerManagement
{
    public partial class UpdateCustomerForm : Form
    {
        private readonly CustomerService _customerService;
        private readonly int _customerId;

        public UpdateCustomerForm(int customerId)
        {
            InitializeComponent();
            _customerService = new CustomerService();
            _customerId = customerId;
        }

        private async void UpdateCustomerForm_Load(object sender, EventArgs e)
        {
            await LoadCustomerData();
        }

        private async Task LoadCustomerData()
        {
            var customer = await _customerService.GetCustomerByIdAsync(_customerId);
            if (customer != null)
            {
                txtName.Text = customer.Name;
                txtPhone.Text = customer.Phone;
                txtAddress.Text = customer.Address;
            }
            else
            {
                MessageBox.Show("Không tìm thấy khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var name = txtName.Text.Trim();
            var phone = txtPhone.Text.Trim();
            var address = txtAddress.Text.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(address))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var existingCustomer = await _customerService.GetCustomerByPhoneAsync(phone);
            if (existingCustomer != null && existingCustomer.Id != _customerId)
            {
                MessageBox.Show("Số điện thoại đã tồn tại, vui lòng nhập số khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var updatedCustomer = new Customer
            {
                Id = _customerId,
                Name = name,
                Phone = phone,
                Address = address
            };

            await _customerService.UpdateCustomerAsync(updatedCustomer);
            MessageBox.Show("Cập nhật thông tin khách hàng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

}
