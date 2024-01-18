using MediatR;
using TarkovHelper.Application.DTO;

namespace TarkovHelper.Application.Requests.Queries.QuestQueries;

public class GetQuestById : IRequest<QuestDto?>
{
    public int Id { get; set; }
}