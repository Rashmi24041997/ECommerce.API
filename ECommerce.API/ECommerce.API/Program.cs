using ECommerce.Infra;
using ECommerce.Core;
using Microsoft.AspNetCore.Builder;
using ECommerce.API.Middlewares;
using System.Text.Json.Serialization;
using ECommerce.Core.Mappers;

namespace ECommerce.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddInfrastructure();
            builder.Services.AddCore();
            builder.Services.AddControllers().AddJsonOptions
            (
                options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                }
            );
            builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);

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
