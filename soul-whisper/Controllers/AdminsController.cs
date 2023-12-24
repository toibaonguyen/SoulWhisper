using Microsoft.AspNetCore.Mvc;
using soul_whisper.Helpers;
using soul_whisper.Models.Private.Enum;
using soul_whisper.Models.Public;
using soul_whisper.Models.Public.Enum;
using soul_whisper.Service;

namespace soul_whisper.Controllers;

[ApiController]
[Route("[controller]", Name = "admins")]

public class AdminsController : ControllerBase
{
    private readonly ILogger<AdminsController> _logger;
    private readonly string LOGOUT_SUCCESSFULLY = "Logout successfully!";
    private readonly string MISSING_TOKEN = "Missing token!";
    private readonly string UPDATE_SUCCESSFULLY = "Updated successfully!";
    private readonly string DELETE_SUCCESSFULLY = "Deleted successfully!";
    private readonly string DO_NOT_HAVE_PERMISSION = "Do not permission";
    private readonly string CREATED_SUCCESSFULLY = "Created successfully";

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
    // [HttpPost("refreshToken")]
    // public ActionResult<BaseResponseDTO> refreshToken()
    // {
    //     UserDTO user = this.ConvertAccessTokenToUserDTO();
    //     var adminService = new AdminService();
    //     adminService.Logout(user.userId);
    //     return Ok(new ContainMessageResponseDTO { message = this.LOGOUT_SUCCESSFULLY });
    // }
    [HttpPost("logout")]
    public ActionResult<BaseResponseDTO> Logout()
    {

        UserDTO user = this.ConvertAccessTokenToUserDTO();
        var adminService = new AdminService();
        adminService.Logout(user.userId);
        return Ok(new ContainMessageResponseDTO { message = this.LOGOUT_SUCCESSFULLY });
    }
    [HttpGet("{adminId}")]
    public async Task<ActionResult<BaseResponseDTO>> GetAdminById(Guid adminId)
    {
        var service = new AdminService();
        AdminDTO admin = await service.GetAdminDTOById(adminId);
        return Ok(new ContainDataResponseDTO { data = admin });
    }
    [HttpGet]
    public async Task<ActionResult<BaseResponseDTO>> GetAdmins()
    {
        string? limit = HttpContext.Request.Query["limit"];
        UserDTO user = this.ConvertAccessTokenToUserDTO();
        var service = new AdminService();
        List<AdminDTO> admins = await service.GetAdminDTOs();
        if (user.role == UserRole.ADMIN)
        {
            if (limit != null)
            {
                return Ok(new ContainDataResponseDTO { data = admins.Take(Int32.Parse(limit)) });
            }
            return Ok(new ContainDataResponseDTO { data = admins });
        }
        else
        {
            if (limit != null)
            {
                return Ok(new ContainDataResponseDTO { data = admins.Where(a => a.activationStatus == ActivationStatus.ACTIVE.ToString()).Take(Int32.Parse(limit)) });
            }
            return Ok(new ContainDataResponseDTO { data = admins.Where(a => a.activationStatus == ActivationStatus.ACTIVE.ToString()) });
        }
    }
    [HttpPost]
    public async Task<ActionResult<BaseResponseDTO>> CreateAdmin(AdminDTO admin)
    {
        UserDTO user = this.ConvertAccessTokenToUserDTO();
        if (user.role == UserRole.ADMIN)
        {
            var service = new AdminService();
            await service.Register(admin);
            return Ok(new ContainMessageResponseDTO { message = CREATED_SUCCESSFULLY });
        }
        else
        {
            return BadRequest(new ContainMessageResponseDTO { message = this.DO_NOT_HAVE_PERMISSION });
        }

    }
    [HttpPatch("{adminId}")]
    public async Task<ActionResult<BaseResponseDTO>> UpdateAdmin(Guid adminId, UpdateAdminDTO update)
    {
        var service = new AdminService();
        UserDTO user = this.ConvertAccessTokenToUserDTO();
        if (user.role != UserRole.ADMIN)
        {
            throw new InvalidOperationException(DO_NOT_HAVE_PERMISSION);
        }
        await service.UpdateAdmin(adminId, update);
        return Ok(new ContainMessageResponseDTO { message = UPDATE_SUCCESSFULLY });
    }

}

