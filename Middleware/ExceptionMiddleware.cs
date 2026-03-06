using Microsoft.AspNetCore.Http.HttpResults;
using System.Text.Json;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            context.Response.ContentType = "application/json";
            if(ex is ArgumentException)
            {
                context.Response.StatusCode = 400;
            }
            else if (ex is KeyNotFoundException)
            {
                context.Response.StatusCode = 404;
            }
            else if (ex is InvalidOperationException)
            {
                context.Response.StatusCode = 409;
            }
            else
            {
                context.Response.StatusCode = 500;
            }
            await context.Response.WriteAsync(JsonSerializer.Serialize(new
            {
                error = ex.Message
            }));
        }
    }
}