using TarkovHelper.Core.Interfaces;
using TarkovHelper.Core.Models;

namespace TarkovHelper.Core.Repositories;

public interface IRequiredItemRepository : ITransientService
{
    Task Delete(RequiredItem requiredItem);
}