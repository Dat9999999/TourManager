using Microsoft.VisualBasic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TourManagerment.Data;
using TourManagerment.Models;
using TourManagerment.Services;

namespace TourManagerment.Forms.Authentication
{
    public partial class LoginForm : Form
    {
        private readonly IAuthenService authenService;
        public User AuthenticatedUser { get; private set; }
        public LoginForm()
        {
            InitializeComponent();
            authenService = new AuthenService();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = tbUserName.Text.Trim();
            string password = tbPassword.Text.Trim();

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin đăng nhập");
                return;
            }

            User user = await authenService.AuthenticateSynce(userName, password); ;
            
            if (user == null)
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");
                return;
            }

            AuthenticatedUser = user;
            this.DialogResult = DialogResult.OK;
        }
        
        private void LoginForm_Load(object sender, EventArgs e)
        {
        }
    }
}
