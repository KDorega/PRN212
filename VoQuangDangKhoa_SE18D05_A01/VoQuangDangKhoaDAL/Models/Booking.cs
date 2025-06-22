using System;

namespace VoQuangDangKhoaDAL.Models
{
    public class Booking
    {
        public int BookingID { get; set; }
        public int CustomerID { get; set; }
        public int RoomID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalPrice { get; set; }
        public Customer Customer { get; set; } // Navigation property
        public Room Room { get; set; } // Navigation property
    }
}
