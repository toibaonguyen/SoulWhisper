
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
        return new AdminDTO { id = admin.id, email = admin.email, password = admin.password, name = admin.name, birthday = admin.birthday, gender = admin.gender.ToString() };
    }
    static public AppointmentDTO ConvertAppointmentToAppointmentDTO(Appointment appointment)
    {
        return new AppointmentDTO
        {
            id = appointment.id,
            type = appointment.type.ToString(),
            startTime = appointment.startTime,
            endTime = appointment.endTime,
            diagnosis = appointment.diagnosis,
            prescription = appointment.prescription,
            notes = appointment.notes,
            doctorId = (Guid)appointment.doctor.id,
            patientId = (Guid)appointment.patient.id,
            status = appointment.status.ToString()
        };
    }
    static public DoctorDTO ConvertDoctorToDoctorDTO(Doctor d)
    {
        return new DoctorDTO
        {
            id = d.id,
            email = d.email,
            password = d.password,
            name = d.name,
            avatar = d.avatar,
            birthday = d.birthday,
            gender = d.gender.ToString(),
            activationStatus = d.activationStatus.ToString(),
            specialty = d.specialty.ToString()
        };
    }
    static public ExerciseDTO ConvertExerciseToExerciseDTO(Exercise exercise)
    {
        return new ExerciseDTO
        {
            id = exercise.id,
            type = exercise.type.ToString(),
            name = exercise.name,
            description = exercise.description,
            duration = exercise.duration
        };
    }
}