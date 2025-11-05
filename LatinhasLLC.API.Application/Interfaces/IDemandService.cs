using LatinhasLLC.API.Application.DTOs;

namespace LatinhasLLC.API.Application.Interfaces;

public interface IDemandService
{
    Task<List<DemandDto>> GetAllAsync();
    Task<DemandDto?> GetByIdAsync(Guid id);
    Task<DemandDto> CreateAsync(DemandDto dto);
    Task<bool> UpdateAsync(Guid id, DemandDto dto);
    Task<bool> DeleteAsync(Guid id);
}
