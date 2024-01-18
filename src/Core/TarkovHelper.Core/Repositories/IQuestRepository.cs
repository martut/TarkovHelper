using TarkovHelper.Core.Interfaces;
using TarkovHelper.Core.Models;

namespace TarkovHelper.Core.Repositories;

public interface IQuestRepository : ITransientService
{
    Task<IEnumerable<Quest>> GetAll();

    Task<Quest?> GetById(int id);

    Task Create(Quest quest);

    Task<bool> Save();

    Task Delete(Quest quest);
}