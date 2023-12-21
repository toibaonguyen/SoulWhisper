using Microsoft.AspNetCore.Mvc;
using soul_whisper.Models.Public;
using soul_whisper.Helpers;

namespace soul_whisper.Controllers;

[ApiController]
[Route("[controller]", Name = "messages")]

public class MessagesController : ControllerBase
{
    private readonly ILogger<MessagesController> _logger;
        private readonly string MISSING_TOKEN = "Missing token!";
    public MessagesController(ILogger<MessagesController> logger)
    {
        _logger = logger;
    }
private UserDTO ConvertAccessTokenToUserDTO()
    {
       string? authHeaderValue = HttpContext.Request.Headers["Authorization"];
        if (String.IsNullOrEmpty(authHeaderValue))
        {
            throw new UnauthorizedAccessException(this.MISSING_TOKEN);
        }
        var myMachine = new TokenConverterMachine();
        UserDTO user = myMachine.ConvertAccessTokenToUserDTO(authHeaderValue);
        return user;
    }
    // [HttpGet]
    // public async Task<ActionResult<BaseResponseDTO>> GetMessages()
    // {

    // }
    // [HttpPost]
    // public async Task<ActionResult<BaseResponseDTO>> CreateMessage(MessageDTO message)
    // {

    // }

}

