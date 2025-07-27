using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BusinessObjects.Models;
using Services;

namespace HuynhPhucTanWPF
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly ICustomersService _customersService;
        public LoginWindow()
        {
            _customersService = new CustomersService();
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            String email = txtUser.Text;
            String password = txtPass.Password;

            var user = _customersService.GetCustomerByEmail(email);
            if (user != null && user.Password == password)
            {
                if (user.EmailAddress == "admin@FUMiniHotelSystem.com")
                {
                    new AdminWindow().Show();
                    this.Close();
                }
                else
                {
                    new CustomerWindow(user).Show();
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("Sai email hoặc mật khẩu!", "Đăng nhập thất bại",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }


        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
