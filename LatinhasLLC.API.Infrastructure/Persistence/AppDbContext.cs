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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Item>()
            .HasKey(p => p.SKU);

        modelBuilder.Entity<Item>()
            .HasOne(i => i.Demand)
            .WithMany(d => d.Items)
            .HasForeignKey(i => i.DemandId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
