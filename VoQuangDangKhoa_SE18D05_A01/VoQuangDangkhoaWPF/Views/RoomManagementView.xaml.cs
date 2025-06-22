using VoQuangDangKhoaBLL.Services;
using VoQuangDangKhoaDAL.Models;
using VoQuangDangKhoaWPF.ViewModels;
using System.Windows;
using System.Windows.Controls;
using VoQuangDangKhoaWPF.Helpers;


namespace VoQuangDangKhoaWPF.Views
{
    public partial class RoomManagementView : Window
    {
        private readonly IRoomService _roomService;



        private void RoomList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (RoomList.SelectedItem is Room room)
            {
                var editViewModel = ServiceProvider.GetService<EditViewModel>();
                if (editViewModel != null)
                {
                    editViewModel.LoadItem(room, "Room");
                    var editView = new EditView(editViewModel);
                    editView.ShowDialog();
                    LoadRooms();
                }
            }
        }
        public RoomManagementView(IRoomService roomService)
        {
            InitializeComponent();
            _roomService = roomService;
            LoadRooms();
        }

        private void LoadRooms()
        {
            var rooms = _roomService.GetAllRooms().Take(10); // Lấy 10 phòng đầu tiên
            RoomList.ItemsSource = rooms.ToList();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            var searchText = SearchBox.Text;
            var rooms = _roomService.SearchRoomsByRoomNumber(searchText);
            RoomList.ItemsSource = rooms;
        }

        private void AddRoom_Click(object sender, RoutedEventArgs e)
        {
            var room = new Room
            {
                RoomNumber = "NewRoom",
                RoomDescription = "New Room Description",
                RoomMaxCapacity = 2,
                RoomStatus = 1,
                RoomPricePerDate = 50m,
                RoomTypeID = 1
            };
            _roomService.AddRoom(room);
            LoadRooms();
            MessageBox.Show("Room added successfully!");
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