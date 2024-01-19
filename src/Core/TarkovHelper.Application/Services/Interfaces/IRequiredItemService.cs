using TarkovHelper.Application.DTO;
using TarkovHelper.Core.Interfaces;
using TarkovHelper.Core.Models;

namespace TarkovHelper.Application.Services.Interfaces;

public interface IRequiredItemService : ITransientService
{
    Task<RequiredItem> Create(RequiredItemCreateDto reqItemDto);
    Task<RequiredItem> Create(RequiredItemDto reqItemDto);
    Task Delete(RequiredItem requiredItem);
}