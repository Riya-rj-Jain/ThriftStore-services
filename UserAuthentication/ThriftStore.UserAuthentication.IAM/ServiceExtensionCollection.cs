using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ThriftStore.UserAuthentication.IAM.Data;

namespace ThriftStore.UserAuthentication.IAM
{
    public static class ServiceExtensionCollection
    {
        public static IServiceCollection UserAssistServices(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            var customDbConnectionString = configuration.GetConnectionString("Mysql");

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseMySql(
                    customDbConnectionString,
                    ServerVersion.AutoDetect(customDbConnectionString),
                    mysqlOptions =>
                    {
                        mysqlOptions.EnableRetryOnFailure(
                            int.Parse(configuration["DbConnRetryCounts"] ?? "3"));
                    });

            });

            return services;
        }
    }
}
