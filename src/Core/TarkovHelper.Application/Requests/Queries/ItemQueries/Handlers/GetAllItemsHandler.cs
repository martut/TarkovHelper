using MediatR;
using TarkovHelper.Application.DTO;
using TarkovHelper.Application.Services.Interfaces;

namespace TarkovHelper.Application.Requests.Queries.ItemQueries.Handlers;

public class GetAllItemsHandler(IItemService itemService)
    : IRequestHandler<GetAllItems, IEnumerable<ItemDto>>
{
    public async Task<IEnumerable<ItemDto>> Handle(GetAllItems request, CancellationToken cancellationToken)
        => await itemService.GetAll();
}