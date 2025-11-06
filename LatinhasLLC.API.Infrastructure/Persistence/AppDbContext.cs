using LatinhasLLC.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LatinhasLLC.API.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Item> Items => Set<Item>();
    public DbSet<Demand> Demands => Set<Demand>();
    public DbSet<DemandItem> DemandItems => Set<DemandItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<DemandItem>()
            .HasOne(di => di.Demand)
            .WithMany(d => d.DemandItems)
            .HasForeignKey(di => di.DemandId);

        modelBuilder.Entity<DemandItem>()
            .HasOne(di => di.Item)
            .WithMany()
            .HasForeignKey(di => di.SKU);
    }
}
