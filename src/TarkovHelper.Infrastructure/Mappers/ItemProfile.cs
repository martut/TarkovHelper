using AutoMapper;
using TarkovHelper.Application.DTO;
using TarkovHelper.Core.Models;

namespace TarkovHelper.Infrastructure.Mappers;

public class ItemProfile : Profile
{
    public ItemProfile()
    {
        CreateMap<Item, ItemDto>()
            .ForMember(i => i.ItemType, opt => opt.MapFrom(i => i.ItemType.ToString()));
    }
}