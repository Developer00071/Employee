namespace WebApi.Middlewares;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _request;
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    public RequestLoggingMiddleware(
        RequestDelegate request,
        ILogger<RequestLoggingMiddleware> logger)
    {
        _request = request;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        _logger.LogInformation(
            "HTTP {Method} {Path} started.",
            context.Request.Method,
            context.Request.Path);

        await _request(context);

        _logger.LogInformation(
            "HTTP {Method} {Path} responded with {StatusCode}.",
            context.Request.Method,
            context.Request.Path,
            context.Response.StatusCode);
    }
}

