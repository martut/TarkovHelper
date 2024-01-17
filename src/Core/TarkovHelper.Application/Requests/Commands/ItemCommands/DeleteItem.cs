using MediatR;

namespace TarkovHelper.Application.Requests.Commands.ItemCommands;

public class DeleteItem : IRequest<bool>
{
    public int Id { get; set; }
}