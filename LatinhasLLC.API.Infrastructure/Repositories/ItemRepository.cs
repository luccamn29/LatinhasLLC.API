using LatinhasLLC.API.Application.Interfaces;
using LatinhasLLC.API.Domain.Entities;
using LatinhasLLC.API.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LatinhasLLC.API.Infrastructure.Repositories;

public class ItemRepository : IItemRepository
{
    private readonly AppDbContext _context;

    public ItemRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Item>> GetAllAsync()
    {
        return await _context.Items
            .OrderBy(x => x.SKU)
            .ToListAsync();
    }

    public async Task<Item?> GetBySKUAsync(string sku)
    {
        return await _context.Items
            .FirstOrDefaultAsync(d => d.SKU == sku);
    }

    public async Task AddAsync(Item item)
    {
        _context.Items.Add(item);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Item item)
    {
        _context.Items.Update(item);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(string sku)
    {
        var entity = await _context.Items.FindAsync(sku);
        if (entity is not null)
        {
            _context.Items.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
