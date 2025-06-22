using VoQuangDangKhoaBLL.Services;
using VoQuangDangKhoaWPF.Helpers;
using VoQuangDangKhoaWPF.ViewModels;
using System.Windows;

namespace VoQuangDangKhoaWPF.Views
{
    public partial class CustomerView : Window
    {
        private readonly ICustomerService _customerService;
        private readonly IBookingService _bookingService;
        private int _customerId;

        public CustomerView(ICustomerService customerService, IBookingService bookingService)
        {
            InitializeComponent();
            _customerService = customerService;
            _bookingService = bookingService;
            LoadCustomerInfo();
        }

        private void LoadCustomerInfo()
        {
            try
            {
                var loginViewModel = ServiceProvider.GetService<LoginViewModel>();
                if (loginViewModel != null)
                {
                    var customer = _customerService.GetCustomerByEmail(loginViewModel.Email);
                    if (customer != null)
                    {
                        _customerId = customer.CustomerID;
                        CustomerInfo.Text = $"Welcome, {customer.CustomerFullName}!";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customer info: {ex.Message}");
            }
        }

        private void ViewBookings_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var bookings = _bookingService.GetBookingsByCustomerId(_customerId);
                if (bookings != null && bookings.Any())
                {
                    string bookingDetails = string.Join("\n", bookings.Select(b => $"ID: {b.BookingID}, Room: {b.RoomID}, Start: {b.StartDate:dd/MM/yyyy}, End: {b.EndDate:dd/MM/yyyy}"));
                    MessageBox.Show($"Your Bookings:\n{bookingDetails}");
                }
                else
                {
                    MessageBox.Show("No bookings found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error viewing bookings: {ex.Message}");
            }
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var loginViewModel = ServiceProvider.GetService<LoginViewModel>();
                if (loginViewModel != null)
                {
                    loginViewModel.IsAuthenticated = false;
                    var loginView = new LoginView(loginViewModel);
                    loginView.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error logging out: {ex.Message}");
            }
        }
    }
}