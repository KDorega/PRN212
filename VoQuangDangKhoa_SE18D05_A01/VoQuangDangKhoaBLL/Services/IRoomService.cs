using System.Collections.Generic;
using VoQuangDangKhoaDAL.Models;

namespace VoQuangDangKhoaBLL.Services
{
    public interface IRoomService
    {
        IEnumerable<Room> GetAllRooms();
        Room GetRoomById(int id);
        void AddRoom(Room room);
        void UpdateRoom(Room room);
        void DeleteRoom(int id);
        IEnumerable<Room> SearchRoomsByRoomNumber(string roomNumber);
    }
}
