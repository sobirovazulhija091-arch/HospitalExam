public class RequestTimeMiddleware(RequestDelegate next,ILogger<RequestTimeMiddleware> logger)
{
     private RequestDelegate _next=next; 
     private ILogger<RequestTimeMiddleware> _logger=logger;
     public async Task InvokeAsync(HttpContext context)
    {
        _logger.LogInformation
        (
          "income request: {Methot} {Paht}",
            context.Request.Method,
            context.Request.Path
        );
        var start = DateTime.Now;
        try
        {
            await _next(context);
        }
        catch (System.Exception ex)
        {
             _logger.LogError(ex.Message,"Error");
        }
        var end = DateTime.Now;
        _logger.LogInformation("Successfully");
        Console.WriteLine($"request taked{(end-start).TotalMicroseconds} ms");
    }
}
