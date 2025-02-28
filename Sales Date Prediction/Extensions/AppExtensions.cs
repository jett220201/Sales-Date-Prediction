using Microsoft.EntityFrameworkCore;
using SalesDatePrediction_Application.Interfaces;
using SalesDatePrediction_Infraestructure.Repository;
using SalesDatePrediction_Infraestructure.Persistence;
using SalesDatePrediction_Application.Services;
namespace Sales_Date_Prediction.Extensions
{
    public static class AppExtensions
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // Repositories
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderDetailsRepository, OrderDetailsRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IShipperRepository, ShipperRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            // Services
            services.AddScoped<CategoryService>();
            services.AddScoped<CustomerService>();
            services.AddScoped<EmployeeService>();
            services.AddScoped<OrderService>();
            services.AddScoped<OrderDetailService>();
            services.AddScoped<ProductService>();
            services.AddScoped<ShipperService>();
            services.AddScoped<SupplierService>();
        }

        public static void RegisterDataSource(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = Environment.GetEnvironmentVariable("DATABASE_URL") ?? configuration.GetConnectionString("salesDatePredictionConnection");
            services.AddDbContextFactory<CoreDBContext>(opt => opt.UseSqlServer(connectionString));
        }
    }
}
