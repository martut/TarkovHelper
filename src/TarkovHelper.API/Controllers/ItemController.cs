using Microsoft.AspNetCore.Mvc;
using TarkovHelper.Application.DTO;
using TarkovHelper.Application.Requests.Commands.ItemCommands;
using TarkovHelper.Application.Requests.Queries.ItemQueries;

namespace TarkovHelper.API.Controllers;

public class ItemController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await Mediator.Send(new GetAllItems()));
    }

    [HttpGet("{id:int}", Name = "GetById")]
    public async Task<IActionResult> GetById(int id)
    {
        var item = await Mediator.Send(new GetItemById { Id = id });

        if (item == null)
        {
            return NotFound();
        }

        return Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ItemCreateDto item)
    {
        var id = await Mediator.Send(new CreateItem(item));

        return CreatedAtRoute("GetById", new { id }, null);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, ItemDto item)
    {
        if (id != item.Id)
        {
            return BadRequest();
        }

        var updated = await Mediator.Send(new UpdateItem(item));

        if (!updated)
        {
            return BadRequest();
        }

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await Mediator.Send(new DeleteItem { Id = id });

        if (!deleted)
        {
            return BadRequest();
        }

        return NoContent();
    }
}