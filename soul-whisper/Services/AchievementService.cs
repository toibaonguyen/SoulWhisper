
using System.Reflection;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using soul_whisper.Data;
using soul_whisper.Models.Private.Data;
using soul_whisper.Models.Public;

namespace soul_whisper.Service;

public class AchievementService
{
    private string DOCTOR_NOT_EXIST = "This doctor is not exist";
    private string ACHIEVEMENT_NOT_EXIST="This achievement is not exist";
    private AchievementDTO ConvertAchievementToAchievementDTO(Achievement achievement)
    {

        List<Achievement_Image> achievementImages = achievement.images.ToList();
        List<string> achievementImageMatchDatas = [];
        foreach (var image in achievementImages)
        {
            achievementImageMatchDatas.Add(image.image);
        }

        return new AchievementDTO
        {
            id = achievement.id,
            images = achievementImageMatchDatas,
            type = achievement.type.ToString(),
            title = achievement.title,
            description = achievement.description,
            dateEarned = achievement.dateEarned,
            activationStatus = achievement.activationStatus.ToString()
        };

    }
    public async Task<List<AchievementDTO>> GetAchievementDTOsWithDoctorId(Guid doctorId)
    {
        try
        {
            using (FlatformContext context = new FlatformContext())
            {
                var doctor = await context.doctors.FirstOrDefaultAsync(d => d.id == doctorId);
                if (doctor == null)
                {
                    throw new TargetException(DOCTOR_NOT_EXIST);
                }
                List<Achievement> achievements = await context.achievements.Where(a => a.doctor == doctor).ToListAsync();
                List<AchievementDTO> publicStandardAchievements = [];
                foreach (var a in achievements)
                {
                    publicStandardAchievements.Add(ConvertAchievementToAchievementDTO(a));
                }
                return publicStandardAchievements;
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task<AchievementDTO> GetAchievementDTOById(Guid achievementId)
    {
        try
        {
            using (FlatformContext context = new FlatformContext())
            {
                var achievement = await context.achievements.FirstOrDefaultAsync(a => a.id == achievementId);
                if (achievement == null)
                {
                    throw new TargetException(ACHIEVEMENT_NOT_EXIST);
                }
                AchievementDTO publicStandardAchievement = ConvertAchievementToAchievementDTO(achievement);
                
                return publicStandardAchievement;
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
}