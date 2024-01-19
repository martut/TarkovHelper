using AutoMapper;
using TarkovHelper.Application.DTO;
using TarkovHelper.Application.Exceptions;
using TarkovHelper.Application.Services.Interfaces;
using TarkovHelper.Core.Models;
using TarkovHelper.Core.Repositories;

namespace TarkovHelper.Application.Services;

public class RequiredItemService(
    IItemRepository itemRepository,
    IRequiredItemRepository requiredItemRepository,
    IMapper mapper) : IRequiredItemService
{
    public async Task<RequiredItem> Create(RequiredItemCreateDto reqItemDto)
    {
        var reqItem = RequiredItem.Create(reqItemDto.IsFoundInRaid, reqItemDto.Count);
        var item = await itemRepository.GetById(reqItemDto.ItemId);
        if (item == null)
        {
            throw new ServiceException(ErrorCodes.ItemNotFound,
                $"Item with id: '{reqItemDto.ItemId}' was not found.");
        }

        reqItem.SetItem(item);

        return reqItem;
    }

    public Task<RequiredItem> Create(RequiredItemDto reqItemDto)
    {
        var reqItem = mapper.Map<RequiredItemCreateDto>(reqItemDto);
        return Create(reqItem);
    }

    public async Task Delete(RequiredItem requiredItem)
    {
        await requiredItemRepository.Delete(requiredItem);
    }
}