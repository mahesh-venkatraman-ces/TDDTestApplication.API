using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TDDTestApplication.DataAccessLayer.Entities;

namespace TDDTestApplication.DataAccessLayer.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                 new User()
                 {
                     UserId = 1,
                     Name = "Test",
                     Password = "Test",
                     Surname = "Test",
                     Username = "Test"
                 }
             );
        }
    }
}
