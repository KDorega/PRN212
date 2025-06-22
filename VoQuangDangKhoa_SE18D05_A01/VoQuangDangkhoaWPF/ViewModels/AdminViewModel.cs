using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using VoQuangDangKhoaBLL.Services;
using VoQuangDangKhoaWPF.Helpers;
using VoQuangDangKhoaWPF.Views;

namespace VoQuangDangKhoaWPF.ViewModels
{
    public class AdminViewModel : INotifyPropertyChanged
    {
        private readonly ICustomerService _customerService;
        private readonly IRoomService _roomService;
        private readonly IRoomTypeService _roomTypeService;
        private readonly IBookingService _bookingService;

        public ICommand ManageRoomsCommand { get; }
        public ICommand ManageRoomTypesCommand { get; }
        public ICommand ManageBookingsCommand { get; }
        public ICommand ManageCustomersCommand { get; }
        public ICommand LogoutCommand { get; }
        public ICommand GenerateReportCommand { get; }

        public AdminViewModel(
            ICustomerService customerService,
            IRoomService roomService,
            IRoomTypeService roomTypeService,
            IBookingService bookingService)
        {
            _customerService = customerService;
            _roomService = roomService;
            _roomTypeService = roomTypeService;
            _bookingService = bookingService;

            ManageRoomsCommand = new RelayCommand(ManageRooms, CanExecuteCommand);
            ManageRoomTypesCommand = new RelayCommand(ManageRoomTypes, CanExecuteCommand);
            ManageBookingsCommand = new RelayCommand(ManageBookings, CanExecuteCommand);
            ManageCustomersCommand = new RelayCommand(ManageCustomers, CanExecuteCommand);
            LogoutCommand = new RelayCommand(Logout, CanExecuteCommand);
            GenerateReportCommand = new RelayCommand(GenerateReport, CanExecuteCommand);
        }

        private bool CanExecuteCommand(object parameter)
        {
            var loginViewModel = ServiceProvider.GetService<LoginViewModel>();
            return loginViewModel?.IsAuthenticated == true;
        }

        private void ManageRooms(object parameter)
        {
            try
            {
                var roomService = ServiceProvider.GetService<IRoomService>();
                if (roomService != null)
                {
                    var adminView = parameter as AdminView;
                    if (adminView != null)
                        adminView.HideWindow();
                    var roomManagementView = new RoomManagementView(roomService);
                    roomManagementView.Closed += (s, e) => adminView?.ShowWindow();
                    roomManagementView.Show();
                }
                else
                {
                    System.Windows.MessageBox.Show("Failed to load RoomService.");
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Error in ManageRooms: {ex.Message}");
            }
        }

        private void ManageRoomTypes(object parameter)
        {
            try
            {
                var roomTypeService = ServiceProvider.GetService<IRoomTypeService>();
                if (roomTypeService != null)
                {
                    var adminView = parameter as AdminView;
                    if (adminView != null)
                        adminView.HideWindow();
                    var roomTypeManagementView = new RoomTypeManagementView(roomTypeService);
                    roomTypeManagementView.Closed += (s, e) => adminView?.ShowWindow();
                    roomTypeManagementView.Show();
                }
                else
                {
                    System.Windows.MessageBox.Show("Failed to load RoomTypeService.");
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Error in ManageRoomTypes: {ex.Message}");
            }
        }

        private void ManageBookings(object parameter)
        {
            try
            {
                var bookingService = ServiceProvider.GetService<IBookingService>();
                if (bookingService != null)
                {
                    var adminView = parameter as AdminView;
                    if (adminView != null)
                        adminView.HideWindow();
                    var bookingManagementView = new BookingManagementView(bookingService);
                    bookingManagementView.Closed += (s, e) => adminView?.ShowWindow();
                    bookingManagementView.Show();
                }
                else
                {
                    System.Windows.MessageBox.Show("Failed to load BookingService.");
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Error in ManageBookings: {ex.Message}");
            }
        }

        private void ManageCustomers(object parameter)
        {
            try
            {
                var customerService = ServiceProvider.GetService<ICustomerService>();
                if (customerService != null)
                {
                    var adminView = parameter as AdminView;
                    if (adminView != null)
                        adminView.HideWindow();
                    var customerManagementView = new CustomerManagementView(customerService);
                    customerManagementView.Closed += (s, e) => adminView?.ShowWindow();
                    customerManagementView.Show();
                }
                else
                {
                    System.Windows.MessageBox.Show("Failed to load CustomerService.");
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Error in ManageCustomers: {ex.Message}");
            }
        }

        private void GenerateReport(object parameter)
        {
            try
            {
                var roomService = ServiceProvider.GetService<IRoomService>();
                var bookingService = ServiceProvider.GetService<IBookingService>();
                if (roomService != null && bookingService != null)
                {
                    var adminView = parameter as AdminView;
                    if (adminView != null)
                        adminView.HideWindow();
                    var reportView = new ReportView(roomService, bookingService);
                    reportView.Closed += (s, e) => adminView?.ShowWindow();
                    reportView.Show();
                }
                else
                {
                    System.Windows.MessageBox.Show("Failed to load Report services.");
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Error in GenerateReport: {ex.Message}");
            }
        }

        private void Logout(object parameter)
        {
            try
            {
                var loginViewModel = ServiceProvider.GetService<LoginViewModel>();
                if (loginViewModel != null)
                {
                    loginViewModel.IsAuthenticated = false;
                    var loginView = new LoginView(loginViewModel);
                    loginView.Show();
                    (parameter as Window)?.Close();
                }
                else
                {
                    System.Windows.MessageBox.Show("Failed to load LoginViewModel.");
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Error in Logout: {ex.Message}");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}