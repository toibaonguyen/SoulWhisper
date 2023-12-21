using Microsoft.AspNetCore.Mvc;
using soul_whisper.Models.Public;
using soul_whisper.Helpers;
namespace soul_whisper.Controllers;

[ApiController]
[Route("[controller]", Name = "conservation")]

public class ExercisesController : ControllerBase
{
    private readonly ILogger<ExercisesController> _logger;
        private readonly string MISSING_TOKEN = "Missing token!";
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
    public ExercisesController(ILogger<ExercisesController> logger)
    {
        _logger = logger;
    }
    // [HttpGet]
    // public async Task<ActionResult<BaseResponseDTO>> GetExercises()
    // {

    // }
    // [HttpGet("{exerciseId}")]
    // public async Task<ActionResult<BaseResponseDTO>> GetExerciseById(Guid exerciseId)
    // {

    // }
    // [HttpPatch("{exerciseId}")]
    // public async Task<ActionResult<BaseResponseDTO>> UpdateExercise(Guid exerciseId,UpdateExerciseDTO updateExercise)
    // {
        
    // }
    // [HttpPost]
    // public async Task<ActionResult<BaseResponseDTO>> CreateExercise(ExerciseDTO exercise)
    // {

    // }
}

