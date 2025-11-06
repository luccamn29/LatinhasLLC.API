using LatinhasLLC.API.Application.DTOs;

namespace LatinhasLLC.API.Application.Interfaces;

public interface IItemService
{
    Task<List<ItemDto>> GetAllAsync();
    Task<ItemDto?> GetBySKUAsync(string sku);
    Task<ItemDto> CreateAsync(ItemDto dto);
    Task<bool> UpdateAsync(string sku, ItemDto dto);
    Task<bool> DeleteAsync(string sku);
}
