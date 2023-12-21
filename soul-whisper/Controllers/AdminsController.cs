using Microsoft.AspNetCore.Mvc;
using soul_whisper.Helpers;
using soul_whisper.Models.Public;
using soul_whisper.Service;

namespace soul_whisper.Controllers;

[ApiController]
[Route("[controller]", Name = "admins")]

public class AdminsController : ControllerBase
{
    private readonly ILogger<AdminsController> _logger;
    private readonly string MISSING_TOKEN = "Missing token!";
    private readonly string LOGOUT_SUCCESSFULLY = "Logout successfully!";

    public AdminsController(ILogger<AdminsController> logger)
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
    [HttpPost("login")]
    public async Task<ActionResult<BaseResponseDTO>> Login(AccountDTO account)
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
    [HttpPost("logout")]
    public async Task<ActionResult<BaseResponseDTO>> Logout()
    {

        UserDTO user = this.ConvertAccessTokenToUserDTO();
        var adminService = new AdminService();
        await adminService.Logout(user.userId);
        return Ok(new ContainMessageResponseDTO { message = this.LOGOUT_SUCCESSFULLY });
    }
    // [HttpGet("{adminId}")]
    // public async Task<ActionResult<BaseResponseDTO>> GetAdminById(Guid adminId)
    // {

    // }
    // [HttpGet]
    // public async Task<ActionResult<BaseResponseDTO>> GetAdmins()
    // {
    //     string? limit = HttpContext.Request.Query["limit"];
    // }
    // [HttpPost]
    // public async Task<ActionResult<BaseResponseDTO>> CreateAdmin(AdminDTO admin)
    // {

    // }
    // [HttpPatch("{adminId}")]
    // public async Task<ActionResult<BaseResponseDTO>> UpdateAdmin(Guid adminId, UpdateAdminDTO admin)
    // {

    // }

}

