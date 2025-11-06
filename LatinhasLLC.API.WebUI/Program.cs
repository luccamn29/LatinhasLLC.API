using LatinhasLLC.API.Application.Interfaces;
using LatinhasLLC.API.Application.Mappings;
using LatinhasLLC.API.Application.Services;
using LatinhasLLC.API.Infrastructure.Persistence;
using LatinhasLLC.API.Infrastructure.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(ItemProfile).Assembly);

// Criar conexão em memória e mantê-la aberta
var keepAliveConnection = new SqliteConnection("DataSource=:memory:");
keepAliveConnection.Open();

// Registrar DbContext usando essa conexão
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(keepAliveConnection)
);

builder.Services.AddScoped<IDemandRepository, DemandRepository>();
builder.Services.AddScoped<IDemandService, DemandService>();

// Adicionar controllers e Swagger
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

// Criar as tabelas no banco em memória
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();

    // Opcional: inserir seed inicial
    if (!db.Demands.Any())
    {
        db.Demands.Add(new LatinhasLLC.API.Domain.Entities.Demand
        {
            StartDate = DateTime.UtcNow,
            EndDate = DateTime.UtcNow.AddDays(7),
            Status = LatinhasLLC.API.Domain.Enums.DemandStatus.Planning,
            Items = new List<LatinhasLLC.API.Domain.Entities.Item>
            {
                new() { SKU = "SKU001", Description = "Test Item", TotalPlan = 500 }
            }
        });
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
