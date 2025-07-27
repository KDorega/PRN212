using BusinessObjects.Models;
using System;
using System.Windows;

namespace HuynhPhucTanWPF
{
    public partial class CustomerPopup : Window
    {
        public Customer CustomerData { get; private set; }
        private readonly bool isUpdateMode;

        public CustomerPopup(Customer? customer = null)
        {
            InitializeComponent();

            if (customer != null)
            {
                isUpdateMode = true;
                CustomerData = customer;

                txtName.Text = customer.CustomerFullName;
                txtEmail.Text = customer.EmailAddress;
                txtEmail.IsEnabled = false; // Không cho sửa Email (định danh duy nhất)
                txtPhone.Text = customer.Telephone;

                if (customer.CustomerBirthday.HasValue)
                    dpBirthday.SelectedDate = customer.CustomerBirthday.Value.ToDateTime(TimeOnly.MinValue);

                txtStatus.Text = customer.CustomerStatus?.ToString() ?? "1";
            }
            else
            {
                isUpdateMode = false;
                CustomerData = new Customer();
                txtStatus.Text = "1"; // Mặc định active
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            // --- Validation ---
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Full Name and Email are required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!isUpdateMode && string.IsNullOrWhiteSpace(txtPassword.Password))
            {
                MessageBox.Show("Password is required when creating a new customer.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // --- Gán dữ liệu vào CustomerData ---
            CustomerData.CustomerFullName = txtName.Text.Trim();
            CustomerData.EmailAddress = txtEmail.Text.Trim();
            CustomerData.Telephone = txtPhone.Text.Trim();
            CustomerData.CustomerBirthday = dpBirthday.SelectedDate.HasValue
                ? DateOnly.FromDateTime(dpBirthday.SelectedDate.Value)
                : null;

            if (byte.TryParse(txtStatus.Text.Trim(), out byte status))
                CustomerData.CustomerStatus = status;

            // Password chỉ lưu nếu có nhập
            if (!string.IsNullOrWhiteSpace(txtPassword.Password))
                CustomerData.Password = txtPassword.Password;

            // --- Trả về DialogResult ---
            DialogResult = true;
            this.Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
    }
}
