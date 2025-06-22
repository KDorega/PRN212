using System.Collections.Generic;
using System.Linq;
using VoQuangDangKhoaDAL.Data;
using VoQuangDangKhoaDAL.Models;



namespace VoQuangDangKhoaDAL.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelDbContext _context;

        public RoomRepository()
        {
            _context = new HotelDbContext();
        }

        public void AddRoom(Room room)
        {
            _context.Rooms.Add(room);
            _context.SaveChanges();
        }

        public void DeleteRoom(int roomId)
        {
            var room = _context.Rooms.Find(roomId);
            if (room != null)
            {
                _context.Rooms.Remove(room);
                _context.SaveChanges();
            }
        }

        public Room GetRoomById(int roomId)
        {
            return _context.Rooms.Find(roomId);
        }

        public List<Room> GetAllRooms()
        {
            return _context.Rooms.ToList();
        }

        public void UpdateRoom(Room room)
        {
            _context.Rooms.Update(room);
            _context.SaveChanges();
        }

        public List<Room> SearchRoomsByRoomNumber(string roomNumber)
        {
            return _context.Rooms
                .Where(r => r.RoomNumber.Contains(roomNumber))
                .ToList();
        }
    

        private readonly List<Room> _rooms = InMemoryDb.Instance.Rooms;

        public IEnumerable<Room> GetAll() => _rooms.Where(r => r.RoomStatus == 1);

        public Room GetById(int id) => _rooms.FirstOrDefault(r => r.RoomID == id && r.RoomStatus == 1);

        public void Add(Room entity)
        {
            entity.RoomID = _rooms.Any() ? _rooms.Max(r => r.RoomID) + 1 : 1;
            _rooms.Add(entity);
        }

        public void Update(Room entity)
        {
            var existing = GetById(entity.RoomID);
            if (existing != null)
            {
                existing.RoomNumber = entity.RoomNumber;
                existing.RoomDescription = entity.RoomDescription;
                existing.RoomMaxCapacity = entity.RoomMaxCapacity;
                existing.RoomStatus = entity.RoomStatus;
                existing.RoomPricePerDate = entity.RoomPricePerDate;
                existing.RoomTypeID = entity.RoomTypeID;
            }
        }

        public void Delete(int id)
        {
            var room = GetById(id);
            if (room != null)
                room.RoomStatus = 2; // Soft delete
        }

        public IEnumerable<Room> SearchByRoomNumber(string roomNumber) =>
            _rooms.Where(r => r.RoomNumber.ToLower().Contains(roomNumber.ToLower()) && r.RoomStatus == 1);
    }
}
