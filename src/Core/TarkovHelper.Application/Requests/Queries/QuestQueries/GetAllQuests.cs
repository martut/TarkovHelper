using MediatR;
using TarkovHelper.Application.DTO;

namespace TarkovHelper.Application.Requests.Queries.QuestQueries;

public class GetAllQuests : IRequest<IEnumerable<QuestDto>>
{
}