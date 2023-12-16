
using Microsoft.EntityFrameworkCore;
using soul_whisper.Models.Private.Data;
namespace soul_whisper.Data;

public class FlatformContext : DbContext
{
    public DbSet<Achievement_Image> achievement_images { get; set; }
    public DbSet<Achievement> achievements { get; set; }
    public DbSet<Admin> admins { get; set; }
    public DbSet<Appointment> appointments { get; set; }
    public DbSet<Diagnosis> diagnoses { get; set; }
    public DbSet<Doctor> doctors { get; set; }
    public DbSet<Doctorship_Registration> doctorship_registrations { get; set; }
    public DbSet<Exercise> exercises { get; set; }
    public DbSet<Habit> habits { get; set; }
    public DbSet<Patient_Doctor_Registration> patient_doctor_registrations { get; set; }
    public DbSet<Patient> patients { get; set; }
    public DbSet<Rating> ratings { get; set; }
    public DbSet<Receipt> receipts { get; set; }
    public DbSet<Rule> rules { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True");
    }

}