using Microsoft.AspNetCore.Mvc;
using soul_whisper.Models.Public;

namespace soul_whisper.Controllers;

[ApiController]
[Route("[controller]", Name = "habits")]

public class HabitsController : ControllerBase
{
    private readonly ILogger<HabitsController> _logger;
    public HabitsController(ILogger<HabitsController> logger)
    {
        _logger = logger;
    }
    [HttpGet]
    public async Task<ActionResult<BaseResponseDTO>> GetHabits()
    {

    }
    [HttpGet("{habitId}")]
    public async Task<ActionResult<BaseResponseDTO>> GetHabitById(Guid habitId)
    {

    }
    [HttpPatch("{habitId}")]
    public async Task<ActionResult<BaseResponseDTO>> UpdateHabit(Guid habitId,UpdateHabitDTO updateHabit)
    {
        
    }
    [HttpPost]
    public async Task<ActionResult<BaseResponseDTO>> CreateHabit(HabitDTO exercise)
    {

    }
}

