using Microsoft.AspNetCore.Mvc;
using soul_whisper.Helpers;
using soul_whisper.Models.Public;
using soul_whisper.Service;

namespace soul_whisper.Controllers;

[ApiController]
[Route("[controller]", Name = "patient")]

public class PatientController : ControllerBase
{
    private readonly ILogger<PatientController> _logger;
    private readonly string LOGOUT_SUCCESSFULLY = "Logout fully!";
    private readonly string LOGOUT_FAILLY = "Logout fully!";

    public PatientController(ILogger<PatientController> logger)
    {
        _logger = logger;
    }
    [HttpPost("login")]
    public async Task<ActionResult<BaseResponseDTO>> Login(LoginRequestDTO account)
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
        string authHeaderValue = HttpContext.Request.Headers["Authorization"];
        if (String.IsNullOrEmpty(authHeaderValue))
        {
            throw new UnauthorizedAccessException(this.LOGOUT_FAILLY);
        }
        PatientService service = new PatientService();

        var myMachine = new TokenConverterMachine();
        UserDTO user = myMachine.ConvertAccessTokenToUserDTO(authHeaderValue);
        await service.Logout(user.userId);

        return Ok(new ContainMessageResponse { message = this.LOGOUT_SUCCESSFULLY });
    }
}

