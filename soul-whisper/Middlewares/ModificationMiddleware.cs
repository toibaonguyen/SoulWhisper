
using soul_whisper.Data;
using soul_whisper.Helpers;

namespace soul_whisper.Middlewares;


public class GlobalModifierMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalModifierMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {

      
        // Xử lý trước khi gửi yêu cầu đến middleware tiếp theo
        // Console.WriteLine("-----------Middleware đang xử lý trước khi gửi yêu cầu đến middleware tiếp theo.");
        // var DB= new FlatformContext();
        // await   DB.CreateDatabase();
        TokenOperator.RemoveExpiredTokens();
        // Gọi middleware tiếp theo trong pipeline
        await _next(context);

        // Xử lý sau khi nhận phản hồi từ middleware tiếp theo
        // Console.WriteLine("-------------Middleware đang xử lý sau khi nhận phản hồi từ middleware tiếp theo.");
    }
}
