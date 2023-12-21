using Microsoft.AspNetCore.Mvc;
using soul_whisper.Models.Public;
using soul_whisper.Helpers;

namespace soul_whisper.Controllers;

[ApiController]
[Route("[controller]", Name = "habits")]

public class HabitsController : ControllerBase
{
    private readonly ILogger<HabitsController> _logger;
        private readonly string MISSING_TOKEN = "Missing token!";
    public HabitsController(ILogger<HabitsController> logger)
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
    // public async Task<ActionResult<BaseResponseDTO>> GetHabits()
    // {

    // }
    // [HttpGet("{habitId}")]
    // public async Task<ActionResult<BaseResponseDTO>> GetHabitById(Guid habitId)
    // {

    // }
    // [HttpPatch("{habitId}")]
    // public async Task<ActionResult<BaseResponseDTO>> UpdateHabit(Guid habitId,UpdateHabitDTO updateHabit)
    // {
        
    // }
    // [HttpPost]
    // public async Task<ActionResult<BaseResponseDTO>> CreateHabit(HabitDTO exercise)
    // {

    // }
}

