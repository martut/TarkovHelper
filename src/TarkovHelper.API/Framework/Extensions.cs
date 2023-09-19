namespace TarkovHelper.API.Framework;

public static class Extensions
{
    public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware(typeof(ExceptionHandlerMiddleware));
    }
}