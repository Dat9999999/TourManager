using TourManagerment.Forms;
using TourManagerment.Forms.Authentication;
using TourManagerment.Forms.Booking;
using TourManagerment.Forms.CustomerManagement;
using TourManagerment.Forms.Report;
using TourManagerment.Forms.ScheduleManagement;
using TourManagerment.Models;

namespace TourManagerment
{
    public partial class MainForm : Form
    {
        private User currentUser;

        public MainForm(User user)
        {
            InitializeComponent();
            currentUser = user;
        }
        private void ShowLoginForm()
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                //truyền thông tin user từ form login 
                currentUser = loginForm.AuthenticatedUser;
                this.Show();
                Authorization();
            }
            else
            {
                // Đóng MainForm nếu đăng nhập thất bại hoặc bị hủy
                this.Close();
            }
        }
        private void Authorization()
        {
            // Reset tất cả control nhạy cảm
            ResetAuthorizationControls();

            string role = currentUser.Role;

            switch (role)
            {
                case "admin":
                    ConfigureAdminPermissions();
                    break;
                case "employee":
                    ConfigureEmployeePermissions();
                    break;
                default:
                    HandleUnauthorizedUser();
                    break;
            }
        }
        private void ResetAuthorizationControls()
        {
            btnReport.Visible = false;
            btnManageTour.Visible = false;
        }

        private void ConfigureAdminPermissions()
        {
            btnReport.Visible = true;
            btnManageTour.Visible = true;
        }

        private void ConfigureEmployeePermissions()
        {
            btnManageTour.Visible = true;
        }



        private void HandleUnauthorizedUser()
        {
            MessageBox.Show("Tài khoản không có quyền truy cập");
            this.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (currentUser == null)
            {
                ShowLoginForm();
            }
        }

        private void btnShowTourForm_Click(object sender, EventArgs e)
        {
            TourForm tourForm = new TourForm();
            tourForm.ShowDialog();
        }
        private void btnManageCustomer_Click(object sender, EventArgs e)
        {
            CustomerForm f = new CustomerForm();
            f.ShowDialog();
        }
        private void btnManageTourOrder_Click(object sender, EventArgs e)
        {
            TourOrderForm f = new TourOrderForm();
            f.ShowDialog();
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            ScheduleForm f = new ScheduleForm();
            f.ShowDialog();
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            ReportForm f = new ReportForm();

            f.ShowDialog();
        }

        private void btnStatisticsForm_Click(object sender, EventArgs e)
        {
            //StatisticsForm f = new StatisticsForm();
            //f.ShowDialog();
        }

        private void lblRole_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            currentUser = null;
            //Load lại form 
            MainForm_Load(sender, e);
        }


    }
}
