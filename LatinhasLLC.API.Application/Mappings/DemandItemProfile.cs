using AutoMapper;
using LatinhasLLC.API.Application.DTOs;
using LatinhasLLC.API.Domain.Entities;

namespace LatinhasLLC.API.Application.Mappings;

public class DemandItemProfile : Profile
{
    public DemandItemProfile()
    {
        CreateMap<DemandItem, DemandItemDto>()
            .ForMember(dest => dest.ItemDescription, opt => opt.MapFrom(src => src.Item.Description))
            .ReverseMap()
            .ForPath(dest => dest.Item.Description, opt => opt.Ignore());
    }
}
