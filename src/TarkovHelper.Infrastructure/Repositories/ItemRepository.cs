using Microsoft.EntityFrameworkCore;
using TarkovHelper.Core.Models;
using TarkovHelper.Core.Repositories;
using TarkovHelper.Infrastructure.DAL;

namespace TarkovHelper.Infrastructure.Repositories;

public class ItemRepository(ApplicationDbContext dbContext) : IItemRepository
{
    public async Task<IEnumerable<Item>> GetAll() => await dbContext.Items.ToListAsync();

    public async Task<Item?> GetById(int id)
    {
        var item = await dbContext.Items.FirstOrDefaultAsync(i => i.Id == id);

        return item;
    }

    public async Task<int> Create(Item item)
    {
        await dbContext.Items.AddAsync(item);

        return await dbContext.SaveChangesAsync();
    }
}