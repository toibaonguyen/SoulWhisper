using Microsoft.AspNetCore.Mvc;
using soul_whisper.Data;
using soul_whisper.Helpers;
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
    [HttpPost]
    public async Task<ActionResult<BaseResponseDTO>> CreateRatings(RatingDTO rating)
    {
        try
        {
            UserDTO user = this.ConvertAccessTokenToUserDTO();
            var service = new RatingService();
            if(user.userId!=rating.patientId)
            {
                return BadRequest(new ContainMessageResponseDTO{message="User do not has permission"});
            }
            await service.CreateRating(rating);
            return Ok(new ContainMessageResponseDTO { message = "Created successfully" });
        }
        catch (Exception)
        {
            throw;
        }
    }
    [HttpGet("{ratingId}")]
    public async Task<ActionResult<BaseResponseDTO>> GetRatingByRatingId(Guid ratingId)
    {
        try
        {
            var service = new RatingService();
           RatingDTO rating= await service.GetRatingDTOById(ratingId);
            return Ok(new ContainDataResponseDTO { data = rating });
        }
        catch (Exception)
        {
            throw;
        }
    }

    [HttpPatch("{ratingId}")]
    public async Task<ActionResult<BaseResponseDTO>> UpdateRating(Guid ratingId, UpdateRatingDTO updatePatient)
    {
   UserDTO user = this.ConvertAccessTokenToUserDTO();
        var service = new RatingService();
    using(FlatformContext context=new FlatformContext()){
        if (context.ratings.Count(r=>r.patient.id==user.userId&&r.id==ratingId)>0)
        {
            await service.UpdateRating(ratingId, updatePatient);
            return Ok(new ContainMessageResponseDTO { message = "Updated successfully" });

        }
        else
        {
            return BadRequest(new ContainMessageResponseDTO { message = "You do not have permission" });
        }
    }}



}

