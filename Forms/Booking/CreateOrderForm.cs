﻿using TourManagerment.Models;
using TourManagerment.Services;

namespace TourManagerment.Forms.Booking
{
    public partial class CreateOrderForm : Form
    {
        private readonly TourService _tourService;
        private readonly CustomerService _customerService;
        private readonly TourOrderService _orderService;
        private Customer? _existingCustomer;
        private Tour? _selectedTour;

        public CreateOrderForm()
        {
            InitializeComponent();
            _tourService = new TourService();
            _customerService = new CustomerService();
            _orderService = new TourOrderService();
        }

        private async void CreateOrderForm_Load(object sender, EventArgs e)
        {
            await LoadTours();
        }

        private async Task LoadTours()
        {
            var tours = await _tourService.GetAllToursAsync();
            comboBoxTours.DataSource = tours;
            comboBoxTours.DisplayMember = "Name";
            comboBoxTours.ValueMember = "Id";
        }

        private async void txtPhone_TextChanged(object sender, EventArgs e)
        {
            string phone = txtPhone.Text.Trim();
            if (string.IsNullOrEmpty(phone))
                return;

            _existingCustomer = await _customerService.GetCustomerByPhoneAsync(phone);
            if (_existingCustomer != null)
            {
                txtName.Text = _existingCustomer.Name;
                txtAddress.Text = _existingCustomer.Address;
                lblId.Visible = true;
                lblId.Text = $"ID: {_existingCustomer.Id}";
            }
            else
            {
                txtName.Clear();
                txtAddress.Clear();
                lblId.Visible = false;
                lblId.Text = "";
            }
        }

        private async void btnCreateOrder_Click(object sender, EventArgs e)
        {
            string phone = txtPhone.Text.Trim();
            string name = txtName.Text.Trim();
            string address = txtAddress.Text.Trim();

            if (string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(address))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxTours.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn tour!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int tourId = (int)comboBoxTours.SelectedValue;
            _selectedTour = await _tourService.GetTourByIdAsync(tourId);
            if (_selectedTour == null)
            {
                MessageBox.Show("Vui lòng chọn tour hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                customer = await _customerService.GetCustomerByPhoneAsync(phone);
            }

            TourOrder order = new TourOrder
            {
                CreationTime = DateTime.Now,
                Status = "Pending",
                CustomerID = customer.Id,
                TourID = _selectedTour.Id
            };

            await _orderService.AddTourOrderAsync(order);
            MessageBox.Show("Tạo đơn đặt tour thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
