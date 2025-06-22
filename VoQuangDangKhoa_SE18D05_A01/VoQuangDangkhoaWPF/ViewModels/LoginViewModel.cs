using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using VoQuangDangKhoaBLL.Services;
using VoQuangDangKhoaWPF.Helpers;
using VoQuangDangKhoaWPF.Views;

namespace VoQuangDangKhoaWPF.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private readonly ICustomerService _customerService;
        private string _email;
        private string _errorMessage;
        private bool _isAuthenticated;

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public bool IsAuthenticated
        {
            get => _isAuthenticated;
            set
            {
                _isAuthenticated = value;
                OnPropertyChanged(nameof(IsAuthenticated));
            }
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel(ICustomerService customerService)
        {
            _customerService = customerService;
            LoginCommand = new RelayCommand(Login, CanLogin);
        }

        private bool CanLogin(object parameter) => !string.IsNullOrEmpty(Email);

        private void Login(object parameter)
        {
            var passwordBox = parameter as PasswordBox;
            var password = passwordBox?.Password;

            try
            {
                if (_customerService.ValidateCustomer(Email, password))
                {
                    var customer = _customerService.GetCustomerByEmail(Email);
                    IsAuthenticated = true;
                    if (customer.EmailAddress == "admin@FUMiniHotelSystem.com")
                    {
                        var adminViewModel = ServiceProvider.GetService<AdminViewModel>();
                        if (adminViewModel != null)
                        {
                            var adminView = new AdminView(adminViewModel);
                            adminView.Show();
                            (parameter as PasswordBox)?.TryFindParent<Window>()?.Close();
                        }
                        else
                        {
                            ErrorMessage = "Failed to load AdminViewModel.";
                        }
                    }
                    else
                    {
                        var customerService = ServiceProvider.GetService<ICustomerService>();
                        var bookingService = ServiceProvider.GetService<IBookingService>();
                        if (customerService != null && bookingService != null)
                        {
                            var customerView = new CustomerView(customerService, bookingService);
                            customerView.Show();
                            (parameter as PasswordBox)?.TryFindParent<Window>()?.Close();
                        }
                        else
                        {
                            ErrorMessage = "Failed to load Customer services.";
                        }
                    }
                }
                else
                {
                    ErrorMessage = "Invalid email or password.";
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"An error occurred: {ex.Message}";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}