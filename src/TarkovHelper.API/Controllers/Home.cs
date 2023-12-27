using Microsoft.AspNetCore.Mvc;

namespace TarkovHelper.API.Controllers;

public class Home : BaseApiController
{
    
    
    // GET

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await Mediator.Send());
    }
}