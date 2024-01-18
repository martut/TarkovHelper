using TarkovHelper.Application.DTO;
using TarkovHelper.Core.Interfaces;

namespace TarkovHelper.Application.Services.Interfaces;

public interface IQuestService : ITransientService
{
    Task<IEnumerable<QuestDto>> GetAll();
    Task<QuestDto?> GetById(int id);
    Task<int> Create(QuestCreateDto questDto);
    Task<bool> Delete(int id);
    Task<bool> Update(QuestDto questDto);
}