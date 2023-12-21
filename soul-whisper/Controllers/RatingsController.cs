using Microsoft.AspNetCore.Mvc;
using soul_whisper.Helpers;
using soul_whisper.Models.Private.Business.Patient;
using soul_whisper.Models.Public;
using soul_whisper.Service;

namespace soul_whisper.Controllers;

[ApiController]
[Route("[controller]", Name = "ratings")]

public class RatingsController : ControllerBase
{
    private readonly ILogger<RatingsController> _logger;
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
    public RatingsController(ILogger<RatingsController> logger)
    {
        _logger = logger;
    }
    // [HttpGet]
    // public async Task<ActionResult<BaseResponseDTO>> GetRatings()
    // {
    //     string? limit = HttpContext.Request.Query["limit"];
    // }
    // [HttpPost]
    // public async Task<ActionResult<BaseResponseDTO>> CreateRatings(RatingDTO rating)
    // {
        
    // }
    // [HttpGet("{ratingId}")]
    // public async Task<ActionResult<BaseResponseDTO>> GetRatingByRatingId(Guid ratingId)
    // {

    // }

    // [HttpPatch("{ratingId}")]
    // public async Task<ActionResult<BaseResponseDTO>> UpdateRating(Guid ratingId, UpdateRatingDTO updatePatient)
    // {

    // }



}

