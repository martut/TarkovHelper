using AutoMapper;
using MediatR;
using TarkovHelper.Application.DTO;
using TarkovHelper.Core.Repositories;

namespace TarkovHelper.Application.Requests.Queries.ItemQueries.Handlers;

public class GetAllItemsQueryHandler(IItemRepository itemRepository, IMapper mapper)
    : IRequestHandler<GetAllItemsQuery, IEnumerable<ItemDto>>
{
    public async Task<IEnumerable<ItemDto>> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
    {
        var items = await itemRepository.GetAll();

        return mapper.Map<IEnumerable<ItemDto>>(items);
    }
}