using System.Net;
using Newtonsoft.Json;

namespace ProgramApplication;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;

    public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            await HandleExceptionMessageAsync(context, ex).ConfigureAwait(false);
        }
    }

    private static Task HandleExceptionMessageAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        int statusCode = (int)HttpStatusCode.InternalServerError;
        var result = JsonConvert.SerializeObject(new StandardResponse<dynamic>()
        {
            StatusCode = (HttpStatusCode)statusCode,
            Message = exception.Message
        });
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;
        return context.Response.WriteAsync(result);
    }
}

public static class ExceptionHandlerMiddlewareExtensions
{
    public static void UseExceptionHandlerMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}
