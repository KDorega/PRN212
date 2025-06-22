using VoQuangDangKhoaBLL.Services;
using VoQuangDangKhoaDAL.Models;
using VoQuangDangKhoaWPF.ViewModels;
using System;
using System.Windows;
using VoQuangDangKhoaWPF.Helpers;

namespace VoQuangDangKhoaWPF.Views
{
    public partial class BookingManagementView : Window
    {
        private readonly IBookingService _bookingService;

        public BookingManagementView(IBookingService bookingService)
        {
            InitializeComponent();
            _bookingService = bookingService;
            LoadBookings();
        }

        private void LoadBookings()
        {
            var bookings = _bookingService.GetAllBookings();
            BookingList.ItemsSource = bookings;
        }

        private void AddBooking_Click(object sender, RoutedEventArgs e)
        {
            var booking = new Booking
            {
                CustomerID = 1,
                RoomID = 1,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
                TotalPrice = 100m
            };
            _bookingService.AddBooking(booking);
            LoadBookings();
            MessageBox.Show("Booking added successfully!");
        }

        private void BookingList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (BookingList.SelectedItem is Booking booking)
            {
                var editViewModel = ServiceProvider.GetService<EditViewModel>();
                if (editViewModel != null)
                {
                    editViewModel.LoadItem(booking, "Booking");
                    var editView = new EditView(editViewModel);
                    editView.ShowDialog();
                    LoadBookings();
                }
            }
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var adminViewModel = ServiceProvider.GetService<AdminViewModel>();
            if (adminViewModel != null)
            {
                var adminView = new AdminView(adminViewModel);
                adminView.Show();
                this.Close();
            }
        }

    }
}