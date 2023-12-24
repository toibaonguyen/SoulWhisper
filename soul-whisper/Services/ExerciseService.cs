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
public class ExerciseService
{
    public async Task DeleteExercise(Guid exerciseId)
    {
try
        {
            using (FlatformContext context = new FlatformContext())
            {
                var ex=await context.exercises.FirstOrDefaultAsync(e=>e.id==exerciseId);
                if(ex==null)
                {
                    throw new BadHttpRequestException("Exercises is not exist!");
                }
                  context.exercises.Remove(ex);
                  context.SaveChanges();
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task<List<ExerciseDTO>> GetExerciseDTOs()
    {
        try
        {
            using (FlatformContext context = new FlatformContext())
            {
                var ds = await context.exercises.ToListAsync();
                List<ExerciseDTO> publicStandardDs = [];
                ds.ForEach(a =>
                {
                    publicStandardDs.Add(ModelsConverterMachine.ConvertExerciseToExerciseDTO(a));
                });
                return publicStandardDs;
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task UpdateExercise(Guid exerciseId, UpdateExerciseDTO update)
    {
        try
        {
            using (FlatformContext context = new FlatformContext())
            {
                var exercise = await context.exercises.FirstOrDefaultAsync();
                if (exercise != null)
                {
                    exercise.name = update.name ?? exercise.name;
                    exercise.type = update.type != null ? (ExerciseType)Enum.Parse(typeof(ExerciseType), update.type) : exercise.type;
                    exercise.description = update.description ?? exercise.description;
                    exercise.duration = update.duration ?? exercise.duration;
                    context.SaveChanges();
                }
                else
                {
                    throw new HttpRequestException("exercise is not exist");
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task CreateExercise(ExerciseDTO exercise)
    {
        try
        {
            using (FlatformContext context = new FlatformContext())
            {
                await context.exercises.AddAsync(new Exercise
                {
                    name = exercise.name,
                    type = (ExerciseType)Enum.Parse(typeof(ExerciseType), exercise.type),
                    description = exercise.description,
                    duration = exercise.duration
                });
                context.SaveChanges();
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

}