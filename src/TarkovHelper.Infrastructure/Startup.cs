using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TarkovHelper.Infrastructure;

public static class Startup
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        return services.AddScoped<>()
    }
}