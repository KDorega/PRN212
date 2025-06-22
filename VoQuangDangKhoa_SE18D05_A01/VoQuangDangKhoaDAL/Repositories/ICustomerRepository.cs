using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoQuangDangKhoaDAL.Models;

namespace VoQuangDangKhoaDAL.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetByEmail(string email);
        IEnumerable<Customer> SearchByName(string name);
    }
}
