using TarkovHelper.Application.DTO;
using TarkovHelper.Core.Interfaces;

namespace TarkovHelper.Application.Services.Interfaces;

public interface IItemService : ITransientService
{
    Task<ItemDto?> GetById(int id);

    Task<IEnumerable<ItemDto>> GetAll();

    Task<int> Create(ItemCreateDto item);
}