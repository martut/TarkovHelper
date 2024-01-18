using MediatR;
using TarkovHelper.Application.Services.Interfaces;

namespace TarkovHelper.Application.Requests.Commands.QuestCommands.Handlers;

public class DeleteQuestHandler(IQuestService questService) : IRequestHandler<DeleteQuest, bool>
{
    public async Task<bool> Handle(DeleteQuest request, CancellationToken cancellationToken)
        => await questService.Delete(request.Id);
}