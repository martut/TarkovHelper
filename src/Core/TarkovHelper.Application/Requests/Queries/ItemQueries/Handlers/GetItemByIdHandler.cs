using MediatR;
using TarkovHelper.Application.DTO;
using TarkovHelper.Application.Services.Interfaces;

namespace TarkovHelper.Application.Requests.Queries.ItemQueries.Handlers;

public class GetItemByIdHandler(IItemService itemService) : IRequestHandler<GetItemById, ItemDto?>
{
    public async Task<ItemDto?> Handle(GetItemById request, CancellationToken cancellationToken)
        => await itemService.GetById(request.Id);
}