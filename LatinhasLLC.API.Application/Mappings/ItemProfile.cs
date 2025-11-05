using AutoMapper;
using LatinhasLLC.API.Application.DTOs;
using LatinhasLLC.API.Domain.Entities;

namespace LatinhasLLC.API.Application.Mappings;

public class ItemProfile : Profile
{
    public ItemProfile()
    {
        CreateMap<Item, ItemDto>().ReverseMap();
    }
}
