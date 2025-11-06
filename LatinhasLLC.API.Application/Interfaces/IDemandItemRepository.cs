using LatinhasLLC.API.Domain.Entities;

namespace LatinhasLLC.API.Application.Interfaces;

public interface IDemandItemRepository
{
    Task<List<DemandItem>> GetAllAsync();
    Task<DemandItem?> GetByIdAsync(Guid id);
    Task AddAsync(DemandItem demandItem);
    Task UpdateAsync(DemandItem demandItem);
    Task DeleteAsync(Guid id);
}
