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

namespace HuynhPhucTanWPF
{
    public partial class BookingPopup : Window
    {
        public BookingReservation BookingData { get; private set; }
        private readonly bool isUpdateMode;

        public BookingPopup(BookingReservation? booking = null)
        {
            InitializeComponent();

            if (booking != null)
            {
                isUpdateMode = true;
                BookingData = booking;

                if (booking.BookingDate.HasValue)
                    dpBookingDate.SelectedDate = booking.BookingDate.Value.ToDateTime(TimeOnly.MinValue);

                txtTotalPrice.Text = booking.TotalPrice?.ToString();
                txtCustomerId.Text = booking.CustomerId.ToString();
                txtBookingStatus.Text = booking.BookingStatus?.ToString() ?? "1";
            }
            else
            {
                BookingData = new BookingReservation();
                txtBookingStatus.Text = "1";
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!dpBookingDate.SelectedDate.HasValue ||
                string.IsNullOrWhiteSpace(txtCustomerId.Text))
            {
                MessageBox.Show("Booking Date and Customer ID are required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            BookingData.BookingDate = DateOnly.FromDateTime(dpBookingDate.SelectedDate.Value);

            if (decimal.TryParse(txtTotalPrice.Text, out decimal total))
                BookingData.TotalPrice = total;

            if (int.TryParse(txtCustomerId.Text, out int customerId))
                BookingData.CustomerId = customerId;

            if (byte.TryParse(txtBookingStatus.Text, out byte status))
                BookingData.BookingStatus = status;

            DialogResult = true;
            this.Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
    }
}
