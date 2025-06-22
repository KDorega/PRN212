using System.Collections.Generic;
using System.Linq;
using VoQuangDangKhoaDAL.Data;
using VoQuangDangKhoaDAL.Models;

namespace VoQuangDangKhoaDAL.Repositories
{
    public class RoomTypeRepository : IRoomTypeRepository
    {
        private readonly HotelDbContext _context;

        public RoomTypeRepository()
        {
            _context = new HotelDbContext();
        }

        public void AddRoomType(RoomType roomType)
        {
            _context.RoomTypes.Add(roomType);
            _context.SaveChanges();
        }

        public void DeleteRoomType(int roomTypeId)
        {
            var roomType = _context.RoomTypes.Find(roomTypeId);
            if (roomType != null)
            {
                _context.RoomTypes.Remove(roomType);
                _context.SaveChanges();
            }
        }

        public RoomType GetRoomTypeById(int roomTypeId)
        {
            return _context.RoomTypes.Find(roomTypeId);
        }

        public List<RoomType> GetAllRoomTypes()
        {
            return _context.RoomTypes.ToList();
        }

        public void UpdateRoomType(RoomType roomType)
        {
            _context.RoomTypes.Update(roomType);
            _context.SaveChanges();
        }

        private readonly List<RoomType> _roomTypes = InMemoryDb.Instance.RoomTypes;

        public IEnumerable<RoomType> GetAll() => _roomTypes;

        public RoomType GetById(int id) => _roomTypes.FirstOrDefault(rt => rt.RoomTypeID == id);

        public void Add(RoomType entity)
        {
            entity.RoomTypeID = _roomTypes.Any() ? _roomTypes.Max(rt => rt.RoomTypeID) + 1 : 1;
            _roomTypes.Add(entity);
        }

        public void Update(RoomType entity)
        {
            var existing = GetById(entity.RoomTypeID);
            if (existing != null)
            {
                existing.RoomTypeName = entity.RoomTypeName;
                existing.TypeDescription = entity.TypeDescription;
                existing.TypeNote = entity.TypeNote;
            }
        }

        public void Delete(int id)
        {
            var roomType = GetById(id);
            if (roomType != null)
                _roomTypes.Remove(roomType);
        }
    }
}
