using MediatR;
using TarkovHelper.Application.Services.Interfaces;

namespace TarkovHelper.Application.Requests.Commands.ItemCommands.Handlers;

public class CreateItemHandler(IItemService itemService) : IRequestHandler<CreateItem, int>
{
    public async Task<int> Handle(CreateItem request, CancellationToken cancellationToken)
        => await itemService.Create(request.Item);
}