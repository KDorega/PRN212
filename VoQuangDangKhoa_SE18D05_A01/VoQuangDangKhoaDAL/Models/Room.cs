namespace VoQuangDangKhoaDAL.Models
{
    public class Room
    {
        public int RoomID { get; set; }
        public string RoomNumber { get; set; } // max 50 chars
        public string RoomDescription { get; set; } // max 220 chars
        public int RoomMaxCapacity { get; set; }
        public int RoomStatus { get; set; } // 1: Active, 2: Deleted
        public decimal RoomPricePerDate { get; set; }
        public int RoomTypeID { get; set; }
        public RoomType RoomType { get; set; } // Navigation property
    }
}
