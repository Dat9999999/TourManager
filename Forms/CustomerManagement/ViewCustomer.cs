using TourManagerment.Services;

namespace TourManagerment.Forms.CustomerManagement
{
    public partial class ViewCustomer : Form
    {
        private readonly CustomerService _customerService;
        private readonly int _customerId;

        public ViewCustomer(int customerId)
        {
            InitializeComponent();
            _customerService = new CustomerService();
            _customerId = customerId;
        }

        private async void ViewCustomerForm_Load(object sender, EventArgs e)
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


        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }


    }

}
