using MediatR;
using TarkovHelper.Application.DTO;

namespace TarkovHelper.Application.Requests.Commands.QuestCommands;

public class UpdateQuest(QuestDto quest) : IRequest<bool>
{
    public QuestDto Quest { get; set; } = quest;
}