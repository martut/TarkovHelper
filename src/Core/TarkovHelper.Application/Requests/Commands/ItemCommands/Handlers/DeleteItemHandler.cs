using MediatR;
using TarkovHelper.Application.Services.Interfaces;

namespace TarkovHelper.Application.Requests.Commands.ItemCommands.Handlers;

public class DeleteItemHandler(IItemService itemService) : IRequestHandler<DeleteItem, bool>
{
    public Task<bool> Handle(DeleteItem request, CancellationToken cancellationToken)
        => itemService.Delete(request.Id);
}