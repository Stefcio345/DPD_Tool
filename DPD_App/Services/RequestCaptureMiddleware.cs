namespace DPD_App;

public class RequestCaptureMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestCaptureMiddleware> _logger;

    public RequestCaptureMiddleware(RequestDelegate next, ILogger<RequestCaptureMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Log request information
        var log =
            $"Incoming Request: {context.Request.Method} {context.Request.Path} from {context.Connection.RemoteIpAddress}\n";

        log = context.Request.Headers.Aggregate(log, (current, header) => current + $"Header: {header.Key} = {header.Value}\n");

        _logger.LogInformation(log);

        // Call the next middleware in the pipeline
        await _next(context);
        
        _logger.LogInformation("Response Status Code: {StatusCode}", context.Response.StatusCode);
    }
}