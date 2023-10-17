using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TDDTestApplication.BusinessLayer.Services;
using TDDTestApplication.BusinessLayer.Services.Interfaces;
using TDDTestApplication.BusinessLayer.Utilities.AutomapperProfiles;

namespace TDDTestApplication.BusinessLayer;

public static class DependencyInjection
{
    public static void RegisterBLLDependencies(this IServiceCollection services, IConfiguration Configuration)
    {
        services.AddAutoMapper(typeof(AutoMapperProfiles));
        services.AddScoped<IUserService, UserService>();
        DataAccessLayer.DependencyInjection.RegisterDALDependencies(services, Configuration);
    }
}