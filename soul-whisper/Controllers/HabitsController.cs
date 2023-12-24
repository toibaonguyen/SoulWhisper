using Microsoft.AspNetCore.Mvc;
using soul_whisper.Models.Public;
using soul_whisper.Helpers;
using soul_whisper.Service;
using soul_whisper.Models.Public.Enum;

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
    [HttpGet]
    public async Task<ActionResult<BaseResponseDTO>> GetHabits()
    {
        string? patientId = HttpContext.Request.Query["patientId"];
        UserDTO user = this.ConvertAccessTokenToUserDTO();
        var service = new HabitService();
        List<HabitDTO> habits = await service.GetHabitDTOs();
        if (user.role == UserRole.PATIENT)
        {
            return Ok(new ContainDataResponseDTO { data = habits.Where(i => i.patientId == user.userId).ToList() });
        }
        else
        {
            if (patientId == null)
            {
                return BadRequest(new ContainMessageResponseDTO { message = "Missing patientId in query" });
            }
            else
            {
                return Ok(new ContainDataResponseDTO { data = habits.Where(i => i.patientId == Guid.Parse(patientId)).ToList() });
            }
        }

    }
    [HttpGet("{habitId}")]
    public async Task<ActionResult<BaseResponseDTO>> GetHabitById(Guid habitId)
    {

        var service = new HabitService();
        List<HabitDTO> habits = await service.GetHabitDTOs();
        HabitDTO? habit = habits.FirstOrDefault(h => h.id == habitId);
        if (habit == null)
        {
            return BadRequest(new ContainMessageResponseDTO { message = "Habit is not exist" });
        }
        else
        {

            return Ok(new ContainDataResponseDTO { data = habit });
        }
    }
    [HttpPatch("{habitId}")]
    public async Task<ActionResult<BaseResponseDTO>> UpdateHabit(Guid habitId, UpdateHabitDTO updateHabit)
    {

        UserDTO user = this.ConvertAccessTokenToUserDTO();
        var service = new HabitService();

        List<HabitDTO> habits = await service.GetHabitDTOs();
        if (habits.Count(e => e.patientId == user.userId) > 0)
        {
            await service.UpdateHabit(habitId, updateHabit);
            return Ok(new ContainMessageResponseDTO { message = "Updated successfully" });

        }
        else
        {
            return BadRequest(new ContainMessageResponseDTO { message = "You do not have permission" });
        }

    }
    [HttpPost]
    public async Task<ActionResult<BaseResponseDTO>> CreateHabit(HabitDTO habit)
    {
        UserDTO user = this.ConvertAccessTokenToUserDTO();
        habit.patientId = user.userId;
        if (user.role == UserRole.PATIENT)
        {
            var service = new HabitService();
            await service.CreateHabit(habit);
            return Ok(new ContainMessageResponseDTO { message = "created successfully" });
        }
        else
        {
            return BadRequest(new ContainMessageResponseDTO { message = "You do not have permission" });
        }
    }
        [HttpDelete("{habitId}")]
    public async Task<ActionResult<BaseResponseDTO>> DeleteHabit(Guid habitId)
    {
        UserDTO user = this.ConvertAccessTokenToUserDTO();
            var service = new HabitService();
        if ((await service.GetHabitDTOs()).Count(e=>e.patientId==user.userId&&e.id==habitId)>0)
        {
            await service.DeleteHabit(habitId);
            return Ok(new ContainMessageResponseDTO { message = "Deleted successfully" });
        }
        return BadRequest(new ContainMessageResponseDTO { message = "You do not have permission" });
    }
}

