using LatinhasLLC.API.Application.Models.DemandItem.Requests;
using LatinhasLLC.API.Application.Models.DemandItem.Responses;

namespace LatinhasLLC.API.Application.Interfaces;

public interface IDemandItemService
{
    Task<List<DemandItemDto>> GetAllAsync();
    Task<DemandItemDto?> GetByIdAsync(Guid id);
    Task<DemandItemDto> CreateAsync(DemandItemRequest request);
    Task<bool> UpdateAsync(Guid id, DemandItemRequest request);
    Task<bool> DeleteAsync(Guid id);
}
