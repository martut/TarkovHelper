using MediatR;
using TarkovHelper.Application.Services.Interfaces;

namespace TarkovHelper.Application.Requests.Commands.QuestCommands.Handlers;

public class CreateQuestHandler(IQuestService questService) : IRequestHandler<CreateQuest, int>
{
    public async Task<int> Handle(CreateQuest request, CancellationToken cancellationToken)
        => await questService.Create(request.Quest);
}