using MediatR;
using TarkovHelper.Application.DTO;
using TarkovHelper.Application.Services.Interfaces;

namespace TarkovHelper.Application.Requests.Queries.QuestQueries.Handlers;

public class GetAllQuestsHandler(IQuestService questService) : IRequestHandler<GetAllQuests, IEnumerable<QuestDto>>
{
    public async Task<IEnumerable<QuestDto>> Handle(GetAllQuests request, CancellationToken cancellationToken)
        => await questService.GetAll();
}