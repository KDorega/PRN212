using VoQuangDangKhoaDAL.Models;
using VoQuangDangKhoaDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace VoQuangDangKhoaBLL.Services
{
    public class RoomTypeService : IRoomTypeService
    {
        private readonly IRoomTypeRepository _roomTypeRepository;

        public RoomTypeService(IRoomTypeRepository roomTypeRepository)
        {
            _roomTypeRepository = roomTypeRepository;
        }

        public IEnumerable<RoomType> GetAllRoomTypes() => _roomTypeRepository.GetAll();

        public RoomType GetRoomTypeById(int id) => _roomTypeRepository.GetById(id);

        public void AddRoomType(RoomType roomType)
        {
            ValidateRoomTypeData(roomType);
            _roomTypeRepository.Add(roomType);
        }

        public void UpdateRoomType(RoomType roomType)
        {
            ValidateRoomTypeData(roomType);
            _roomTypeRepository.Update(roomType);
        }

        public void DeleteRoomType(int id) => _roomTypeRepository.Delete(id);

        private void ValidateRoomTypeData(RoomType roomType)
        {
            if (string.IsNullOrEmpty(roomType.RoomTypeName) || roomType.RoomTypeName.Length > 50)
                throw new ArgumentException("Invalid room type name.");
            if (string.IsNullOrEmpty(roomType.TypeDescription) || roomType.TypeDescription.Length > 250)
                throw new ArgumentException("Invalid type description.");
            if (string.IsNullOrEmpty(roomType.TypeNote) || roomType.TypeNote.Length > 250)
                throw new ArgumentException("Invalid type note.");
        }
    }
}
