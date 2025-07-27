using System.Windows;
using BusinessObjects.Models;
using Services;

namespace HuynhPhucTanWPF
{
    public partial class AdminWindow : Window
    {
        private readonly ICustomersService _customerService;
        private readonly IRoomInformationService _roomService;
        private readonly IBookingReservationService _bookingService;
        private readonly IBookingDetailService _bookingDetailService;

        public AdminWindow()
        {
            InitializeComponent();
            _customerService = new CustomersService();
            _roomService = new RoomInformationService();
            _bookingService = new BookingReservationService();
            _bookingDetailService = new BookingDetailService();

            LoadCustomers();
            LoadRooms();
            LoadBookings();
        }

        #region Load Methods
        private void LoadCustomers()
        {
            dgCustomers.ItemsSource = _customerService.GetCustomer();
        }

        private void LoadRooms()
        {
            dgRooms.ItemsSource = _roomService.GetRoomInformation();
        }

        private void LoadBookings()
        {
            dgBookings.ItemsSource = _bookingService.GetBookingReservation();
        }
        #endregion

        #region Report
        private void BtnGenerateReport_Click(object sender, RoutedEventArgs e)
        {
            if (dpStartDate.SelectedDate == null || dpEndDate.SelectedDate == null)
            {
                MessageBox.Show("Please select both Start and End date.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DateOnly start = DateOnly.FromDateTime(dpStartDate.SelectedDate.Value);
            DateOnly end = DateOnly.FromDateTime(dpEndDate.SelectedDate.Value);

            if (end < start)
            {
                MessageBox.Show("End date must be after Start date.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var reportList = _bookingDetailService.GetBookingDetailsByPeriod(start, end)
                .OrderByDescending(b => b.StartDate)
                .ToList(); // sắp xếp giảm dần theo ngày bắt đầu

            dgBookingReport.ItemsSource = reportList;
        }
        #endregion

        #region Customer Buttons (stubbed)
        private void BtnAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            var popup = new CustomerPopup();
            if (popup.ShowDialog() == true)
            {
                _customerService.AddCustomer(popup.CustomerData);
                LoadCustomers();
            }
        }

        private void BtnUpdateCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (dgCustomers.SelectedItem is Customer selected)
            {
                var popup = new CustomerPopup(selected);
                if (popup.ShowDialog() == true)
                {
                    _customerService.UpdateCustomer(popup.CustomerData);
                    LoadCustomers();
                }
            }
            else
            {
                MessageBox.Show("Please select a booking to update.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (dgCustomers.SelectedItem is Customer selected)
            {
                var result = MessageBox.Show($"Delete booking ID #{selected.CustomerId}?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    _customerService.DeleteCustomer(selected);
                    LoadCustomers();
                }
            }
            else
            {
                MessageBox.Show("Please select a booking to delete.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnSearchCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtSearchCustomer.Text.Trim(), out int id))
            {
                var customer = _customerService.GetCustomerById(id);
                if (customer != null)
                {
                    dgCustomers.ItemsSource = new List<Customer> { customer };
                }
                else
                {
                    dgCustomers.ItemsSource = null;
                    MessageBox.Show("Customer not found.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                LoadCustomers();
            }
        }

        #endregion


        private void BtnAddRoom_Click(object sender, RoutedEventArgs e)
        {
            var popup = new RoomPopup();
            if (popup.ShowDialog() == true)
            {
                _roomService.AddRoomInformation(popup.RoomData);
                LoadRooms();
            }
        }

        private void BtnUpdateRoom_Click(object sender, RoutedEventArgs e)
        {
            if (dgRooms.SelectedItem is RoomInformation selected)
            {
                var popup = new RoomPopup(selected);
                if (popup.ShowDialog() == true)
                {
                    _roomService.UpdateRoomInformation(popup.RoomData);
                    LoadRooms();
                }
            }
            else
            {
                MessageBox.Show("Please select a room to update.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnDeleteRoom_Click(object sender, RoutedEventArgs e)
        {
            if (dgRooms.SelectedItem is RoomInformation selected)
            {
                var result = MessageBox.Show($"Delete booking ID #{selected.RoomId}?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    _roomService.DeleteRoomInformation(selected);
                    LoadRooms();
                }
            }
            else
            {
                MessageBox.Show("Please select a booking to delete.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnSearchRoom_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtSearchRoom.Text.Trim(), out int roomId))
            {
                var room = _roomService.GetRoomInformationById(roomId);
                if (room != null)
                {
                    dgRooms.ItemsSource = new List<RoomInformation> { room };
                }
                else
                {
                    dgRooms.ItemsSource = null;
                    MessageBox.Show("Room not found.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                LoadRooms();
            }
        }

        #region Booking Buttons (stubbed)
        private void BtnAddBooking_Click(object sender, RoutedEventArgs e)
        {
            var popup = new BookingPopup();
            if (popup.ShowDialog() == true)
            {
                _bookingService.AddBookingReservation(popup.BookingData);
                LoadBookings();
            }
        }

        private void BtnUpdateBooking_Click(object sender, RoutedEventArgs e)
        {
            if (dgBookings.SelectedItem is BookingReservation selected)
            {
                var popup = new BookingPopup(selected);
                if (popup.ShowDialog() == true)
                {
                    _bookingService.UpdateBookingReservation(popup.BookingData);
                    LoadBookings();
                }
            }
            else
            {
                MessageBox.Show("Please select a booking to update.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnDeleteBooking_Click(object sender, RoutedEventArgs e)
        {
            if (dgBookings.SelectedItem is BookingReservation selected)
            {
                var result = MessageBox.Show($"Delete booking ID #{selected.BookingReservationId}?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    _bookingService.DeleteBookingReservation(selected);
                    LoadBookings();
                }
            }
            else
            {
                MessageBox.Show("Please select a booking to delete.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnSearchBooking_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtSearchBooking.Text.Trim(), out int bookingId))
            {
                var booking = _bookingService.GetBookingReservationById(bookingId);
                if (booking != null)
                {
                    dgBookings.ItemsSource = new List<BookingReservation> { booking };
                }
                else
                {
                    dgBookings.ItemsSource = null;
                    MessageBox.Show("Booking not found.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                LoadBookings();
            }
        }
        #endregion
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
