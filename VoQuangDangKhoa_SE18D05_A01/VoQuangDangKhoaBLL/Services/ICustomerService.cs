using System.Collections.Generic;
using VoQuangDangKhoaDAL.Models;

namespace VoQuangDangKhoaBLL.Services
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        Customer GetCustomerByEmail(string email);
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int id);
        IEnumerable<Customer> SearchCustomersByName(string name);
        bool ValidateCustomer(string email, string password);
    }
}
