using Microsoft.Extensions.DependencyInjection;
using VoQuangDangKhoaWPF.ViewModels;
using System.Windows;

namespace VoQuangDangKhoaWPF.Views
{
    public partial class LoginView : Window
    {
        public LoginView(LoginViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}