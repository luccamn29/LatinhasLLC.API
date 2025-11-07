using LatinhasLLC.API.Application.Models.Demand.Requests;
using LatinhasLLC.API.Application.Models.Demand.Responses;

namespace LatinhasLLC.API.Application.Interfaces;

public interface IDemandService
{
    Task<List<DemandDto>> GetAllAsync();
    Task<DemandDto?> GetByIdAsync(Guid id);
    Task<DemandDto> CreateAsync(DemandRequest request);
    Task<bool> UpdateAsync(Guid id, DemandRequest request);
    Task<bool> DeleteAsync(Guid id);
}
