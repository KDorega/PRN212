using VoQuangDangKhoaBLL.Services;
using VoQuangDangKhoaWPF.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using VoQuangDangKhoaWPF.Helpers;

namespace VoQuangDangKhoaWPF.Views
{
    public partial class ReportView : Window
    {
        private readonly IRoomService _roomService;
        private readonly IBookingService _bookingService;

        public ReportView(IRoomService roomService, IBookingService bookingService)
        {
            InitializeComponent();
            _roomService = roomService;
            _bookingService = bookingService;
            LoadReports();
        }

        private void LoadReports()
        {
            try
            {
                var totalRooms = _roomService.GetAllRooms().Count();
                TotalRooms.Text = totalRooms.ToString();

                var totalBookings = _bookingService.GetAllBookings().Count();
                TotalBookings.Text = totalBookings.ToString();

                var totalRevenue = _bookingService.GetAllBookings().Sum(b => (decimal?)b.TotalPrice) ?? 0m;
                TotalRevenue.Text = totalRevenue.ToString("C");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading reports: {ex.Message}");
            }
        }

        private void GenerateRoomChart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RoomChartCanvas.Children.Clear();
                var rooms = _roomService.GetAllRooms();
                DrawBarChart(RoomChartCanvas, rooms.Count(), "Rooms");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating room chart: {ex.Message}");
            }
        }

        private void GenerateBookingChart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BookingChartCanvas.Children.Clear();
                var bookings = _bookingService.GetAllBookings();
                DrawBarChart(BookingChartCanvas, bookings.Count(), "Bookings");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating booking chart: {ex.Message}");
            }
        }

        private void DrawBarChart(Canvas canvas, int count, string label)
        {
            try
            {
                const int barWidth = 50;
                const int spacing = 10;
                int maxHeight = 200;
                int barHeight = (int)((count / 10.0) * maxHeight);

                var rectangle = new Rectangle
                {
                    Width = barWidth,
                    Height = barHeight,
                    Fill = Brushes.Blue
                };
                Canvas.SetLeft(rectangle, spacing);
                Canvas.SetTop(rectangle, maxHeight - barHeight);
                canvas.Children.Add(rectangle);

                var text = new TextBlock
                {
                    Text = $"{label}: {count}",
                    Foreground = Brushes.Black
                };
                Canvas.SetLeft(text, spacing);
                Canvas.SetTop(text, maxHeight - barHeight - 20);
                canvas.Children.Add(text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error drawing chart: {ex.Message}");
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var adminViewModel = ServiceProvider.GetService<AdminViewModel>();
                if (adminViewModel != null)
                {
                    var adminView = new AdminView(adminViewModel);
                    adminView.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error returning to Admin: {ex.Message}");
            }
        }
    }
}