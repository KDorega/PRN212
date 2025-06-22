using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using VoQuangDangKhoaBLL.Services;
using VoQuangDangKhoaDAL.Repositories;
using VoQuangDangKhoaWPF.ViewModels;
using VoQuangDangKhoaWPF.Views;

namespace VoQuangDangKhoaWPF
{
    public partial class App : Application
    {
        private ServiceProvider _serviceProvider;

        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ICustomerRepository, CustomerRepository>();
            services.AddSingleton<ICustomerService, CustomerService>();
            services.AddSingleton<LoginViewModel>();
            services.AddSingleton<LoginView>();
            // Add other services if needed
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var loginView = _serviceProvider.GetService<LoginView>();
            if (loginView != null)
            {
                loginView.DataContext = _serviceProvider.GetService<LoginViewModel>();
                loginView.Show();
            }
            else
            {
                throw new InvalidOperationException("Failed to resolve LoginView.");
            }
        }
    }
}
