using MediatR;
using TarkovHelper.Application.Services.Interfaces;

namespace TarkovHelper.Application.Requests.Commands.QuestCommands.Handlers;

public class UpdateQuestHandler(IQuestService questService) : IRequestHandler<UpdateQuest, bool>
{
    public async Task<bool> Handle(UpdateQuest request, CancellationToken cancellationToken)
        => await questService.Update(request.Quest);
}