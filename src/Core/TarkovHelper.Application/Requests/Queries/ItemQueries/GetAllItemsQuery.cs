using MediatR;
using TarkovHelper.Application.DTO;

namespace TarkovHelper.Application.Requests.Queries.ItemQueries;

public class GetAllItemsQuery : IRequest<IEnumerable<ItemDto>>
{
}