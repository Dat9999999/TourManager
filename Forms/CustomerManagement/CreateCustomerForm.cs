using TourManagerment.Models;
using TourManagerment.Services;

namespace TourManagerment.Forms.CustomerManagement
{
    public partial class CreateCustomerForm : Form
    {
        private readonly CustomerService _customerService;

        public CreateCustomerForm()
        {
            InitializeComponent();
            _customerService = new CustomerService();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string address = txtAddress.Text.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(address))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var existingCustomer = await _customerService.GetCustomerByPhoneAsync(phone);
            if (existingCustomer != null)
            {
                var result = MessageBox.Show("Số điện thoại này đã tồn tại. Bạn có muốn cập nhật thông tin khách hàng không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    existingCustomer.Name = name;
                    existingCustomer.Address = address;
                    await _customerService.UpdateCustomerAsync(existingCustomer);
                    MessageBox.Show("Cập nhật thông tin khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else
            {
                var newCustomer = new Customer
                {
                    Name = name,
                    Phone = phone,
                    Address = address
                };
                await _customerService.AddCustomerAsync(newCustomer);
                MessageBox.Show("Thêm khách hàng mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
