using AutoMapper;
using LatinhasLLC.API.Application.Interfaces;
using LatinhasLLC.API.Application.Models.DemandItem.Requests;
using LatinhasLLC.API.Application.Models.DemandItem.Responses;
using LatinhasLLC.API.Domain.Entities;

namespace LatinhasLLC.API.Application.Services;

public class DemandItemService : IDemandItemService
{
    private readonly IDemandItemRepository _repo;
    private readonly IMapper _mapper;

    public DemandItemService(IDemandItemRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<List<DemandItemDto>> GetAllAsync()
    {
        var demandItems = await _repo.GetAllAsync();
        return _mapper.Map<List<DemandItemDto>>(demandItems);
    }

    public async Task<DemandItemDto?> GetByIdAsync(Guid id)
    {
        var demandItem = await _repo.GetByIdAsync(id);
        return _mapper.Map<DemandItemDto?>(demandItem);
    }

    public async Task<DemandItemDto> CreateAsync(DemandItemRequest request)
    {
        var entity = _mapper.Map<DemandItem>(request);
        await _repo.AddAsync(entity);
        return _mapper.Map<DemandItemDto>(entity);
    }

    public async Task<bool> UpdateAsync(Guid id, DemandItemRequest request)
    {
        var existing = await _repo.GetByIdAsync(id);
        if (existing == null) return false;

        _mapper.Map(request, existing);
        await _repo.UpdateAsync(existing);
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var existing = await _repo.GetByIdAsync(id);
        if (existing == null) return false;

        await _repo.DeleteAsync(id);
        return true;
    }
}
