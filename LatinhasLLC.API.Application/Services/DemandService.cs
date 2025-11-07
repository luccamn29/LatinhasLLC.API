using AutoMapper;
using LatinhasLLC.API.Application.Interfaces;
using LatinhasLLC.API.Application.Models.Demand.Requests;
using LatinhasLLC.API.Application.Models.Demand.Responses;
using LatinhasLLC.API.Domain.Entities;

namespace LatinhasLLC.API.Application.Services;

public class DemandService : IDemandService
{
    private readonly IDemandRepository _repo;
    private readonly IMapper _mapper;

    public DemandService(IDemandRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<List<DemandDto>> GetAllAsync()
    {
        var demands = await _repo.GetAllAsync();
        return _mapper.Map<List<DemandDto>>(demands);
    }

    public async Task<DemandDto?> GetByIdAsync(Guid id)
    {
        var demand = await _repo.GetByIdAsync(id);
        return _mapper.Map<DemandDto?>(demand);
    }

    public async Task<DemandDto> CreateAsync(DemandRequest request)
    {
        var entity = _mapper.Map<Demand>(request);
        await _repo.AddAsync(entity);
        return _mapper.Map<DemandDto>(entity);
    }

    public async Task<bool> UpdateAsync(Guid id, DemandRequest request)
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
