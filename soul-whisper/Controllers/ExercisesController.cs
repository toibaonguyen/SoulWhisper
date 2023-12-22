using Microsoft.AspNetCore.Mvc;
using soul_whisper.Models.Public;
using soul_whisper.Helpers;
using soul_whisper.Service;
using soul_whisper.Models.Public.Enum;
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
    [HttpGet]
    public async Task<ActionResult<BaseResponseDTO>> GetExercises()
    {
        string? limit = HttpContext.Request.Query["limit"];
        UserDTO user = this.ConvertAccessTokenToUserDTO();
        var service = new ExerciseService();
        List<ExerciseDTO> exercises = await service.GetExerciseDTOs();

        if (limit != null)
        {
            return Ok(new ContainDataResponseDTO { data = exercises.Take(Int32.Parse(limit)) });
        }
        return Ok(new ContainDataResponseDTO { data = exercises });


    }
    [HttpGet("{exerciseId}")]
    public async Task<ActionResult<BaseResponseDTO>> GetExerciseById(Guid exerciseId)
    {
        UserDTO user = this.ConvertAccessTokenToUserDTO();
        var service = new ExerciseService();
        List<ExerciseDTO> exercises = await service.GetExerciseDTOs();
        ExerciseDTO? exercise=exercises.FirstOrDefault(e=>e.id==exerciseId);
        if(exercise==null)
        {
            return BadRequest(new ContainMessageResponseDTO{message="Exercise is not exist"});
        }
        return Ok(new ContainDataResponseDTO { data = exercise });
    }
    [HttpPatch("{exerciseId}")]
    public async Task<ActionResult<BaseResponseDTO>> UpdateExercise(Guid exerciseId,UpdateExerciseDTO updateExercise)
    {
        try{

        UserDTO user = this.ConvertAccessTokenToUserDTO();
        
        var service = new ExerciseService();
        await service.UpdateExercise(exerciseId,updateExercise);
        return Ok(new ContainMessageResponseDTO{message="Updated successfully"});
        }
        catch(Exception)
        {
            throw;
        }
    }
    // [HttpPost]
    // public async Task<ActionResult<BaseResponseDTO>> CreateExercise(ExerciseDTO exercise)
    // {

    // }
}

