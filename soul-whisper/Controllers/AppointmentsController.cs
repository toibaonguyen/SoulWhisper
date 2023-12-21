using Microsoft.AspNetCore.Mvc;
using soul_whisper.Helpers;
using soul_whisper.Models.Public;
using soul_whisper.Service;

namespace soul_whisper.Controllers;

[ApiController]
[Route("[controller]", Name = "appointments")]

public class AppointmentsController : ControllerBase
{
    private readonly ILogger<AppointmentsController> _logger;
    private readonly string MISSING_TOKEN = "Missing token!";
    public AppointmentsController(ILogger<AppointmentsController> logger)
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
    // public async Task<ActionResult<BaseResponseDTO>> GetAppointments()
    // {

    // }
    // [HttpGet("{appointmentId}")]
    // public async Task<ActionResult<BaseResponseDTO>> GetAppointmentById(Guid appointmentId)
    // {

    // }
    // [HttpPost]
    // public async Task<ActionResult<BaseResponseDTO>> CreateAppointment(AppointmentDTO appointment)
    // {

    // }
    // [HttpPatch("{appointmentId}")]
    // public async Task<ActionResult<BaseResponseDTO>> UpdateAppointment(Guid appointmentId, UpdateAppointmentDTO appointment)
    // {

    // }
}

