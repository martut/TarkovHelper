using MediatR;
using TarkovHelper.Application.DTO;

namespace TarkovHelper.Application.Requests.Queries.ItemQueries;

public class GetAllItems : IRequest<IEnumerable<ItemDto>>
{
}