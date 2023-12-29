using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace TarkovHelper.Infrastructure.Middleware;

public static class Extensions
{
    public static IServiceCollection AddCustomExceptionHandler(this IServiceCollection services)
        => services.AddSingleton<ExceptionHandlerMiddleware>();
    public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        => builder.UseMiddleware<ExceptionHandlerMiddleware>();
}