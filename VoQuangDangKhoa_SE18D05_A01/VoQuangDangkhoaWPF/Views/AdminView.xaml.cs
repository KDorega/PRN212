using VoQuangDangKhoaWPF.Helpers;
using VoQuangDangKhoaWPF.ViewModels;
using System.Windows;

namespace VoQuangDangKhoaWPF.Views
{
    public partial class AdminView : Window
    {
        public AdminView(AdminViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
            this.Visibility = Visibility.Visible; 
        }

        private void ManageRooms_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is AdminViewModel vm)
                vm.ManageRoomsCommand.Execute(this);
        }

        private void ManageRoomTypes_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is AdminViewModel vm)
                vm.ManageRoomTypesCommand.Execute(this);
        }

        private void ManageBookings_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is AdminViewModel vm)
                vm.ManageBookingsCommand.Execute(this);
        }

        private void ManageCustomers_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is AdminViewModel vm)
                vm.ManageCustomersCommand.Execute(this);
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is AdminViewModel vm)
                vm.LogoutCommand.Execute(this);
        }

        public void HideWindow()
        {
            this.Visibility = Visibility.Hidden;
        }

        public void ShowWindow()
        {
            this.Visibility = Visibility.Visible;
        }
        private void GenerateReport_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is AdminViewModel vm)
                vm.GenerateReportCommand.Execute(this);
        }

    }
}