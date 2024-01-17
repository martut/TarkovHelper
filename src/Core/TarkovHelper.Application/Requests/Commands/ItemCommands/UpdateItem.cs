using MediatR;
using TarkovHelper.Application.DTO;

namespace TarkovHelper.Application.Requests.Commands.ItemCommands;

public class UpdateItem(ItemDto itemDto) : IRequest<bool>
{
    public ItemDto ItemDto { get; set; } = itemDto;
}