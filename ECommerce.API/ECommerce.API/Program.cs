using ECommerce.Infra;
using ECommerce.Core;
using Microsoft.AspNetCore.Builder;
using ECommerce.API.Middlewares;

namespace ECommerce.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddInfrastructure();
            builder.Services.AddCore();
            builder.Services.AddControllers();

            var app = builder.Build();

            app.UseMiddleware<ExceptionHandlerMiddleware>();
            
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();   
            app.Run();
        }
    }
}
