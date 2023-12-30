using Microsoft.AspNetCore.Mvc;
using soul_whisper.Helpers;
using soul_whisper.Models.Public;
using soul_whisper.Models.Public.Enum;
using soul_whisper.Service;

namespace soul_whisper.Controllers;

[ApiController]
[Route("[controller]", Name = "patient")]

public class PatientsController : ControllerBase
{
    private readonly ILogger<PatientsController> _logger;
    private readonly string LOGOUT_SUCCESSFULLY = "Logout fully!";
    private readonly string LOGOUT_FAIL = "Logout fully!";
    private readonly string MISSING_TOKEN = "Missing token!";
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
    public ActionResult<BaseResponseDTO> Logout()
    {

        PatientService service = new PatientService();
        UserDTO user = this.ConvertAccessTokenToUserDTO();
        service.Logout(user.userId);

        return Ok(new ContainMessageResponseDTO { message = this.LOGOUT_SUCCESSFULLY });
    }

    [HttpGet]
    public async Task<ActionResult<BaseResponseDTO>> GetPatients()
    {
        string? limit = HttpContext.Request.Query["limit"];
        UserDTO user = this.ConvertAccessTokenToUserDTO();
        if (user.role == UserRole.ADMIN)
        {
            PatientService service = new PatientService();
            List<PatientDTO> patients = await service.GetPatientDTOs();
            if (limit != null)
            {
                return Ok(new ContainDataResponseDTO { data = patients.Take(Int32.Parse(limit)) });
            }
            return Ok(new ContainDataResponseDTO { data = patients });
        }
        return BadRequest(new ContainMessageResponseDTO { message = "User do not have permisstion" });
    }
    [HttpPost]
    public async Task<ActionResult<BaseResponseDTO>> CreatePatient(PatientDTO patient)
    {
        PatientService service = new PatientService();
        await service.Register(patient);
        return Ok(new ContainMessageResponseDTO { message = "Created successfully" });

    }
    [HttpGet("{patientId}")]
    public async Task<ActionResult<BaseResponseDTO>> GetPatientByPatientId(Guid patientId)
    {
        PatientService service = new PatientService();
        List<PatientDTO> patients = await service.GetPatientDTOs();
        PatientDTO? p = patients.FirstOrDefault(h => h.id == patientId);
        if (p == null)
        {
            return BadRequest(new ContainMessageResponseDTO { message = "Patient is not exist" });
        }
        else
        {

            return Ok(new ContainDataResponseDTO { data = p });
        }
    }
    [HttpPatch("{patientId}")]
    public async Task<ActionResult<BaseResponseDTO>> UpdatePatient(Guid patientId, UpdatePatientDTO updatePatient)
    {
        UserDTO user = this.ConvertAccessTokenToUserDTO();
        if (user.userId == patientId)
        {
            if (updatePatient.activationStatus != null)
            {

                return BadRequest(new ContainMessageResponseDTO { message = "User do not have permisstion" });
            }
            PatientService service = new PatientService();
            await service.UpdatePatient(patientId, updatePatient);
            return Ok(new ContainMessageResponseDTO { message = "Updated successfully" });
        }
        else if (user.role == UserRole.ADMIN)
        {
            PatientService service = new PatientService();
            await service.UpdatePatient(patientId, updatePatient);
            return Ok(new ContainMessageResponseDTO { message = "Updated successfully" });
        }
        else
        {
            return BadRequest(new ContainMessageResponseDTO { message = "User do not have permisstion" });
        }
    }



}

