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
public class HabitService
{
    public async Task DeleteHabit(Guid habitId)
    {
        try
        {
            using (FlatformContext context = new FlatformContext())
            {
                var ex = await context.habits.FirstOrDefaultAsync(e => e.id == habitId);
                if (ex == null)
                {
                    throw new BadHttpRequestException("Habit is not exist!");
                }
                context.habits.Remove(ex);
                context.SaveChanges();
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task<List<HabitDTO>> GetHabitDTOs()
    {
        try
        {
            using (FlatformContext context = new FlatformContext())
            {
                var ds = await context.habits.ToListAsync();
                List<HabitDTO> publicStandardDs = [];
                ds.ForEach(a =>
                {
                    publicStandardDs.Add(ModelsConverterMachine.ConvertHabitToHabitDTO(a));
                });
                return publicStandardDs;
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task UpdateHabit(Guid exerciseId, UpdateHabitDTO update)
    {
        try
        {
            using (FlatformContext context = new FlatformContext())
            {
                var habit = await context.habits.FirstOrDefaultAsync();
                if (habit != null)
                {
                    habit.name = update.name ?? habit.name;
                    habit.type = update.type != null ? (HabitType)Enum.Parse(typeof(HabitType), update.type) : habit.type;
                    habit.description = update.description ?? habit.description;
                }
                else
                {
                    throw new HttpRequestException("habit is not exist");
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task CreateHabit(HabitDTO habit)
    {
        try
        {
            using (FlatformContext context = new FlatformContext())
            {
                var patient=await context.patients.FirstOrDefaultAsync(e=>e.id==habit.patientId);
                if(patient==null)
                {
                    throw new HttpRequestException("Patient is not exist");
                }
                else{
                await context.habits.AddAsync(new Habit
                {
                    name = habit.name,
                    type = (HabitType)Enum.Parse(typeof(HabitType), habit.type),
                    description = habit.description,
                    patient = patient
                });
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