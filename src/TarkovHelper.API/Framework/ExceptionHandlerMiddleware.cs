using System.Net;

namespace TarkovHelper.API.Framework;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var errorCode = "error";
        var statusCode = HttpStatusCode.BadRequest;
        var exceptionType = exception.GetType();
        switch (exception)
        {
            case Exception e when exceptionType == typeof(UnauthorizedAccessException):
                statusCode = HttpStatusCode.Unauthorized;
                break;
        }

        var response = new { code = errorCode, message = exception.Message };
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        return context.Response.WriteAsJsonAsync(response);
    }
}