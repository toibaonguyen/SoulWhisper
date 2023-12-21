using Microsoft.AspNetCore.Mvc;
using soul_whisper.Helpers;
using soul_whisper.Models.Private.Business.Patient;
using soul_whisper.Models.Public;
using soul_whisper.Service;

namespace soul_whisper.Controllers;

[ApiController]
[Route("[controller]", Name = "rules")]

public class RulesController : ControllerBase
{    private readonly string MISSING_TOKEN = "Missing token!";
    private readonly ILogger<RulesController> _logger;
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
    public RulesController(ILogger<RulesController> logger)
    {
        _logger = logger;
    }
    // [HttpGet]
    // public async Task<ActionResult<BaseResponseDTO>> GetRules()
    // {
    //     string? limit = HttpContext.Request.Query["limit"];
    // }
    // [HttpPost]
    // public async Task<ActionResult<BaseResponseDTO>> CreateRules(RuleDTO rule)
    // {

    // }
    // [HttpGet("{ruleId}")]
    // public async Task<ActionResult<BaseResponseDTO>> GetRuleByRuleId(Guid ruleId)
    // {

    // }
    // [HttpPatch("{ruleId}")]
    // public async Task<ActionResult<BaseResponseDTO>> UpdateRule(Guid ruleId, UpdateRuleDTO updatePatient)
    // {

    // }
    //    [HttpDelete("{ruleId}")]
    // public async Task<ActionResult<BaseResponseDTO>> DeleteRule(Guid ruleId)
    // {

    // }



}

