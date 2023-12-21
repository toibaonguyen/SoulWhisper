using Microsoft.AspNetCore.Mvc;
using soul_whisper.Helpers;
using soul_whisper.Models.Public;
using soul_whisper.Service;

namespace soul_whisper.Controllers;

[ApiController]
[Route("[controller]", Name = "achievements")]

public class AchievementsController : ControllerBase
{
    private readonly ILogger<AchievementsController> _logger;
    private readonly string MISSING_TOKEN = "Missing token!";
    public AchievementsController(ILogger<AchievementsController> logger)
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
    // public async Task<ActionResult<BaseResponseDTO>> GetAchievements()
    // {

    // }
    
    // [HttpGet("{achievementId}")]
    // public async Task<ActionResult<BaseResponseDTO>> GetAchievementById(Guid achievementId)
    // {

    // }
    // [HttpPost]
    // public async Task<ActionResult<BaseResponseDTO>> CreateAppointment(AchievementDTO achievement)
    // {

    // }

    // [HttpPatch("{achievementId}")]
    // public async Task<ActionResult<BaseResponseDTO>> UpdateAppointment(Guid achievementId, UpdateAchievementDTO achievement)
    // {

    // }

    //    [HttpDelete("{achievementId}")]
    // public async Task<ActionResult<BaseResponseDTO>> DeleteAchievement(Guid achievementId)
    // {

    // }
}

