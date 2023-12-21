using Microsoft.AspNetCore.Mvc;
using soul_whisper.Models.Public;

namespace soul_whisper.Controllers;

[ApiController]
[Route("[controller]", Name = "conservation")]

public class ExercisesController : ControllerBase
{
    private readonly ILogger<ExercisesController> _logger;
    public ExercisesController(ILogger<ExercisesController> logger)
    {
        _logger = logger;
    }
    [HttpGet]
    public async Task<ActionResult<BaseResponseDTO>> GetExercises()
    {

    }
    [HttpGet("{exerciseId}")]
    public async Task<ActionResult<BaseResponseDTO>> GetExerciseById(Guid exerciseId)
    {

    }
    [HttpPut("{exerciseId}")]
    public async Task<ActionResult<BaseResponseDTO>> SetExercise(Guid exerciseId)
    {

    }
    [HttpPatch("{exerciseId}")]
    public async Task<ActionResult<BaseResponseDTO>> UpdateExercise(Guid exerciseId,UpdateExerciseDTO updateExercise)
    {
        
    }
    [HttpPost]
    public async Task<ActionResult<BaseResponseDTO>> CreateExercise(ExerciseDTO exercise)
    {

    }
}

