using LatinhasLLC.API.Application.Interfaces;
using LatinhasLLC.API.Domain.Entities;
using LatinhasLLC.API.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LatinhasLLC.API.Infrastructure.Repositories;

public class DemandRepository : IDemandRepository
{
    private readonly AppDbContext _context;

    public DemandRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Demand>> GetAllAsync()
    {
        return await _context.Demands.Include(d => d.Items).ToListAsync();
    }

    public async Task<Demand?> GetByIdAsync(Guid id)
    {
        return await _context.Demands
            .Include(d => d.Items)
            .FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task AddAsync(Demand demand)
    {
        _context.Demands.Add(demand);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Demand demand)
    {
        _context.Demands.Update(demand);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _context.Demands.FindAsync(id);
        if (entity is not null)
        {
            _context.Demands.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
