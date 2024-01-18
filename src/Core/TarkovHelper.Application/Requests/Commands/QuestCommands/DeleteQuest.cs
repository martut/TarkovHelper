using MediatR;

namespace TarkovHelper.Application.Requests.Commands.QuestCommands;

public class DeleteQuest : IRequest<bool>
{
    public int Id { get; set; }
}