using Microsoft.AspNetCore.Mvc;
using TarkovHelper.Application.Requests.Queries.ItemQueries;

namespace TarkovHelper.API.Controllers;

public class ItemController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await Mediator.Send(new GetAllItemsQuery()));
    }
}