
using System.Reflection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using soul_whisper.Models.Public;

namespace soul_whisper.Middlewares;


public class GlobalErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalErrorHandlerMiddleware(RequestDelegate next)
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
            // Xử lý ngoại lệ ở đây
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        int statusCode;
        string errorMessage = exception.Message != "" ? exception.Message : "Something wrong!"; // Có thể thay đổi tùy vào loại ngoại lệ
        switch (exception)
        {
            case UnauthorizedAccessException _:
                statusCode = StatusCodes.Status401Unauthorized;
                break;
            case InvalidOperationException _:
                statusCode = StatusCodes.Status403Forbidden;
                break;
            case SecurityTokenInvalidLifetimeException _:
                statusCode = StatusCodes.Status401Unauthorized;
                break;
            case ArgumentException _:
                statusCode = StatusCodes.Status403Forbidden;
                break;
            case TargetException _:
             statusCode = StatusCodes.Status404NotFound;
                break;
            default:
                statusCode = 500;
                break;

        }

        // Kiểm tra ngoại lệ và cập nhật thông báo lỗi cụ thể nếu cần thiết

        var response = new ContainMessageResponseDTO
        {
            message = errorMessage
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;

        await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
    }
}
