using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers;

[Authorize]
[ApiController]
[Route("api/messages")]
public class MessagesController : ControllerBase
{
    [HttpGet]
    public IActionResult GetMessages()
    {
        // Return list of messages
        return Ok();
    }

    /*[HttpPost]
    public IActionResult SendMessage([FromBody] MessageDto message)
    {
        // Process and store the message
        return Ok();
    }*/
}
