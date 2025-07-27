using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BusinessObjects.Models;

namespace HuynhPhucTanWPF
{
    public partial class RoomPopup : Window
    {
        public RoomInformation RoomData { get; private set; }
        private readonly bool isUpdateMode;

        public RoomPopup(RoomInformation? room = null)
        {
            InitializeComponent();

            if (room != null)
            {
                isUpdateMode = true;
                RoomData = room;
                txtRoomNumber.Text = room.RoomNumber;
                txtDescription.Text = room.RoomDetailDescription;
                txtCapacity.Text = room.RoomMaxCapacity?.ToString();
                txtPrice.Text = room.RoomPricePerDay?.ToString();
                txtRoomTypeId.Text = room.RoomTypeId.ToString();
                txtStatus.Text = room.RoomStatus?.ToString() ?? "1";
            }
            else
            {
                RoomData = new RoomInformation();
                txtStatus.Text = "1";
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRoomNumber.Text) ||
                string.IsNullOrWhiteSpace(txtCapacity.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text) ||
                string.IsNullOrWhiteSpace(txtRoomTypeId.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            RoomData.RoomNumber = txtRoomNumber.Text.Trim();
            RoomData.RoomDetailDescription = txtDescription.Text.Trim();

            if (int.TryParse(txtCapacity.Text, out int capacity))
                RoomData.RoomMaxCapacity = capacity;

            if (decimal.TryParse(txtPrice.Text, out decimal price))
                RoomData.RoomPricePerDay = price;

            if (int.TryParse(txtRoomTypeId.Text, out int typeId))
                RoomData.RoomTypeId = typeId;

            if (byte.TryParse(txtStatus.Text, out byte status))
                RoomData.RoomStatus = status;

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