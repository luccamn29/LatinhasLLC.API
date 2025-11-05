using LatinhasLLC.API.Domain.Entities;

namespace LatinhasLLC.API.Application.Interfaces;

public interface IDemandRepository
{
    Task<List<Demand>> GetAllAsync();
    Task<Demand?> GetByIdAsync(Guid id);
    Task AddAsync(Demand demand);
    Task UpdateAsync(Demand demand);
    Task DeleteAsync(Guid id);
}
