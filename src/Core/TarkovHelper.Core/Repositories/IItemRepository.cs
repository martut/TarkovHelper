using TarkovHelper.Core.Interfaces;
using TarkovHelper.Core.Models;

namespace TarkovHelper.Core.Repositories;

public interface IItemRepository : ITransientService
{
    Task<IEnumerable<Item>> GetAll();
}