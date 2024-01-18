using AutoMapper;
using TarkovHelper.Application.DTO;
using TarkovHelper.Application.Exceptions;
using TarkovHelper.Application.Extension;
using TarkovHelper.Application.Services.Interfaces;
using TarkovHelper.Core.Models;
using TarkovHelper.Core.Models.Enums;
using TarkovHelper.Core.Repositories;

namespace TarkovHelper.Application.Services;

public class ItemService(IItemRepository itemRepository, IMapper mapper) : IItemService
{
    public async Task<ItemDto?> GetById(int id)
    {
        var item = await itemRepository.GetById(id);

        return item == null ? null : mapper.Map<ItemDto>(item);
    }

    public async Task<IEnumerable<ItemDto>> GetAll()
    {
        var items = await itemRepository.GetAll();

        return mapper.Map<IEnumerable<ItemDto>>(items);
    }

    public async Task<int> Create(ItemCreateDto itemDto)
    {
        var itemType = EnumExtension.Parse<ItemType>(itemDto.ItemType, ErrorCodes.ItemTypeNotFound);
        var item = new Item(itemDto.Name, itemDto.ShortName, itemType);

        await itemRepository.Create(item);
        await itemRepository.Save();
        return item.Id;
    }

    public async Task<bool> Update(ItemDto itemDto)
    {
        var item = await itemRepository.GetById(itemDto.Id);
        if (item == null)
        {
            throw new ServiceException(ErrorCodes.ItemNotFound,
                $"Item with id: '{itemDto.Id}' was not found.");
        }

        var itemType = EnumExtension.Parse<ItemType>(itemDto.ItemType, ErrorCodes.ItemTypeNotFound);

        item.SetName(itemDto.Name);
        item.SetShortName(itemDto.ShortName);
        item.SetItemType(itemType);

        return await itemRepository.Save();
    }

    public async Task<bool> Delete(int id)
    {
        var item = await itemRepository.GetById(id);
        if (item == null)
        {
            throw new ServiceException(ErrorCodes.ItemNotFound,
                $"Item with id: '{id}' was not found.");
        }

        await itemRepository.Delete(item);

        return await itemRepository.Save();
    }
}