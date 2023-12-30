using Microsoft.AspNetCore.Mvc;
using soul_whisper.Helpers;
using soul_whisper.Models.Public;
using soul_whisper.Models.Public.Enum;
using soul_whisper.Service;

namespace soul_whisper.Controllers;

[ApiController]
[Route("[controller]", Name = "appointments")]

public class AppointmentsController : ControllerBase
{
    private readonly ILogger<AppointmentsController> _logger;
    private readonly string LOGOUT_SUCCESSFULLY = "Logout successfully!";
    private readonly string MISSING_TOKEN = "Missing token!";
    private readonly string UPDATE_SUCCESSFULLY = "Updated successfully!";
    private readonly string DELETE_SUCCESSFULLY = "Deleted successfully!";
    private readonly string DO_NOT_HAVE_PERMISSION = "Do not permission";
    private readonly string CREATED_SUCCESSFULLY = "Created successfully";
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
    [HttpGet]
    public async Task<ActionResult<BaseResponseDTO>> GetAppointments()
    {
        string? limit = HttpContext.Request.Query["limit"];
        string? doctorId = HttpContext.Request.Query["doctorId"];
        string? patientId = HttpContext.Request.Query["patientId"];

        UserDTO user = this.ConvertAccessTokenToUserDTO();
        var service = new AppointmentService();
        List<AppointmentDTO> appointments = await service.GetAppointmentDTOs();
        if (limit != null)
        {
            if (doctorId != null || patientId != null)
            {
                return Ok(new ContainDataResponseDTO
                {
                    data = appointments.Where((a)=>
                    {
                        if (doctorId != null)
                        {
                            return a.doctorId == Guid.Parse(doctorId);
                        }
                        else
                        {
                            return a.patientId == Guid.Parse(patientId);
                        }
                    }).Take(Int32.Parse(limit))
                });

            }
            return Ok(new ContainDataResponseDTO { data = appointments.Where(a => a.doctorId == user.userId || a.patientId == user.userId).Take(Int32.Parse(limit)) });
        }
        if (doctorId != null || patientId != null)
        {
            return Ok(new ContainDataResponseDTO { data = appointments.Where(a => a.doctorId == Guid.Parse(doctorId) || a.patientId == Guid.Parse(patientId)) });

        }
        return Ok(new ContainDataResponseDTO { data = appointments.Where(a => a.doctorId == user.userId || a.patientId == user.userId) });
    }
    [HttpGet("{appointmentId}")]
    public async Task<ActionResult<BaseResponseDTO>> GetAppointmentById(Guid appointmentId)
    {
        UserDTO user = this.ConvertAccessTokenToUserDTO();
        var service = new AppointmentService();
        List<AppointmentDTO> appointments = await service.GetAppointmentDTOs();
        return Ok(new ContainDataResponseDTO { data = appointments.Where(a => a.id == appointmentId) });

    }
    //DO NOT USE THIS -> CREATE VIA REGISTERCONTROLLER
    // [HttpPost]
    // public async Task<ActionResult<BaseResponseDTO>> CreateAppointment(AppointmentDTO appointment)
    // {

    // }
    [HttpPatch("{appointmentId}")]
    public async Task<ActionResult<BaseResponseDTO>> UpdateAppointment(Guid appointmentId, UpdateAppointmentDTO update)
    {
        var service = new AppointmentService();
        UserDTO user = this.ConvertAccessTokenToUserDTO();
        if (user.role != UserRole.DOCTOR)
        {
            throw new InvalidOperationException(DO_NOT_HAVE_PERMISSION);
        }
        await service.UpdateAppointment(appointmentId, update);
        return Ok(new ContainMessageResponseDTO { message = UPDATE_SUCCESSFULLY });
    }
}
