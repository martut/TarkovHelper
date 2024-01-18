using Microsoft.EntityFrameworkCore;
using TarkovHelper.Core.Models;
using TarkovHelper.Core.Repositories;
using TarkovHelper.Infrastructure.DAL;

namespace TarkovHelper.Infrastructure.Repositories;

public class QuestRepository(ApplicationDbContext dbContext) : IQuestRepository
{
    public async Task<IEnumerable<Quest>> GetAll()
        => await dbContext
            .Quests
            .Include(q => q.RequiredItems)
            .ThenInclude(r => r.Item)
            .ToListAsync();

    public async Task<Quest?> GetById(int id)
        => await dbContext
            .Quests
            .Include(q => q.RequiredItems)
            .ThenInclude(r => r.Item)
            .FirstOrDefaultAsync(i => i.Id == id);

    public async Task Create(Quest quest)
        => await dbContext.Quests.AddAsync(quest);


    public async Task<bool> Save()
        => await dbContext.SaveChangesAsync() >= 0;

    public async Task Delete(Quest quest)
    {
        dbContext.Quests.Remove(quest);
        await Task.CompletedTask;
    }

    public async Task<int> SaveAndGetId()
        => await dbContext.SaveChangesAsync();
}