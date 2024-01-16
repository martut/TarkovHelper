using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TarkovHelper.Infrastructure.DAL;
using TarkovHelper.Infrastructure.IoC;
using TarkovHelper.Infrastructure.Middleware;

namespace TarkovHelper.Infrastructure;

public static class Startup
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        var assembly = Assembly.GetExecutingAssembly();
        return services
            .AddDbContext<ApplicationDbContext>(
                options => options.UseSqlite(
                    config.GetConnectionString("ApplicationDBConnectionString")
                )
            )
            .AddCustomExceptionHandler()
            .AddServices()
            .AddAutoMapper(assembly)
            .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
    }
}