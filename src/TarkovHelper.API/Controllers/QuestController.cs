using Microsoft.AspNetCore.Mvc;
using TarkovHelper.Application.DTO;
using TarkovHelper.Application.Requests.Commands.QuestCommands;
using TarkovHelper.Application.Requests.Queries.QuestQueries;

namespace TarkovHelper.API.Controllers;

public class QuestController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await Mediator.Send(new GetAllQuests()));
    }

    [HttpGet("{id:int}", Name = "GetQuestById")]
    public async Task<IActionResult> GetById(int id)
    {
        var quest = await Mediator.Send(new GetQuestById { Id = id });

        if (quest == null)
        {
            return NotFound();
        }

        return Ok(quest);
    }

    [HttpPost]
    public async Task<IActionResult> Create(QuestCreateDto quest)
    {
        var id = await Mediator.Send(new CreateQuest(quest));

        return CreatedAtRoute("GetQuestById", new { id }, null);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, QuestDto quest)
    {
        if (id != quest.Id)
        {
            return BadRequest();
        }

        var updated = await Mediator.Send(new UpdateQuest(quest));

        if (!updated)
        {
            return BadRequest();
        }

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await Mediator.Send(new DeleteQuest { Id = id });

        if (!deleted)
        {
            return BadRequest();
        }

        return NoContent();
    }
}