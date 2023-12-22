

using System.Reflection;
using Microsoft.EntityFrameworkCore;
using soul_whisper.Data;
using soul_whisper.Helpers;
using soul_whisper.Models.Private.Enum;
using soul_whisper.Models.Public;

namespace soul_whisper.Service;

public class AppointmentService
{
    public async Task<List<AppointmentDTO>> GetAppointmentDTOs()
    {
        try
        {
            using (FlatformContext context = new FlatformContext())
            {
                var appointments = await context.appointments.ToListAsync();
                List<AppointmentDTO> publicStandardAppointments = [];
                appointments.ForEach(a =>
                {
                    publicStandardAppointments.Add(ModelsConverterMachine.ConvertAppointmentToAppointmentDTO(a));
                });
                return publicStandardAppointments;
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task UpdateAppointment(Guid appointmentId, UpdateAppointmentDTO update)
    {
        try
        {
            using (FlatformContext context = new FlatformContext())
            {
                var appointment = await context.appointments.FirstOrDefaultAsync(a => a.id == appointmentId);
                if (appointment == null)
                {
                    throw new TargetException("Appointment is not exist");
                }
                appointment.type = update.type != null ? (AppointmentType)Enum.Parse(typeof(AppointmentType), update.type) : appointment.type;
                appointment.diagnosis = update.diagnosis != null ? update.diagnosis : appointment.diagnosis;
                appointment.prescription = update.prescription != null ? update.prescription : appointment.prescription;
                appointment.notes = update.notes != null ? update.notes : appointment.notes;
                appointment.status = update.status != null ? (AppoinmentStatus)Enum.Parse(typeof(AppoinmentStatus), update.status) : appointment.status;
                context.SaveChanges();

            }
        }
        catch (Exception)
        {
            throw;
        }
    }
}