using System.Security.Authentication;
using Microsoft.EntityFrameworkCore;
using soul_whisper.Configs;
using soul_whisper.Data;
using soul_whisper.Helpers.TokenFactory;
using soul_whisper.Helpers;
using soul_whisper.Models.Private.Business.Token;
using soul_whisper.Models.Private.Enum;
using soul_whisper.Models.Public;
using soul_whisper.Models.Public.Enum;
using soul_whisper.Models.Private.Data;
using System.Reflection;

namespace soul_whisper.Service;
public class RatingService
{
    public async Task CreateRating(RatingDTO rating)
    {
        try
        {
            using (FlatformContext context = new FlatformContext())
            {
                var patient = await context.patients.FirstOrDefaultAsync(i => i.id == rating.patientId);
                var doctor = await context.doctors.FirstOrDefaultAsync(i => i.id == rating.doctorId);
                if (patient == null)
                {
                    throw new HttpRequestException("Patient is not exist");
                }
                if (doctor == null)
                {
                    throw new HttpRequestException("Doctor is not exist");
                }
                await context.ratings.AddAsync(new Rating
                {
                    patient = patient,
                    doctor = doctor,
                    value = rating.value,
                    comment = rating.comment,
                    createAt = DateTime.Now,
                    modifiedAt = null
                });
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task<RatingDTO> GetRatingDTOById(Guid ratingId)
    {
        try
        {
            using (FlatformContext context = new FlatformContext())
            {
                var rating = await context.ratings.FirstOrDefaultAsync(i => i.id == ratingId);
                if (rating == null)
                {
                    throw new HttpRequestException("This rating is not exist");
                }
                return ModelsConverterMachine.ConvertRatingToRatingDTO(rating);

            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task UpdateRating(Guid ratingId, UpdateRatingDTO update)
    {
        try
        {
            using (FlatformContext context = new FlatformContext())
            {

                var rating=await context.ratings.FirstOrDefaultAsync(p=> p.id == ratingId);
                if (rating!=null)
                {
                    rating.value=update.value;
                    rating.comment=update.comment;
                    context.SaveChanges();
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
}