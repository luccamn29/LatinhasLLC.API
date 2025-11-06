using LatinhasLLC.API.Application.Interfaces;
using LatinhasLLC.API.Domain.Entities;
using LatinhasLLC.API.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LatinhasLLC.API.Infrastructure.Repositories;

public class DemandItemRepository : IDemandItemRepository
{
    private readonly AppDbContext _context;

    public DemandItemRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<DemandItem>> GetAllAsync()
    {
        return await _context.DemandItems
            .Include(x => x.Item)
            .OrderBy(x => x.SKU)
            .ToListAsync();
    }

    public async Task<DemandItem?> GetByIdAsync(Guid id)
    {
        return await _context.DemandItems
            .FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task AddAsync(DemandItem demandItem)
    {
        _context.DemandItems.Add(demandItem);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(DemandItem demandItem)
    {
        _context.DemandItems.Update(demandItem);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _context.DemandItems.FindAsync(id);
        if (entity is not null)
        {
            _context.DemandItems.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
