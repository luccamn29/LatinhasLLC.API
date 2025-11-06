using LatinhasLLC.API.Application.DTOs;

namespace LatinhasLLC.API.Application.Interfaces;

public interface IDemandItemService
{
    Task<List<DemandItemDto>> GetAllAsync();
    Task<DemandItemDto?> GetByIdAsync(Guid id);
    Task<DemandItemDto> CreateAsync(DemandItemDto dto);
    Task<bool> UpdateAsync(Guid id, DemandItemDto dto);
    Task<bool> DeleteAsync(Guid id);
}
