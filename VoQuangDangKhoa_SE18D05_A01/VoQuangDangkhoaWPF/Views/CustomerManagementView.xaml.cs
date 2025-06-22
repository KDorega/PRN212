using VoQuangDangKhoaBLL.Services;
using VoQuangDangKhoaDAL.Models;
using VoQuangDangKhoaWPF.ViewModels;
using System;
using System.Windows;
using VoQuangDangKhoaWPF.Helpers;

namespace VoQuangDangKhoaWPF.Views
{
    public partial class CustomerManagementView : Window
    {
        private readonly ICustomerService _customerService;

        public CustomerManagementView(ICustomerService customerService)
        {
            InitializeComponent();
            _customerService = customerService;
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            var customers = _customerService.GetAllCustomers();
            CustomerList.ItemsSource = customers;
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            var searchText = SearchBox.Text;
            var customers = _customerService.SearchCustomersByName(searchText);
            CustomerList.ItemsSource = customers;
        }

        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            var customer = new Customer
            {
                CustomerFullName = "New Customer",
                EmailAddress = "new@customer.com",
                Telephone = "1234567890",
                CustomerBirthday = new DateTime(1990, 1, 1),
                Password = "newpass123"
            };
            _customerService.AddCustomer(customer);
            LoadCustomers();
            MessageBox.Show("Customer added successfully!");
        }
        private void CustomerList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (CustomerList.SelectedItem is Customer customer)
            {
                var editViewModel = ServiceProvider.GetService<EditViewModel>();
                if (editViewModel != null)
                {
                    editViewModel.LoadItem(customer, "Customer");
                    var editView = new EditView(editViewModel);
                    editView.ShowDialog();
                    LoadCustomers();
                }
            }
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var adminViewModel = ServiceProvider.GetService<AdminViewModel>();
            if (adminViewModel != null)
            {
                var adminView = new AdminView(adminViewModel);
                adminView.Show();
                this.Close();
            }
        }
    }
}