using MediatR;
using TarkovHelper.Application.Services.Interfaces;

namespace TarkovHelper.Application.Requests.Commands.ItemCommands.Handlers;

public class UpdateItemHandler(IItemService itemService) : IRequestHandler<UpdateItem, bool>
{
    public async Task<bool> Handle(UpdateItem request, CancellationToken cancellationToken)
        => await itemService.Update(request.ItemDto);
}