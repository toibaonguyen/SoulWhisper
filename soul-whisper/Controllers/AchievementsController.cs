using Microsoft.AspNetCore.Mvc;
using soul_whisper.Helpers;
using soul_whisper.Models.Private.Enum;
using soul_whisper.Models.Public;
using soul_whisper.Models.Public.Enum;
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
    [HttpGet]
    public async Task<ActionResult<BaseResponseDTO>> GetAchievements()
    {
        string? doctorIdQuery = HttpContext.Request.Query["doctorId"];
        if (doctorIdQuery == null)
        {
            UserDTO user = this.ConvertAccessTokenToUserDTO();
            var service = new AchievementService();
            List<AchievementDTO> achievements = await service.GetAchievementDTOsWithDoctorId(user.userId);
            return Ok(new ContainDataResponseDTO { data = achievements });
        }
        else
        {
            UserDTO user = this.ConvertAccessTokenToUserDTO();
            var service = new AchievementService();
            List<AchievementDTO> achievements = await service.GetAchievementDTOsWithDoctorId(Guid.Parse(doctorIdQuery));
            if (user.role == UserRole.PATIENT)
            {
                List<AchievementDTO> activeAchievements = achievements.Where(a => a.activationStatus == ActivationStatus.ACTIVE.ToString()).ToList();
                return Ok(new ContainDataResponseDTO { data = activeAchievements });
            }
            return Ok(new ContainDataResponseDTO { data = achievements });
        }
    }

    [HttpGet("{achievementId}")]
    public async Task<ActionResult<BaseResponseDTO>> GetAchievementById(Guid achievementId)
    {
        var service = new AchievementService();
        AchievementDTO achievement = await service.GetAchievementDTOById(achievementId);
        return Ok(new ContainDataResponseDTO { data = achievement });
    }
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

