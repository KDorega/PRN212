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
using Services;
using BusinessObjects.Models;

namespace HuynhPhucTanWPF
{
    /// <summary>
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        private readonly ICustomersService _customerService;
        private readonly Customer currentCustomer;
        private readonly IBookingDetailService _bookingDetailService;

        public CustomerWindow(Customer customer)
        {
            InitializeComponent();
            _customerService = new CustomersService();
            _bookingDetailService = new BookingDetailService();
            currentCustomer = customer;

            LoadProfile();
            LoadBookingHistory();
        }

        private void LoadProfile()
        {
            txtFullName.Text = currentCustomer.CustomerFullName;
            txtEmail.Text = currentCustomer.EmailAddress;
            txtPhone.Text = currentCustomer.Telephone;
            txtPassword.Text = currentCustomer.Password;
        }

        private void LoadBookingHistory()
        {
            try
            {
                var HistoryBooking = _bookingDetailService.GetHistoryBooking(currentCustomer.CustomerId);
                dgBookings.ItemsSource = HistoryBooking;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        private void BtnUpdateProfile_Click(object sender, RoutedEventArgs e)
        {
            currentCustomer.CustomerFullName = txtFullName.Text;
            currentCustomer.Telephone = txtPhone.Text;
            currentCustomer.Password = txtPassword.Text;
            _customerService.UpdateCustomer(currentCustomer);
            MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to logout?", "Confirm Logout", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                // Mở cửa sổ đăng nhập
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.Show();

                // Đóng cửa sổ Admin hiện tại
                this.Close();
            }
        }
    }
}
