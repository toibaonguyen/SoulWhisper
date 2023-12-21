using Microsoft.AspNetCore.Mvc;
using soul_whisper.Models.Public;

namespace soul_whisper.Controllers;

[ApiController]
[Route("[controller]", Name = "registrations")]

public class RegistrationsController : ControllerBase
{
    private readonly ILogger<RegistrationsController> _logger;

    public RegistrationsController(ILogger<RegistrationsController> logger)
    {
        _logger = logger;
    }
    [HttpGet("doctorships/{registrationId}")]
    public async Task<ActionResult<BaseResponseDTO>> GetDoctorshipRegistrationById(Guid registrationId)
    {

    }
        [HttpGet("doctorships")]
   public async Task<ActionResult<BaseResponseDTO>> GetDoctorshipRegistrations(DoctorshipRegistrationDTO conversation)
    {
        
    }
    [HttpPost("doctorships")]
   public async Task<ActionResult<BaseResponseDTO>> CreateDoctorshipRegistration(DoctorshipRegistrationDTO conversation)
    {
        
    }
    [HttpPatch("doctorships/{registrationId}")]
   public async Task<ActionResult<BaseResponseDTO>> UpdateDoctorshipRegistration(UpdateDoctorshipRegistrationDTO conversation)
    {
    }
    [HttpPost("doctorships/{registrationId}")]
   public async Task<ActionResult<BaseResponseDTO>> UpdateDoctorshipRegistration(UpdateDoctorshipRegistrationDTO conversation)
    {
    }
}

