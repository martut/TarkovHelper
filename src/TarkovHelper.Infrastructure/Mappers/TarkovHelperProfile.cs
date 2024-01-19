using AutoMapper;
using TarkovHelper.Application.DTO;
using TarkovHelper.Core.Models;

namespace TarkovHelper.Infrastructure.Mappers;

public class TarkovHelperProfile : Profile
{
    public TarkovHelperProfile()
    {
        CreateMap<Item, ItemDto>()
            .ForMember(i => i.ItemType, opt => opt.MapFrom(i => i.ItemType.ToString()));
        CreateMap<Quest, QuestDto>();
        CreateMap<RequiredItem, RequiredItemDto>();
        CreateMap<RequiredItemDto, RequiredItemCreateDto>()
            .ForMember(r => r.ItemId, opt => opt.MapFrom(i => i.Item.Id));
    }
}