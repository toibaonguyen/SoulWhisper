using Microsoft.AspNetCore.Mvc;
using soul_whisper.Helpers;
using soul_whisper.Models.Private.Business.Patient;
using soul_whisper.Models.Public;
using soul_whisper.Service;

namespace soul_whisper.Controllers;

[ApiController]
[Route("[controller]", Name = "patient")]

public class PatientsController : ControllerBase
{
    private readonly ILogger<PatientsController> _logger;
    private readonly string LOGOUT_SUCCESSFULLY = "Logout fully!";
    private readonly string LOGOUT_FAIL = "Logout fully!";

    public PatientsController(ILogger<PatientsController> logger)
    {
        _logger = logger;
    }
    [HttpPost("login")]
    public async Task<ActionResult<BaseResponseDTO>> Login(AccountDTO account)
    {
        try
        {
            PatientService service = new PatientService();
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
            throw new UnauthorizedAccessException(this.LOGOUT_FAIL);
        }
        PatientService service = new PatientService();

        var myMachine = new TokenConverterMachine();
        UserDTO user = myMachine.ConvertAccessTokenToUserDTO(authHeaderValue);
        await service.Logout(user.userId);

        return Ok(new ContainMessageResponseDTO { message = this.LOGOUT_SUCCESSFULLY });
    }

    [HttpGet]
    public async Task<ActionResult<BaseResponseDTO>> GetPatienta()
    {
        string? limit = HttpContext.Request.Query["limit"];
    }
    [HttpPost]
    public async Task<ActionResult<BaseResponseDTO>> CreatePatient(PatientDTO patient)
    {

    }
    [HttpGet("{patientId}")]
    public async Task<ActionResult<BaseResponseDTO>> GetPatientByPatientId(Guid patientId)
    {

    }
    [HttpPatch("{patientId}")]
    public async Task<ActionResult<BaseResponseDTO>> UpdatePatient(Guid patientId, UpdatePatientDTO updatePatient)
    {

    }



}

