using AutoMapper;
using LatinhasLLC.API.Application.DTOs;
using LatinhasLLC.API.Domain.Entities;

namespace LatinhasLLC.API.Application.Mappings;

public class DemandProfile : Profile
{
    public DemandProfile()
    {
        CreateMap<Demand, DemandDto>().ReverseMap();
    }
}
