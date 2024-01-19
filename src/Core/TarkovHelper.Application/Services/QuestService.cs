using AutoMapper;
using TarkovHelper.Application.DTO;
using TarkovHelper.Application.Exceptions;
using TarkovHelper.Application.Extension;
using TarkovHelper.Application.Services.Interfaces;
using TarkovHelper.Core.Models;
using TarkovHelper.Core.Models.Enums;
using TarkovHelper.Core.Repositories;

namespace TarkovHelper.Application.Services;

public class QuestService(
    IQuestRepository questRepository,
    IRequiredItemService requiredItemService,
    IMapper mapper)
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
            quest.AddRequiredItem(await requiredItemService.Create(requiredItemCreateDto));
        }

        await questRepository.Create(quest);
        await questRepository.Save();

        return quest.Id;
    }

    public async Task<bool> Delete(int id)
    {
        var quest = await questRepository.GetById(id);
        if (quest == null)
        {
            throw new ServiceException(ErrorCodes.QuestNotFound,
                $"Quest with id: '{id}' was not found.");
        }

        foreach (var requiredItem in quest.RequiredItems)
        {
            await requiredItemService.Delete(requiredItem);
        }

        await questRepository.Delete(quest);

        return await questRepository.Save();
    }

    public async Task<bool> Update(QuestDto questDto)
    {
        var quest = await questRepository.GetById(questDto.Id);
        if (quest == null)
        {
            throw new ServiceException(ErrorCodes.QuestNotFound,
                $"Quest with id: '{questDto.Id}' was not found.");
        }

        quest.SetName(questDto.Name);
        var trader = EnumExtension.Parse<Trader>(questDto.Trader, ErrorCodes.TraderNotFound);
        quest.SetTrader(trader);

        var requiredItemsToDelete =
            quest.RequiredItems.Where(r => questDto.RequiredItems.Select(i => i.Id).Contains(r.Id));
        foreach (var requiredItem in requiredItemsToDelete)
        {
            await requiredItemService.Delete(requiredItem);
        }

        foreach (var requiredItemDto in questDto.RequiredItems)
        {
            if (requiredItemDto.Id == null)
            {
                quest.AddRequiredItem(await requiredItemService.Create(requiredItemDto));
            }

            var reqItem = quest.RequiredItems.SingleOrDefault(r => r.Id == requiredItemDto.Id);
            if (reqItem == null)
            {
                throw new ServiceException(ErrorCodes.RequiredItemNotFound,
                    $"Required item with id: '{requiredItemDto.Id}' was not found.");
            }

            reqItem.SetCount(requiredItemDto.Count);
            reqItem.SetIsFoundInRaid(requiredItemDto.IsFoundInRaid);
        }

        return await questRepository.Save();
    }
}