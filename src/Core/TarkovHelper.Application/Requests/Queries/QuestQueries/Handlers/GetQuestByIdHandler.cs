using MediatR;
using TarkovHelper.Application.DTO;
using TarkovHelper.Application.Services.Interfaces;

namespace TarkovHelper.Application.Requests.Queries.QuestQueries.Handlers;

public class GetQuestByIdHandler(IQuestService questService) : IRequestHandler<GetQuestById, QuestDto?>
{
    public async Task<QuestDto?> Handle(GetQuestById request, CancellationToken cancellationToken)
        => await questService.GetById(request.Id);
}