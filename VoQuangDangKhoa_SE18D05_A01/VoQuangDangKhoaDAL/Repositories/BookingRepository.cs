using System;
using System.Collections.Generic;
using System.Linq;
using VoQuangDangKhoaDAL.Data;
using VoQuangDangKhoaDAL.Models;

namespace VoQuangDangKhoaDAL.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly HotelDbContext _context;

        public BookingRepository()
        {
            _context = new HotelDbContext();
        }

        public void AddBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
        }

        public void DeleteBooking(int bookingId)
        {
            var booking = _context.Bookings.Find(bookingId);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                _context.SaveChanges();
            }
        }

        public Booking GetBookingById(int bookingId)
        {
            return _context.Bookings.Find(bookingId);
        }

        public List<Booking> GetAllBookings()
        {
            return _context.Bookings.ToList();
        }

        public List<Booking> GetBookingsByCustomerId(int customerId)
        {
            return _context.Bookings
                .Where(b => b.CustomerID == customerId)
                .ToList();
        }

        public void UpdateBooking(Booking booking)
        {
            _context.Bookings.Update(booking);
            _context.SaveChanges();
        }
        private readonly List<Booking> _bookings = InMemoryDb.Instance.Bookings;

        public IEnumerable<Booking> GetAll() => _bookings;

        public Booking GetById(int id) => _bookings.FirstOrDefault(b => b.BookingID == id);

        public void Add(Booking entity)
        {
            entity.BookingID = _bookings.Any() ? _bookings.Max(b => b.BookingID) + 1 : 1;
            _bookings.Add(entity);
        }

        public void Update(Booking entity)
        {
            var existing = GetById(entity.BookingID);
            if (existing != null)
            {
                existing.CustomerID = entity.CustomerID;
                existing.RoomID = entity.RoomID;
                existing.StartDate = entity.StartDate;
                existing.EndDate = entity.EndDate;
                existing.TotalPrice = entity.TotalPrice;
            }
        }

        public void Delete(int id)
        {
            var booking = GetById(id);
            if (booking != null)
                _bookings.Remove(booking);
        }

        public IEnumerable<Booking> GetByCustomerId(int customerId) =>
            _bookings.Where(b => b.CustomerID == customerId);

        public IEnumerable<Booking> GetByDateRange(DateTime startDate, DateTime endDate) =>
            _bookings.Where(b => b.StartDate >= startDate && b.EndDate <= endDate);
    }
}
