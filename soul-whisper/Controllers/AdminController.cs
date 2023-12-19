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
    [HttpPost("/logout")]
    public ActionResult<bool> test()
    {
        string authHeaderValue = HttpContext.Request.Headers["Authorization"];
        if (String.IsNullOrEmpty(authHeaderValue))
        {
            Console.WriteLine("Token is empty!");
            throw new Exception("MET QUA NHA");
        }
        var myMachine = new TokenConverterMachine();
        return myMachine.ConvertAccessTokenToUserDTO(authHeaderValue);
    }

    public AdminController(ILogger<AdminController> logger)
    {
        _logger = logger;
    }
    [HttpPost("/login")]
    public async Task<IActionResult> Login(LoginRequestDTO account)
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

