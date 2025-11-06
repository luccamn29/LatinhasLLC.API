using LatinhasLLC.API.Domain.Entities;

namespace LatinhasLLC.API.Application.Interfaces;

public interface IItemRepository
{
    Task<List<Item>> GetAllAsync();
    Task<Item?> GetBySKUAsync(string sku);
    Task AddAsync(Item item);
    Task UpdateAsync(Item item);
    Task DeleteAsync(string sku);
}
