using Microsoft.AspNetCore.Mvc;
using soul_whisper.Helpers;
using soul_whisper.Models.Public;
using soul_whisper.Service;

namespace soul_whisper.Controllers;

[ApiController]
[Route("[controller]", Name = "admin")]

public class AdminController : ControllerBase
{
    private readonly ILogger<AdminController> _logger;
    private readonly string LOGOUT_SUCCESSFULLY="Logout fully!";
    private readonly string LOGOUT_FAILLY="Logout fully!";
    [HttpPost("/logout")]
    public async Task<ActionResult<BaseResponseDTO>> test()
    {
        string authHeaderValue = HttpContext.Request.Headers["Authorization"];
        if (String.IsNullOrEmpty(authHeaderValue))
        {
            throw new UnauthorizedAccessException(this.LOGOUT_FAILLY);
        }
        var adminService = new AdminService();

        var myMachine = new TokenConverterMachine();
        UserDTO user = myMachine.ConvertAccessTokenToUserDTO(authHeaderValue);
        await adminService.Logout(user.userId);

        return  Ok(new ContainMessageResponse{message=this.LOGOUT_SUCCESSFULLY});
    }

    public AdminController(ILogger<AdminController> logger)
    {
        _logger = logger;
    }
    [HttpPost("/login")]
    public async Task<ActionResult<BaseResponseDTO>> Login(LoginRequestDTO account)
    {
        try
        {
            AdminService service = new AdminService();
            AccessRightDTO accessRight = await service.Login(account.email, account.password);
            ContainDataResponseDTO response = new ContainDataResponseDTO { data = accessRight };
            return Ok(response);
        }
        catch (Exception)
        {
            throw;
        }

    }
}

