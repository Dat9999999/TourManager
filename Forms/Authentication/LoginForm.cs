using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TourManagerment.Forms.Authentication
{
    public partial class LoginForm : Form
    {
        //sample data user  
        const String SampleUserName = "admin";
        const String SamplePassword = "123";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String UserName = tbUserName.Text;
            String Password = tbPassword.Text;
            if(UserName == "" || 
                Password == "")
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin đăng nhập");
                return;
            }

            if(UserName != SampleUserName ||  Password != SamplePassword)
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");
                return;

            }
            MessageBox.Show("Đăng nhập thành công");


        }
    }
}
