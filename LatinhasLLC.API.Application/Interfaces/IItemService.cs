using LatinhasLLC.API.Application.Models.Item.Requests;
using LatinhasLLC.API.Application.Models.Item.Responses;

namespace LatinhasLLC.API.Application.Interfaces;

public interface IItemService
{
    Task<List<ItemDto>> GetAllAsync();
    Task<ItemDto?> GetBySKUAsync(string sku);
    Task<ItemDto> CreateAsync(ItemRequest request);
    Task<bool> UpdateAsync(ItemRequest request);
    Task<bool> DeleteAsync(string sku);
}
