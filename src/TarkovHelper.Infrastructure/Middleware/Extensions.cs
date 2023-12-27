using Microsoft.AspNetCore.Builder;

namespace TarkovHelper.Infrastructure.Middleware;

public static class Extensions
{
    public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware(typeof(ExceptionHandlerMiddleware));
    }
}