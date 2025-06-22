using VoQuangDangKhoaBLL.Services;
using VoQuangDangKhoaDAL.Models;
using VoQuangDangKhoaWPF.ViewModels;
using System.Windows;
using VoQuangDangKhoaWPF.Helpers;

namespace VoQuangDangKhoaWPF.Views
{
    public partial class RoomTypeManagementView : Window
    {
        private readonly IRoomTypeService _roomTypeService;
           

        public RoomTypeManagementView(IRoomTypeService roomTypeService)
        {
            InitializeComponent();
            _roomTypeService = roomTypeService;
            LoadRoomTypes();
        }

        private void LoadRoomTypes()
        {
            var roomTypes = _roomTypeService.GetAllRoomTypes();
            RoomTypeList.ItemsSource = roomTypes;
        }

        private void AddRoomType_Click(object sender, RoutedEventArgs e)
        {
            var roomType = new RoomType
            {
                RoomTypeName = "New Room Type",
                TypeDescription = "New Room Type Description",
                TypeNote = "New Note"
            };
            _roomTypeService.AddRoomType(roomType);
            LoadRoomTypes();
            MessageBox.Show("Room Type added successfully!");
        }
        private void RoomTypeList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (RoomTypeList.SelectedItem is RoomType roomType)
            {
                var editViewModel = ServiceProvider.GetService<EditViewModel>();
                if (editViewModel != null)
                {
                    editViewModel.LoadItem(roomType, "RoomType");
                    var editView = new EditView(editViewModel);
                    editView.ShowDialog();
                    LoadRoomTypes();
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