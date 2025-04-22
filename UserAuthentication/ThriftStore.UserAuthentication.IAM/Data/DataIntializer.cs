using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ThriftStore.UserAuthentication.IAM.Data.Entities;
using ThriftStore.UserAuthentication.IAM.Enums;

namespace ThriftStore.UserAuthentication.IAM.Data
{
    public static class DataInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {

                if (context.Users.Any())
                {
                    return;
                }

                var user = new Users
                {
                    Name = "Admin User",
                    Password = "Riyajain@1257", 
                    Email = "riya.jain@thriftstore.com",
                    Username = "admin",
                    IsPrime = "true",
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "System",
                    UpdatedAt = DateTime.UtcNow,
                    UpdatedBy = "System",
                    Status = Status.Active
                };

                context.Users.Add(user);
                context.SaveChanges(); 
            }
        }
    }
}
