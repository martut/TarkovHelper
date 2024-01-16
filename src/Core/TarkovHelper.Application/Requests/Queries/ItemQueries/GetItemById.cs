using MediatR;
using TarkovHelper.Application.DTO;

namespace TarkovHelper.Application.Requests.Queries.ItemQueries;

public class GetItemById : IRequest<ItemDto?>
{
    public int Id { get; set; }
}