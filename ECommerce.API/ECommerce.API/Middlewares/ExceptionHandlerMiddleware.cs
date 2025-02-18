using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;

namespace ECommerce.API.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                logger.LogError(JsonSerializer.Serialize(new
                {
                    Message = ex.Message,
                    Type = ex.GetType().ToString(),
                    StackTrace = ex.StackTrace
                }, new JsonSerializerOptions { WriteIndented = true }));
                if (ex.InnerException is not null)
                {
                    logger.LogError($"{ex.InnerException.GetType().Name}:{ex.InnerException.Message}");
                    httpContext.Response.StatusCode = 500;
                    await httpContext.Response.WriteAsJsonAsync(new
                    {
                        Message = ex.Message,
                        Type = ex.InnerException.GetType().ToString(),
                        StackTrace = ex.StackTrace
                    });
                }
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
