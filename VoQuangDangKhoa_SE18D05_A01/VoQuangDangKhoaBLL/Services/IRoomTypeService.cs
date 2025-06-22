using VoQuangDangKhoaDAL.Models;
using System.Collections.Generic;

namespace VoQuangDangKhoaBLL.Services
{
    public interface IRoomTypeService
    {
        IEnumerable<RoomType> GetAllRoomTypes();
        RoomType GetRoomTypeById(int id);
        void AddRoomType(RoomType roomType);
        void UpdateRoomType(RoomType roomType);
        void DeleteRoomType(int id);
    }
}
