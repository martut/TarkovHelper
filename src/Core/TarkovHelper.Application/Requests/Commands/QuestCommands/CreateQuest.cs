using MediatR;
using TarkovHelper.Application.DTO;

namespace TarkovHelper.Application.Requests.Commands.QuestCommands;

public class CreateQuest(QuestCreateDto quest) : IRequest<int>
{
    public QuestCreateDto Quest { get; set; } = quest;
}