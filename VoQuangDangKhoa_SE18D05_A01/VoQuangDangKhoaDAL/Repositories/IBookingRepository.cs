using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoQuangDangKhoaDAL.Models;

namespace VoQuangDangKhoaDAL.Repositories
{
    public interface IBookingRepository : IRepository<Booking>
    {
        IEnumerable<Booking> GetByCustomerId(int customerId);
        IEnumerable<Booking> GetByDateRange(DateTime startDate, DateTime endDate);
    }
}
