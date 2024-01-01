
using soul_whisper.Models.Public;
using soul_whisper.Models.Private.Data;

namespace soul_whisper.Helpers;



public static class ModelsConverterMachine
{
    static public PatientDTO ConvertPatientToPatientDTO(Patient patient)
    {
        return new PatientDTO
        {
            id = patient.id,
            name = patient.name,
            email = patient.email,
            password = patient.password,
            birthday = patient.birthday,
            gender = patient.gender.ToString(),
            activationStatus = patient.activationStatus.ToString(),
            bloodType = patient.bloodType

        };
    }
    static public HabitDTO ConvertHabitToHabitDTO(Habit habit)
    {
        try
        {
            Console.WriteLine($"me no chu");
            Console.WriteLine($"memaynhathglozdottnet {habit.description}");

           Console.WriteLine($"me no chu 3");
                return new HabitDTO
                {
                    id = habit.id,
                    type = habit.type.ToString(),
                    name = habit.name,
                    description = habit.description,
                    patientId = (Guid)habit.patient.id
                };
       
        }
        catch (Exception e)
        {
            Console.WriteLine($"con gai me may: {e}");
            throw;
        }
    }
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
            specialty = d.specialty.ToString(),
            wallet = d.moneyInWallet
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
    static public RatingDTO ConvertRatingToRatingDTO(Rating rating)
    {
        return new RatingDTO
        {
            id = rating.id,
            patientId = (Guid)rating.patient.id,
            doctorId = (Guid)rating.doctor.id,
            value = rating.value,
            comment = rating.comment,
            createAt = rating.createAt,
            modifiedAt = rating.modifiedAt
        };
    }
}