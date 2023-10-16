using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TDDTestApplication.DataAccessLayer.DataContext;
using TDDTestApplication.DataAccessLayer.Entities;
using TDDTestApplication.DataAccessLayer.Repositories;
using TDDTestApplication.DataAccessLayer.Repositories.Interfaces;

namespace TDDTestApplication.DataAccessLayer
{
    public static class DependencyInjection
    {
        public static void RegisterDALDependencies(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IGenericRepository<User>, GenericRepository<User>>();
        }
    }
}
