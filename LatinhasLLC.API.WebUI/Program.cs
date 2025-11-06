using LatinhasLLC.API.Application.Interfaces;
using LatinhasLLC.API.Application.Mappings;
using LatinhasLLC.API.Application.Services;
using LatinhasLLC.API.Domain.Entities;
using LatinhasLLC.API.Infrastructure.Persistence;
using LatinhasLLC.API.Infrastructure.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(ItemProfile).Assembly);

var keepAliveConnection = new SqliteConnection("DataSource=:memory:");
keepAliveConnection.Open();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(keepAliveConnection)
);

builder.Services.AddScoped<IDemandRepository, DemandRepository>();
builder.Services.AddScoped<IDemandService, DemandService>();
builder.Services.AddScoped<IDemandItemRepository, DemandItemRepository>();
builder.Services.AddScoped<IDemandItemService, DemandItemService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:3000", "http://localhost:4000")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();

    if (!db.Demands.Any())
    {
        var items = new List<Item>
        {
            new() { SKU = "SKU001", Description = "Test Item 1" },
            new() { SKU = "SKU002", Description = "Test Item 2" },
            new() { SKU = "SKU003", Description = "Test Item 3" },
            new() { SKU = "SKU004", Description = "Test Item 4" },
            new() { SKU = "SKU005", Description = "Test Item 5" }
        };

        db.Items.AddRange(items);

        var demands = new List<Demand>
        {
            new()
            {
                StartDate = DateTime.UtcNow.AddDays(10),
                EndDate = DateTime.UtcNow.AddDays(17),
                Status = LatinhasLLC.API.Domain.Enums.DemandStatus.Planning,
                DemandItems = new List<DemandItem>()
            },
            new()
            {
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(7),
                Status = LatinhasLLC.API.Domain.Enums.DemandStatus.InProgress,
                DemandItems = new List<DemandItem>
                {
                    new() { SKU = "SKU001", TotalPlanned = 300, TotalProduced = 180 },
                    new() { SKU = "SKU002", TotalPlanned = 400, TotalProduced = 120 },
                    new() { SKU = "SKU005", TotalPlanned = 150, TotalProduced = 30 }
                }
            },
            new()
            {
                StartDate = DateTime.UtcNow.AddDays(-5),
                EndDate = DateTime.UtcNow.AddDays(2),
                Status = LatinhasLLC.API.Domain.Enums.DemandStatus.Completed,
                DemandItems = new List<DemandItem>
                {
                    new() { SKU = "SKU003", TotalPlanned = 200, TotalProduced = 200 },
                    new() { SKU = "SKU004", TotalPlanned = 100, TotalProduced = 100 },
                    new() { SKU = "SKU005", TotalPlanned = 250, TotalProduced = 250 }
                }
            },
            new()
            {
                StartDate = DateTime.UtcNow.AddDays(5),
                EndDate = DateTime.UtcNow.AddDays(12),
                Status = LatinhasLLC.API.Domain.Enums.DemandStatus.Planning,
                DemandItems = new List<DemandItem>
                {
                    new() { SKU = "SKU002", TotalPlanned = 200, TotalProduced = 0 },
                    new() { SKU = "SKU003", TotalPlanned = 250, TotalProduced = 0 },
                    new() { SKU = "SKU004", TotalPlanned = 50, TotalProduced = 0 }
                }
            }
        };

        db.Demands.AddRange(demands);

        db.SaveChanges();
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();
app.MapControllers();
app.Run();
