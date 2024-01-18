using AutoMapper;
using TarkovHelper.Application.DTO;
using TarkovHelper.Application.Exceptions;
using TarkovHelper.Application.Extension;
using TarkovHelper.Application.Services.Interfaces;
using TarkovHelper.Core.Models;
using TarkovHelper.Core.Models.Enums;
using TarkovHelper.Core.Repositories;

namespace TarkovHelper.Application.Services;

public class QuestService(IQuestRepository questRepository, IItemRepository itemRepository, IMapper mapper)
    : IQuestService
{
    public async Task<IEnumerable<QuestDto>> GetAll()
    {
        var quests = await questRepository.GetAll();

        return mapper.Map<IEnumerable<QuestDto>>(quests);
    }

    public async Task<QuestDto?> GetById(int id)
    {
        var quest = await questRepository.GetById(id);

        return quest == null ? null : mapper.Map<QuestDto>(quest);
    }

    public async Task<int> Create(QuestCreateDto questDto)
    {
        var trader = EnumExtension.Parse<Trader>(questDto.Trader, ErrorCodes.TraderNotFound);
        var quest = new Quest(questDto.Name, trader, questDto.IsActive);
        foreach (var requiredItemCreateDto in questDto.RequiredItem)
        {
            quest.AddRequiredItem(await CreateRequiredItem(requiredItemCreateDto));
        }

        await questRepository.Create(quest);
        await questRepository.Save();

        return quest.Id;
    }

    public async Task<bool> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Update(QuestDto questDto)
    {
        throw new NotImplementedException();
    }

    private async Task<RequiredItem> CreateRequiredItem(RequiredItemCreateDto reqItemDto)
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
}