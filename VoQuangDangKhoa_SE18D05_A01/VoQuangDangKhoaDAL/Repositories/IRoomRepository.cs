using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoQuangDangKhoaDAL.Models;

namespace VoQuangDangKhoaDAL.Repositories
{
    public interface IRoomRepository : IRepository<Room>
    {
        IEnumerable<Room> SearchByRoomNumber(string roomNumber);
    }
}
