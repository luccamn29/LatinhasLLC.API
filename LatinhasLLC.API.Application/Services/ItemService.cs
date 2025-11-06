using AutoMapper;
using LatinhasLLC.API.Application.DTOs;
using LatinhasLLC.API.Application.Interfaces;
using LatinhasLLC.API.Domain.Entities;

namespace LatinhasLLC.API.Application.Services;

public class ItemService : IItemService
{
    private readonly IItemRepository _repo;
    private readonly IMapper _mapper;

    public ItemService(IItemRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<List<ItemDto>> GetAllAsync()
    {
        var items = await _repo.GetAllAsync();
        return _mapper.Map<List<ItemDto>>(items);
    }

    public async Task<ItemDto?> GetBySKUAsync(string sku)
    {
        var item = await _repo.GetBySKUAsync(sku);
        return _mapper.Map<ItemDto?>(item);
    }

    public async Task<ItemDto> CreateAsync(ItemDto dto)
    {
        var entity = _mapper.Map<Item>(dto);
        await _repo.AddAsync(entity);
        return _mapper.Map<ItemDto>(entity);
    }

    public async Task<bool> UpdateAsync(string sku, ItemDto dto)
    {
        var existing = await _repo.GetBySKUAsync(sku);
        if (existing == null) return false;

        _mapper.Map(dto, existing);
        await _repo.UpdateAsync(existing);
        return true;
    }

    public async Task<bool> DeleteAsync(string sku)
    {
        var existing = await _repo.GetBySKUAsync(sku);
        if (existing == null) return false;

        await _repo.DeleteAsync(sku);
        return true;
    }
}
