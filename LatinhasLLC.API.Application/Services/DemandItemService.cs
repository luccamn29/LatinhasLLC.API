using AutoMapper;
using LatinhasLLC.API.Application.DTOs;
using LatinhasLLC.API.Application.Interfaces;
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

    public async Task<DemandItemDto> CreateAsync(DemandItemDto dto)
    {
        if (dto.TotalPlanned < 0)
            throw new InvalidOperationException("A quantidade planejada não pode ser negativa.");

        if (dto.TotalProduced < 0)
            throw new InvalidOperationException("A quantidade produzida não pode ser negativa.");

        var entity = _mapper.Map<DemandItem>(dto);
        await _repo.AddAsync(entity);
        return _mapper.Map<DemandItemDto>(entity);
    }

    public async Task<bool> UpdateAsync(Guid id, DemandItemDto dto)
    {
        if (dto.TotalPlanned < 0)
            throw new InvalidOperationException("A quantidade planejada não pode ser negativa.");

        if (dto.TotalProduced < 0)
            throw new InvalidOperationException("A quantidade produzida não pode ser negativa.");

        var existing = await _repo.GetByIdAsync(id);
        if (existing == null) return false;

        _mapper.Map(dto, existing);
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
