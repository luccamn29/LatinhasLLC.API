using AutoMapper;
using LatinhasLLC.API.Application.Models.Item.Requests;
using LatinhasLLC.API.Application.Models.Item.Responses;
using LatinhasLLC.API.Domain.Entities;

namespace LatinhasLLC.API.Application.Mappings;

public class ItemProfile : Profile
{
    public ItemProfile()
    {
        CreateMap<Item, ItemDto>();
        CreateMap<ItemRequest, Item>();
    }
}
