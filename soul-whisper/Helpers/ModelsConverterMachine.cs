
using soul_whisper.Models.Public;
using soul_whisper.Models.Private.Data;

namespace soul_whisper.Helpers;



public static class ModelsConverterMachine
{
    static public AchievementDTO ConvertAchievementToAchievementDTO(Achievement achievement)
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
    static public AdminDTO ConvertAdminToAdminDTO(Admin admin)
    {
        return new AdminDTO{id=admin.id,email=admin.email,password=admin.password,name=admin.name,birthday=admin.birthday,gender=admin.gender.ToString()};
    }

}