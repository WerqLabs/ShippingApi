
namespace ShippingApiApp.Extensions
{
    public static class DataManagerServiceCollection
    {
        public static IServiceCollection AddDataManagers(this IServiceCollection services)
        {
            services.AddScoped<IDBManager>(AddDBManager);
            services.AddScoped<IShipRepository, ShipRepository>();
            services.AddScoped<IShipBAL, ShipBAL>();
            return services;
        }

        internal static IDBManager AddDBManager(IServiceProvider serviceProvider)
        {
            IConfiguration Configuration = serviceProvider.GetRequiredService<IConfiguration>();

            string dbconstr = Configuration.GetConnectionString("DBConnectionString");
            return new DBManagerFactory().GetDBManager(dbconstr);
        }

        internal static IServiceCollection AddAppsettings(this IServiceCollection services, IConfiguration configuration)
        {
            EnvironmentVariableTarget target = EnvironmentVariableTarget.Process;

            string APIKey = configuration["APIKey"];
            Environment.SetEnvironmentVariable("APIKey", APIKey, target);

            return services;
        }
    }
}
