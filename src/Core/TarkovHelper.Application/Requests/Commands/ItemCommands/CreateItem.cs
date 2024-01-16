using MediatR;
using TarkovHelper.Application.DTO;

namespace TarkovHelper.Application.Requests.Commands.ItemCommands;

public class CreateItem(ItemCreateDto item) : IRequest<int>
{
    public ItemCreateDto Item { get; set; } = item;
}