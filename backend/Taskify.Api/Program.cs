using Taskify.Api.Data;
using Microsoft.EntityFrameworkCore;
using Taskify.Api.Models;
using Taskify.Api.Repositories.Implementation;
using Taskify.Api.Repositories.Interfaces;
using Taskify.Api.Services.Implementation;
using Taskify.Api.Services.Interfaces;
using Taskify.Api.Controllers;



namespace Taskify.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // 1. Add Controllers Service (Missing previously)
        builder.Services.AddControllers();

        // 2. Add Swagger/OpenAPI (Corrected case-sensitivity)
        builder.Services.AddOpenApi();

        // 3. Add DbContext Service
        builder.Services.AddDbContext<ApplicationDbContext>(options => 
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        // 4. Register Application Services
        builder.Services.AddScoped<ITaskItemRepository, TaskItemRepository>();
        builder.Services.AddScoped<ITaskItemService, TaskItemService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
           app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        // 4. Map Controllers endpoints (Missing previously)
        app.MapControllers();

        app.Run();
    }
}
