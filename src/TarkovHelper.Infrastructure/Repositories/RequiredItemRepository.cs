using TarkovHelper.Core.Models;
using TarkovHelper.Core.Repositories;
using TarkovHelper.Infrastructure.DAL;

namespace TarkovHelper.Infrastructure.Repositories;

public class RequiredItemRepository(ApplicationDbContext dbContext) : IRequiredItemRepository
{
    public async Task Delete(RequiredItem requiredItem)
    {
        dbContext.RequiredItems.Remove(requiredItem);
        await Task.CompletedTask;
    }
}