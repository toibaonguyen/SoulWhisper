using Microsoft.AspNetCore.Mvc;
using soul_whisper.Helpers;
using soul_whisper.Models.Public;
using soul_whisper.Service;

namespace soul_whisper.Controllers;

[ApiController]
[Route("[controller]", Name = "doctors")]

public class DoctorsController : ControllerBase
{
    private readonly ILogger<DoctorsController> _logger;
    private readonly string LOGOUT_SUCCESSFULLY = "Logout fully!";
    private readonly string LOGOUT_FAILLY = "Logout fully!";

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
    public async Task<ActionResult<BaseResponseDTO>> Logout()
    {
        string? authHeaderValue = HttpContext.Request.Headers["Authorization"];
        if (String.IsNullOrEmpty(authHeaderValue))
        {
            throw new UnauthorizedAccessException(this.LOGOUT_FAILLY);
        }
        DoctorService service = new DoctorService();

        var myMachine = new TokenConverterMachine();
        UserDTO user = myMachine.ConvertAccessTokenToUserDTO(authHeaderValue);
        await service.Logout(user.userId);

        return Ok(new ContainMessageResponseDTO { message = this.LOGOUT_SUCCESSFULLY });
    }
    [HttpGet]
    public async Task<ActionResult<BaseResponseDTO>> GetDoctors()
    {
        string? limit = HttpContext.Request.Query["limit"];
    }
    [HttpPost]
    public async Task<ActionResult<BaseResponseDTO>> CreateDoctor(DoctorDTO doctor)
    {

    }
    [HttpGet("{doctorId}")]
    public async Task<ActionResult<BaseResponseDTO>> GetDoctorByDoctorId(Guid doctorId)
    {

    }
    [HttpPut("{doctorId}")]
    public async Task<ActionResult<BaseResponseDTO>> SetDoctor(Guid doctorId, DoctorDTO doctor)
    {

    }
    [HttpPatch("{doctorId}")]
    public async Task<ActionResult<BaseResponseDTO>> UpdateDoctor(Guid doctorId, UpdateDoctorDTO doctor)
    {

    }


}

