using Microsoft.EntityFrameworkCore;
using TarkovHelper.Core.Models;
using TarkovHelper.Core.Repositories;
using TarkovHelper.Infrastructure.DAL;

namespace TarkovHelper.Infrastructure.Repositories;

public class ItemRepository(ApplicationDbContext dbContext) : IItemRepository
{
    public async Task<IEnumerable<Item>> GetAll() => await dbContext.Items.ToListAsync();
}