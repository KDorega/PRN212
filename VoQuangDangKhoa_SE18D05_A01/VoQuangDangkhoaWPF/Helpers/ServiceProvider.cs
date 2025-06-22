using Microsoft.Extensions.DependencyInjection;
using VoQuangDangKhoaBLL.Services;
using VoQuangDangKhoaDAL.Repositories;
using VoQuangDangKhoaWPF.ViewModels;

namespace VoQuangDangKhoaWPF.Helpers
{
    public static class ServiceProvider
    {
        private static readonly IServiceProvider _serviceProvider;

        static ServiceProvider()
        {
            var services = new ServiceCollection();

            // Register repositories
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();

            // Register services
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IRoomTypeService, RoomTypeService>();

            // Register ViewModels
            services.AddScoped<AdminViewModel>();
            services.AddScoped<LoginViewModel>();
            services.AddScoped<EditViewModel>();
            _serviceProvider = services.BuildServiceProvider();
        }

        public static T GetService<T>() => _serviceProvider.GetService<T>();
    }
}