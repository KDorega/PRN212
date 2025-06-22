using System;
using System.Collections.Generic;
using VoQuangDangKhoaDAL.Models;
using VoQuangDangKhoaDAL.Repositories;

namespace VoQuangDangKhoaBLL.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IEnumerable<Customer> GetAllCustomers() => _customerRepository.GetAll();

        public Customer GetCustomerById(int id) => _customerRepository.GetById(id);

        public Customer GetCustomerByEmail(string email) => _customerRepository.GetByEmail(email);

        public void AddCustomer(Customer customer)
        {
            ValidateCustomerData(customer);
            _customerRepository.Add(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            ValidateCustomerData(customer);
            _customerRepository.Update(customer);
        }

        public void DeleteCustomer(int id) => _customerRepository.Delete(id);

        public IEnumerable<Customer> SearchCustomersByName(string name) => _customerRepository.SearchByName(name);

        public bool ValidateCustomer(string email, string password)
        {
            var customer = _customerRepository.GetByEmail(email);
            return customer != null && customer.Password == password;
        }

        private void ValidateCustomerData(Customer customer)
        {
            if (string.IsNullOrEmpty(customer.CustomerFullName) || customer.CustomerFullName.Length > 50)
                throw new ArgumentException("Invalid full name.");
            if (string.IsNullOrEmpty(customer.EmailAddress) || customer.EmailAddress.Length > 50)
                throw new ArgumentException("Invalid email address.");
            if (string.IsNullOrEmpty(customer.Telephone) || customer.Telephone.Length > 12)
                throw new ArgumentException("Invalid telephone.");
            if (string.IsNullOrEmpty(customer.Password) || customer.Password.Length > 50)
                throw new ArgumentException("Invalid password.");
            if (customer.CustomerBirthday > DateTime.Now)
                throw new ArgumentException("Invalid birthday.");
        }
    }
}
