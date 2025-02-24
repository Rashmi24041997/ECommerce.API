using ECommerce.Infra;
using ECommerce.Core;
using Microsoft.AspNetCore.Builder;
using ECommerce.API.Middlewares;
using System.Text.Json.Serialization;
using ECommerce.Core.Mappers;
using FluentValidation.AspNetCore;

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

            builder.Services.AddFluentValidationAutoValidation();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("http://localhost:4200").AllowAnyMethod();
                });
            });

            var app = builder.Build();

            app.UseMiddleware<ExceptionHandlerMiddleware>();

            app.UseRouting();

            app.UseSwagger(); //adds endpoints that can serve the swagger.json
            app.UseSwaggerUI();//adds swagger ui 

            app.UseCors();

            //auth
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
            app.Run();
        }
    }
}
