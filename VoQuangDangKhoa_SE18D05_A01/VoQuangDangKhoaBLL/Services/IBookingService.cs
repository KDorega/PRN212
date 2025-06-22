using System;
using System.Collections.Generic;
using VoQuangDangKhoaDAL.Models;

namespace VoQuangDangKhoaBLL.Services
{
    public interface IBookingService
    {
        IEnumerable<Booking> GetAllBookings();
        Booking GetBookingById(int id);
        void AddBooking(Booking booking);
        void UpdateBooking(Booking booking);
        void DeleteBooking(int id);
        IEnumerable<Booking> GetBookingsByCustomerId(int customerId);
        IEnumerable<Booking> GetBookingsByDateRange(DateTime startDate, DateTime endDate);
    }
}
