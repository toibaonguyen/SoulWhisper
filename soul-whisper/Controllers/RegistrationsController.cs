using Microsoft.AspNetCore.Mvc;
using soul_whisper.Models.Public;
using soul_whisper.Helpers;

namespace soul_whisper.Controllers;

[ApiController]
[Route("[controller]", Name = "registrations")]

public class RegistrationsController : ControllerBase
{
    private readonly string MISSING_TOKEN = "Missing token!";
    private readonly ILogger<RegistrationsController> _logger;
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
    public RegistrationsController(ILogger<RegistrationsController> logger)
    {
        _logger = logger;
    }
     // [HttpGet("achievements/{registrationId}")]
    // public async Task<ActionResult<BaseResponseDTO>> GetAchievementRegistrationById(Guid registrationId)
    // {

    // }
    // [HttpGet("doctorships/{registrationId}")]
    // public async Task<ActionResult<BaseResponseDTO>> GetDoctorshipRegistrationById(Guid registrationId)
    // {

    // }
    // [HttpGet("doctorships")]
    // public async Task<ActionResult<BaseResponseDTO>> GetDoctorshipRegistrations(DoctorshipRegistrationDTO registration)
    // {

    // }
    // [HttpPost("doctorships")]
    // public async Task<ActionResult<BaseResponseDTO>> CreateDoctorshipRegistration(DoctorshipRegistrationDTO registration)
    // {

    // }
    // [HttpPatch("doctorships/{registrationId}")]
    // public async Task<ActionResult<BaseResponseDTO>> UpdateDoctorshipRegistration(UpdateDoctorshipRegistrationDTO registration)
    // {

    // }

    // [HttpGet("appointments/{registrationId}")]
    // public async Task<ActionResult<BaseResponseDTO>> GetAppointmentRegistrationById(Guid registrationId)
    // {

    // }
    // [HttpGet("appointments")]
    // public async Task<ActionResult<BaseResponseDTO>> GetAppointmentRegistrations(AppointmentRegistrationDTO registration)
    // {

    // }
    // [HttpPost("appointments")]
    // public async Task<ActionResult<BaseResponseDTO>> CreateAppointmentRegistration(AppointmentRegistrationDTO registration)
    // {

    // }
    // [HttpPatch("appointments/{registrationId}")]
    // public async Task<ActionResult<BaseResponseDTO>> UpdateAppointmentRegistration(UpdateAppointmentRegistrationDTO registration)
    // {
    // }

}

