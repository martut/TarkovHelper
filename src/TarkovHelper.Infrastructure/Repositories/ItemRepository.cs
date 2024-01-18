using Microsoft.EntityFrameworkCore;
using TarkovHelper.Core.Models;
using TarkovHelper.Core.Repositories;
using TarkovHelper.Infrastructure.DAL;

namespace TarkovHelper.Infrastructure.Repositories;

public class ItemRepository(ApplicationDbContext dbContext) : IItemRepository
{
    public async Task<IEnumerable<Item>> GetAll() => await dbContext.Items.ToListAsync();

    public async Task<Item?> GetById(int id)
        => await dbContext.Items.FirstOrDefaultAsync(i => i.Id == id);

    public async Task Create(Item item)
        => await dbContext.Items.AddAsync(item);


    public async Task<bool> Save()
        => await dbContext.SaveChangesAsync() >= 0;

    public async Task Delete(Item item)
    {
        dbContext.Items.Remove(item);
        await Task.CompletedTask;
    }

    public async Task<int> SaveAndGetId()
        => await dbContext.SaveChangesAsync();
}