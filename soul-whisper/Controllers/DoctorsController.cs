using Microsoft.AspNetCore.Mvc;
using soul_whisper.Helpers;
using soul_whisper.Models.Private.Enum;
using soul_whisper.Models.Public;
using soul_whisper.Models.Public.Enum;
using soul_whisper.Service;

namespace soul_whisper.Controllers;

[ApiController]
[Route("[controller]", Name = "doctors")]

public class DoctorsController : ControllerBase
{
    private readonly ILogger<DoctorsController> _logger;
    private readonly string MISSING_TOKEN = "Missing token!";
    private readonly string LOGOUT_SUCCESSFULLY = "Logout fully!";
    private readonly string LOGOUT_FAILLY = "Logout fully!";
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
    public DoctorsController(ILogger<DoctorsController> logger)
    {
        _logger = logger;
    }
    [HttpPost("login")]
    public async Task<ActionResult<BaseResponseDTO>> Login(AccountDTO account)
    {
        try
        {
            DoctorService service = new DoctorService();
            AccessRightDTO accessRight = await service.Login(account.email, account.password);
            ContainDataResponseDTO response = new ContainDataResponseDTO { data = accessRight };
            return Ok(response);
        }
        catch (Exception)
        {
            throw;
        }

    }

    [HttpPost("logout")]
    public ActionResult<BaseResponseDTO> Logout()
    {

        DoctorService service = new DoctorService();
        UserDTO user = this.ConvertAccessTokenToUserDTO();
        service.Logout(user.userId);

        return Ok(new ContainMessageResponseDTO { message = this.LOGOUT_SUCCESSFULLY });
    }
    [HttpGet]
    public async Task<ActionResult<BaseResponseDTO>> GetDoctors()
    {
        string? limit = HttpContext.Request.Query["limit"];
        UserDTO user = this.ConvertAccessTokenToUserDTO();
        var service = new DoctorService();
        List<DoctorDTO> doctors = await service.GetDoctorDTOs();
        if (user.role == UserRole.ADMIN)
        {
            if (limit != null)
            {
                return Ok(new ContainDataResponseDTO { data = doctors.Take(Int32.Parse(limit)) });
            }
            return Ok(new ContainDataResponseDTO { data = doctors });
        }
        else
        {
            if (limit != null)
            {
                return Ok(new ContainDataResponseDTO { data = doctors.Where(a => a.activationStatus == ActivationStatus.ACTIVE.ToString()).Take(Int32.Parse(limit)) });
            }
            return Ok(new ContainDataResponseDTO { data = doctors.Where(a => a.activationStatus == ActivationStatus.ACTIVE.ToString()) });
        }

    }
    [HttpPost]
    public async Task<ActionResult<BaseResponseDTO>> CreateDoctor(DoctorDTO doctor)
    {
        try
        {

            var service = new DoctorService();
            await service.Register(doctor);
            return Ok(new ContainMessageResponseDTO { message = "Created successfully" });
        }
        catch (Exception e)
        {
            throw;
        }
    }
    [HttpGet("{doctorId}")]
    public async Task<ActionResult<BaseResponseDTO>> GetDoctorByDoctorId(Guid doctorId)
    {
        try
        {
            UserDTO user = this.ConvertAccessTokenToUserDTO();
            var service = new DoctorService();
            List<DoctorDTO> ds = await service.GetDoctorDTOs();
            if (user.role == UserRole.PATIENT)
            {
                return Ok(new ContainDataResponseDTO { data = ds.FirstOrDefault(d => d.id == doctorId && d.activationStatus == "ACTIVE") });
            }
            return Ok(new ContainDataResponseDTO { data = ds.FirstOrDefault(d => d.id == doctorId) });
        }
        catch (Exception)
        {
            throw;
        }
    }
    [HttpPatch("{doctorId}")]
    public async Task<ActionResult<BaseResponseDTO>> UpdateDoctor(Guid doctorId, UpdateDoctorDTO doctor)
    {
        try
        {
            UserDTO user = this.ConvertAccessTokenToUserDTO();
            var service = new DoctorService();
            await service.UpdateDoctor(doctorId, doctor);
            if (user.role == UserRole.ADMIN)
            {
                return Ok(new ContainMessageResponseDTO { message = "Update successfully" });
            }
            else
            {
                if (doctor.activationStatus != null)
                {
                    return BadRequest(new ContainMessageResponseDTO { message = "Update fail due to you do not have permission" });
                }

                return Ok(new ContainMessageResponseDTO { message = "Update successfully" });
            }
        }
        catch (Exception)
        {
            throw;
        }
    }


}

