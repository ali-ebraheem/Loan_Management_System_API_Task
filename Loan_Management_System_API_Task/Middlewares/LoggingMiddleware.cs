namespace Loan_Management_System_API_Task.Middlewares;

public class LoggingMiddleware(ILogger<LoggingMiddleware> logger, RequestDelegate next)
{
    public async Task Invoke(HttpContext context)
    {
        logger.LogInformation($"Request: {context.Request.Method} {context.Request.Path}");
        await next(context);
        logger.LogInformation($"Response: {context.Response.StatusCode}");
    }
}