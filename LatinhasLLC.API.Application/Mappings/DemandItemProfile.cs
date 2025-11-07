using AutoMapper;
using LatinhasLLC.API.Application.Models.DemandItem.Requests;
using LatinhasLLC.API.Application.Models.DemandItem.Responses;
using LatinhasLLC.API.Domain.Entities;

namespace LatinhasLLC.API.Application.Mappings;

public class DemandItemProfile : Profile
{
    public DemandItemProfile()
    {
        CreateMap<DemandItem, DemandItemDto>()
            .ForMember(dest => dest.ItemDescription, opt => opt.MapFrom(src => src.Item.Description));

        CreateMap<DemandItemRequest, DemandItem>();
    }
}
