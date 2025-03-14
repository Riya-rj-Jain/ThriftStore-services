using Microsoft.EntityFrameworkCore;
using ThriftStore.UserAuthentication.IAM.Data.Entities;


namespace ThriftStore.UserAuthentication.IAM.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
              .HasIndex(u => u.Email)
              .IsUnique();
            base.OnModelCreating(modelBuilder);
        }
    }
}
