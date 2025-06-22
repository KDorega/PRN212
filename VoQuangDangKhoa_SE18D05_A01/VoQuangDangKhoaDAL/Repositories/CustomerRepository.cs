using VoQuangDangKhoaDAL.Data;
using VoQuangDangKhoaDAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace VoQuangDangKhoaDAL.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly HotelDbContext _context;

        public CustomerRepository()
        {
            _context = new HotelDbContext();
        }

        public void AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void DeleteCustomer(int customerId)
        {
            var customer = _context.Customers.Find(customerId);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }
        }

        public Customer GetCustomerByEmail(string email)
        {
            return _context.Customers.FirstOrDefault(c => c.EmailAddress == email);
        }

        public Customer GetCustomerById(int customerId)
        {
            return _context.Customers.Find(customerId);
        }

        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }

        public void UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
        }

        public List<Customer> SearchCustomersByName(string name)
        {
            return _context.Customers
                .Where(c => c.CustomerFullName.Contains(name))
                .ToList();
        }
        private readonly List<Customer> _customers = InMemoryDb.Instance.Customers;

        public IEnumerable<Customer> GetAll() => _customers.Where(c => c.CustomerStatus == 1);

        public Customer GetById(int id) => _customers.FirstOrDefault(c => c.CustomerID == id && c.CustomerStatus == 1);

        public Customer GetByEmail(string email) => _customers.FirstOrDefault(c => c.EmailAddress == email && c.CustomerStatus == 1);

        public void Add(Customer entity)
        {
            entity.CustomerID = _customers.Any() ? _customers.Max(c => c.CustomerID) + 1 : 1;
            _customers.Add(entity);
        }

        public void Update(Customer entity)
        {
            var existing = GetById(entity.CustomerID);
            if (existing != null)
            {
                existing.CustomerFullName = entity.CustomerFullName;
                existing.Telephone = entity.Telephone;
                existing.EmailAddress = entity.EmailAddress;
                existing.CustomerBirthday = entity.CustomerBirthday;
                existing.Password = entity.Password;
                existing.CustomerStatus = entity.CustomerStatus;
            }
        }

        public void Delete(int id)
        {
            var customer = GetById(id);
            if (customer != null)
                customer.CustomerStatus = 2; // Soft delete
        }

        public IEnumerable<Customer> SearchByName(string name) =>
            _customers.Where(c => c.CustomerFullName.ToLower().Contains(name.ToLower()) && c.CustomerStatus == 1);
    }
}
