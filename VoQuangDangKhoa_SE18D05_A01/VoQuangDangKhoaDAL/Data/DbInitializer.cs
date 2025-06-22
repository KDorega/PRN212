using System;
using System.Linq;
using VoQuangDangKhoaDAL.Data;
using VoQuangDangKhoaDAL.Models;

namespace VoQuangDangKhoaDAL.Data
{
    public static class DbInitializer
    {
        public static void Initialize(HotelDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Customers.Any())
            {
                return; // Đã có dữ liệu, không cần khởi tạo lại
            }

            var customers = new Customer[]
            {
                new Customer { CustomerID = 1, CustomerFullName = "Admin User", EmailAddress = "admin@FUMiniHotelSystem.com", Password = "@@abc123@@", Telephone = "1234567890", CustomerBirthday = new DateTime(1990, 1, 1) },
                new Customer { CustomerID = 2, CustomerFullName = "Customer One", EmailAddress = "customer1@hotel.com", Password = "pass123", Telephone = "0987654321", CustomerBirthday = new DateTime(1995, 5, 15) }
            };
            context.Customers.AddRange(customers);

            var roomTypes = new RoomType[]
            {
                new RoomType { RoomTypeID = 1, RoomTypeName = "Standard", TypeDescription = "Basic room", TypeNote = "For 2 people" }
            };
            context.RoomTypes.AddRange(roomTypes);

            var rooms = new Room[]
            {
                new Room { RoomID = 1, RoomNumber = "101", RoomDescription = "Room 101", RoomMaxCapacity = 2, RoomStatus = 1, RoomPricePerDate = 50m, RoomTypeID = 1 }
            };
            context.Rooms.AddRange(rooms);

            context.SaveChanges();
        }
    }
}