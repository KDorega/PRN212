using System.ComponentModel;
using System.Windows.Input;
using VoQuangDangKhoaBLL.Services;
using VoQuangDangKhoaDAL.Models;
using VoQuangDangKhoaWPF.Helpers;

namespace VoQuangDangKhoaWPF.ViewModels
{
    public class EditViewModel : INotifyPropertyChanged
    {
        private readonly ICustomerService _customerService;
        private readonly IRoomService _roomService;
        private readonly IRoomTypeService _roomTypeService;
        private readonly IBookingService _bookingService;

        public string Title { get; set; }
        public string Field1 { get; set; }
        public string Field2 { get; set; }
        public string Field3 { get; set; }
        public string Field4 { get; set; }
        public string Field5 { get; set; }

        public bool IsField1Visible { get; set; }
        public bool IsField2Visible { get; set; }
        public bool IsField3Visible { get; set; }
        public bool IsField4Visible { get; set; }
        public bool IsField5Visible { get; set; }

        public ICommand SaveCommand { get; }

        private object _itemToEdit;
        private string _itemType;

        public EditViewModel(ICustomerService customerService, IRoomService roomService,
            IRoomTypeService roomTypeService, IBookingService bookingService)
        {
            _customerService = customerService;
            _roomService = roomService;
            _roomTypeService = roomTypeService;
            _bookingService = bookingService;
            // Update the RelayCommand instantiation to pass a parameter to match the Action<object> delegate signature.
            SaveCommand = new RelayCommand(_ => Save());
             // Sử dụng lambda để gọi Save
        }

        public void LoadItem(object item, string itemType)
        {
            _itemToEdit = item;
            _itemType = itemType;
            SetupFieldsForItem();
        }

        private void SetupFieldsForItem()
        {
            switch (_itemType)
            {
                case "Customer":
                    var customer = _itemToEdit as Customer;
                    Title = "Edit Customer";
                    Field1 = customer?.CustomerFullName ?? string.Empty; IsField1Visible = true;
                    Field2 = customer?.EmailAddress ?? string.Empty; IsField2Visible = true;
                    Field3 = customer?.Telephone ?? string.Empty; IsField3Visible = true;
                    Field4 = customer?.CustomerBirthday.ToString("dd/MM/yyyy") ?? string.Empty; IsField4Visible = true;
                    Field5 = customer?.Password ?? string.Empty; IsField5Visible = true;
                    break;

                case "Room":
                    var room = _itemToEdit as Room;
                    Title = "Edit Room";
                    Field1 = room?.RoomNumber ?? string.Empty; IsField1Visible = true;
                    Field2 = room?.RoomDescription ?? string.Empty; IsField2Visible = true;
                    Field3 = room?.RoomMaxCapacity.ToString() ?? string.Empty; IsField3Visible = true;
                    Field4 = room?.RoomPricePerDate.ToString() ?? string.Empty; IsField4Visible = true;
                    Field5 = room?.RoomStatus.ToString() ?? string.Empty; IsField5Visible = true;
                    break;

                case "RoomType":
                    var roomType = _itemToEdit as RoomType;
                    Title = "Edit Room Type";
                    Field1 = roomType?.RoomTypeName ?? string.Empty; IsField1Visible = true;
                    Field2 = roomType?.TypeDescription ?? string.Empty; IsField2Visible = true;
                    Field3 = roomType?.TypeNote ?? string.Empty; IsField3Visible = true;
                    Field4 = string.Empty; IsField4Visible = false;
                    Field5 = string.Empty; IsField5Visible = false;
                    break;

                case "Booking":
                    var booking = _itemToEdit as Booking;
                    Title = "Edit Booking";
                    Field1 = booking?.CustomerID.ToString() ?? string.Empty; IsField1Visible = true;
                    Field2 = booking?.RoomID.ToString() ?? string.Empty; IsField2Visible = true;
                    Field3 = booking?.StartDate.ToString("dd/MM/yyyy") ?? string.Empty; IsField3Visible = true;
                    Field4 = booking?.EndDate.ToString("dd/MM/yyyy") ?? string.Empty; IsField4Visible = true;
                    Field5 = booking?.TotalPrice.ToString() ?? string.Empty; IsField5Visible = true;
                    break;
            }
        }

        public void Save()
        {
            switch (_itemType)
            {
                case "Customer":
                    var customer = _itemToEdit as Customer;
                    customer.CustomerFullName = Field1;
                    customer.EmailAddress = Field2;
                    customer.Telephone = Field3;
                    if (DateTime.TryParse(Field4, out DateTime birthday))
                        customer.CustomerBirthday = birthday;
                    customer.Password = Field5;
                    _customerService.UpdateCustomer(customer);
                    break;

                case "Room":
                    var room = _itemToEdit as Room;
                    room.RoomNumber = Field1;
                    room.RoomDescription = Field2;
                    if (int.TryParse(Field3, out int capacity))
                        room.RoomMaxCapacity = capacity;
                    if (decimal.TryParse(Field4, out decimal price))
                        room.RoomPricePerDate = price;
                    if (int.TryParse(Field5, out int status))
                        room.RoomStatus = status;
                    _roomService.UpdateRoom(room);
                    break;

                case "RoomType":
                    var roomType = _itemToEdit as RoomType;
                    roomType.RoomTypeName = Field1;
                    roomType.TypeDescription = Field2;
                    roomType.TypeNote = Field3;
                    _roomTypeService.UpdateRoomType(roomType);
                    break;

                case "Booking":
                    var booking = _itemToEdit as Booking;
                    if (int.TryParse(Field1, out int customerId))
                        booking.CustomerID = customerId;
                    if (int.TryParse(Field2, out int roomId))
                        booking.RoomID = roomId;
                    if (DateTime.TryParse(Field3, out DateTime startDate))
                        booking.StartDate = startDate;
                    if (DateTime.TryParse(Field4, out DateTime endDate))
                        booking.EndDate = endDate;
                    if (decimal.TryParse(Field5, out decimal totalPrice))
                        booking.TotalPrice = totalPrice;
                    _bookingService.UpdateBooking(booking);
                    break;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}