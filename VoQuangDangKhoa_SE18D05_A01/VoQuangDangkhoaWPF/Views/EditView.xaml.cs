using VoQuangDangKhoaWPF.ViewModels;
using System.Windows;

namespace VoQuangDangKhoaWPF.Views
{
    public partial class EditView : Window
    {
        private readonly EditViewModel _viewModel;

        public EditView(EditViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;
            TitleText.Text = _viewModel.Title;
            SetupFields();
        }

        private void SetupFields()
        {
            Field1.Text = _viewModel.Field1;
            Field2.Text = _viewModel.Field2;
            Field3.Text = _viewModel.Field3;
            Field4.Text = _viewModel.Field4;
            Field5.Text = _viewModel.Field5;

            Field1.Visibility = _viewModel.IsField1Visible ? Visibility.Visible : Visibility.Collapsed;
            Field2.Visibility = _viewModel.IsField2Visible ? Visibility.Visible : Visibility.Collapsed;
            Field3.Visibility = _viewModel.IsField3Visible ? Visibility.Visible : Visibility.Collapsed;
            Field4.Visibility = _viewModel.IsField4Visible ? Visibility.Visible : Visibility.Collapsed;
            Field5.Visibility = _viewModel.IsField5Visible ? Visibility.Visible : Visibility.Collapsed;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Save();
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}