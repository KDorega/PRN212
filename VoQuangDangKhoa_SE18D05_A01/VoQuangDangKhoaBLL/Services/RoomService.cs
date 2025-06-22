using System;
using System.Collections.Generic;
using VoQuangDangKhoaDAL.Models;
using VoQuangDangKhoaDAL.Repositories;

namespace VoQuangDangKhoaBLL.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public IEnumerable<Room> GetAllRooms() => _roomRepository.GetAll();

        public Room GetRoomById(int id) => _roomRepository.GetById(id);

        public void AddRoom(Room room)
        {
            ValidateRoomData(room);
            _roomRepository.Add(room);
        }

        public void UpdateRoom(Room room)
        {
            ValidateRoomData(room);
            _roomRepository.Update(room);
        }

        public void DeleteRoom(int id) => _roomRepository.Delete(id);

        public IEnumerable<Room> SearchRoomsByRoomNumber(string roomNumber) => _roomRepository.SearchByRoomNumber(roomNumber);

        private void ValidateRoomData(Room room)
        {
            if (string.IsNullOrEmpty(room.RoomNumber) || room.RoomNumber.Length > 50)
                throw new ArgumentException("Invalid room number.");
            if (string.IsNullOrEmpty(room.RoomDescription) || room.RoomDescription.Length > 220)
                throw new ArgumentException("Invalid room description.");
            if (room.RoomMaxCapacity <= 0)
                throw new ArgumentException("Invalid max capacity.");
            if (room.RoomPricePerDate <= 0)
                throw new ArgumentException("Invalid price.");
            if (room.RoomTypeID <= 0)
                throw new ArgumentException("Invalid room type.");
        }
    }
}
