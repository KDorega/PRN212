using Microsoft.EntityFrameworkCore;
using VoQuangDangKhoaDAL.Models;

namespace VoQuangDangKhoaDAL.Data
{
    public class HotelDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=hotel.db");
        }
    }
}   