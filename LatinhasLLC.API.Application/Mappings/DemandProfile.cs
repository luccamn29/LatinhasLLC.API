using AutoMapper;
using LatinhasLLC.API.Application.Models.Demand.Requests;
using LatinhasLLC.API.Application.Models.Demand.Responses;
using LatinhasLLC.API.Domain.Entities;

namespace LatinhasLLC.API.Application.Mappings;

public class DemandProfile : Profile
{
    public DemandProfile()
    {
        CreateMap<Demand, DemandDto>();
        CreateMap<DemandRequest, Demand>();
    }
}
