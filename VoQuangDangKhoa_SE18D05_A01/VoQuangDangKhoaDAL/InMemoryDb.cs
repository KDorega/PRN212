using System;
using System.Collections.Generic;
using VoQuangDangKhoaDAL.Models;

namespace VoQuangDangKhoaDAL
{
    public class InMemoryDb
    {
        private static InMemoryDb _instance;
        public static InMemoryDb Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new InMemoryDb();
                }
                return _instance;
            }
        }

        public List<Customer> Customers { get; set; } 
        public List<Room> Rooms { get; set; }
        public List<RoomType> RoomTypes { get; set; }
        public List<Booking> Bookings { get; set; }

        private InMemoryDb()
        {
            Customers = new List<Customer>();
            Rooms = new List<Room>();
            RoomTypes = new List<RoomType>();
            Bookings = new List<Booking>();

            // Khởi tạo dữ liệu mẫu
            InitializeSampleData();
        }

        private void InitializeSampleData()
        {
            // Thêm dữ liệu mẫu cho RoomType
            RoomTypes.Add(new RoomType { RoomTypeID = 1, RoomTypeName = "Standard", TypeDescription = "Basic room", TypeNote = "No view" });
            RoomTypes.Add(new RoomType { RoomTypeID = 2, RoomTypeName = "Deluxe", TypeDescription = "Premium room", TypeNote = "Sea view" });

            // Thêm dữ liệu mẫu cho Room
            Rooms.Add(new Room { RoomID = 1, RoomNumber = "101", RoomDescription = "Standard room", RoomMaxCapacity = 2, RoomStatus = 1, RoomPricePerDate = 50m, RoomTypeID = 1 });
            Rooms.Add(new Room { RoomID = 2, RoomNumber = "201", RoomDescription = "Deluxe room", RoomMaxCapacity = 4, RoomStatus = 1, RoomPricePerDate = 100m, RoomTypeID = 2 });

            // Thêm dữ liệu mẫu cho Customer
            Customers.Add(new Customer { CustomerID = 1, CustomerFullName = "Admin", EmailAddress = "admin@FUMiniHotelSystem.com", Password = "@@abc123@@", CustomerStatus = 1, Telephone = "0123456789", CustomerBirthday = DateTime.Now.AddYears(-30) });
            Customers.Add(new Customer { CustomerID = 2, CustomerFullName = "John Doe", EmailAddress = "john@example.com", Password = "123456", CustomerStatus = 1, Telephone = "0987654321", CustomerBirthday = new DateTime(1990, 1, 1) });
        }
    }
}
