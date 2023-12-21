using Microsoft.AspNetCore.Mvc;
using soul_whisper.Models.Public;

namespace soul_whisper.Controllers;

[ApiController]
[Route("[controller]", Name = "messages")]

public class MessagesController : ControllerBase
{
    private readonly ILogger<MessagesController> _logger;
    public MessagesController(ILogger<MessagesController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<BaseResponseDTO>> GetMessages()
    {

    }
    [HttpPost]
    public async Task<ActionResult<BaseResponseDTO>> CreateMessage(MessageDTO message)
    {

    }

}

