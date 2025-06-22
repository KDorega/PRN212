using VoQuangDangKhoaDAL.Models;
using VoQuangDangKhoaDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace VoQuangDangKhoaBLL.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public IEnumerable<Booking> GetAllBookings() => _bookingRepository.GetAll();

        public Booking GetBookingById(int id) => _bookingRepository.GetById(id);

        public void AddBooking(Booking booking)
        {
            ValidateBookingData(booking);
            _bookingRepository.Add(booking);
        }

        public void UpdateBooking(Booking booking)
        {
            ValidateBookingData(booking);
            _bookingRepository.Update(booking);
        }

        public void DeleteBooking(int id) => _bookingRepository.Delete(id);

        public IEnumerable<Booking> GetBookingsByCustomerId(int customerId) => _bookingRepository.GetByCustomerId(customerId);

        public IEnumerable<Booking> GetBookingsByDateRange(DateTime startDate, DateTime endDate) =>
            _bookingRepository.GetByDateRange(startDate, endDate);

        private void ValidateBookingData(Booking booking)
        {
            if (booking.CustomerID <= 0)
                throw new ArgumentException("Invalid customer ID.");
            if (booking.RoomID <= 0)
                throw new ArgumentException("Invalid room ID.");
            if (booking.StartDate >= booking.EndDate)
                throw new ArgumentException("Invalid date range.");
            if (booking.TotalPrice <= 0)
                throw new ArgumentException("Invalid total price.");
        }
    }
}
