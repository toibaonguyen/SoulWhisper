
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using soul_whisper.Data;
using soul_whisper.Models.Private.Data;
using soul_whisper.Models.Public;
using soul_whisper.Helpers;
using soul_whisper.Models.Private.Enum;

namespace soul_whisper.Service;

public class AchievementService
{
    private string DOCTOR_NOT_EXIST = "This doctor is not exist";
    private string ACHIEVEMENT_NOT_EXIST = "This achievement is not exist";

    public async Task<List<AchievementDTO>> GetAchievementDTOsWithDoctorId(Guid doctorId)
    {
        try
        {
            Console.WriteLine("ME MAY CONCHO");
            using (FlatformContext context = new FlatformContext())
            {
                var doctor = await context.doctors.FirstOrDefaultAsync(d => d.id == doctorId);
                if (doctor == null)
                {
                      Console.WriteLine("ME MAY CONCHO2");
                    throw new TargetException(DOCTOR_NOT_EXIST);
                }
                List<Achievement> achievements = await context.achievements.Where(a => a.doctor == doctor).ToListAsync();
                List<AchievementDTO> publicStandardAchievements = [];
                foreach (var a in achievements)
                {
                    publicStandardAchievements.Add(ModelsConverterMachine.ConvertAchievementToAchievementDTO(a));
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
                AchievementDTO publicStandardAchievement = ModelsConverterMachine.ConvertAchievementToAchievementDTO(achievement);

                return publicStandardAchievement;
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task UpdateAchievement(Guid achievementId, UpdateAchievementDTO update)
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
                achievement.dateEarned = (DateTime)(update.dateEarned != null ? update.dateEarned : achievement.dateEarned);
                achievement.description = update.description != null ? update.description : achievement.description;
                achievement.title = update.title != null ? update.title : achievement.title;
                achievement.type = update.type != null ? (AchievementType)Enum.Parse(typeof(AchievementType), update.type) : achievement.type;
                achievement.activationStatus = update.activationStatus != null ? (ActivationStatus)Enum.Parse(typeof(ActivationStatus), update.activationStatus) : achievement.activationStatus;
                if (update.images != null)
                {
                    var achievementImages = context.achievement_images.Where(i => i.belongTo == achievement).ToList();
                    achievementImages.ForEach(i => context.achievement_images.Remove(i));
                    update.images.ForEach(i =>
                    {
                        var image = new Achievement_Image { image = i, belongTo = achievement };
                        context.achievement_images.Add(image);
                    });
                }
                context.SaveChanges();

            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    public void DeleteAchievement(Guid achievementId)
    {
        try
        {
            using (FlatformContext context = new FlatformContext())
            {
                var entityToDelete = context.achievements.FirstOrDefault(e => e.id == achievementId); // Tìm bản ghi dựa trên điều kiện

                if (entityToDelete != null)
                {
                    context.achievements.Remove(entityToDelete); // Xóa bản ghi từ DbSet
                    context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                }
                else
                {
                    throw new TargetException(ACHIEVEMENT_NOT_EXIST);
                }

            }
        }
        catch (Exception)
        {
            throw;
        }
    }
}