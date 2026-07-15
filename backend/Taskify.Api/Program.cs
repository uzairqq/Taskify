
using Microsoft.EntityFrameworkCore;
using Taskify.Api.Data;
using Taskify.Api.Repository.Implementation;
using Taskify.Api.Repository.Interfaces;
using Taskify.Api.Services.Implementation;
using Taskify.Api.Services.Interfaces;

namespace Taskify.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<ITaskItemService, TaskItemService>();
            builder.Services.AddScoped<ITaskItemRepository, TaskItemRepository>();

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
