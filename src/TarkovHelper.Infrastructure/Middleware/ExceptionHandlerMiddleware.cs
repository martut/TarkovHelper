using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace TarkovHelper.Infrastructure.Middleware;

public class ExceptionHandlerMiddleware : IMiddleware
{
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;

    public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger)
    {
        _logger = logger;
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

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            await HandleExceptionAsync(context, ex);
        }
    }
}