using Microsoft.EntityFrameworkCore;
using TDDTestApplication.DataAccessLayer.Entities;

namespace TDDTestApplication.DataAccessLayer.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                 new User()
             );
        }
    }
}
