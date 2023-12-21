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

    public AppointmentsController(ILogger<AppointmentsController> logger)
    {
        _logger = logger;
    }
    [HttpGet]
    public async Task<ActionResult<BaseResponseDTO>> GetAppointments()
    {

    }
    [HttpGet("{appointmentId}")]
    public async Task<ActionResult<BaseResponseDTO>> GetAppointmentById(Guid appointmentId)
    {

    }
    [HttpPost]
    public async Task<ActionResult<BaseResponseDTO>> CreateAppointment(AppointmentDTO appointment)
    {

    }
    [HttpPut("{appointmentId}")]
    public async Task<ActionResult<BaseResponseDTO>> SetAppointment(Guid appointmentId, AppointmentDTO appointment)
    {

    }
    [HttpPatch("{appointmentId}")]
    public async Task<ActionResult<BaseResponseDTO>> UpdateAppointment(Guid appointmentId, UpdateAppointmentDTO appointment)
    {

    }
}

