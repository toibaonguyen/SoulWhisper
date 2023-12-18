
using Microsoft.EntityFrameworkCore;
using soul_whisper.Configs.KeyConfiguration;
using soul_whisper.Models.Private.Data;
namespace soul_whisper.Data;

public class FlatformContext : DbContext
{
    private string connectionString = DatabaseConfig.CONNECTION_STRING;

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
        base.OnConfiguring(optionsBuilder);
        // Tạo ILoggerFactory
        ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

        optionsBuilder.UseSqlServer(this.connectionString).UseLoggerFactory(loggerFactory);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Appointment>().HasOne(a=>a.diagnosis).WithOne(d=>d.appointment);
        modelBuilder.Entity<Admin>().HasIndex(a => a.email).IsUnique();
        modelBuilder.Entity<Patient>().HasIndex(a => a.email).IsUnique();
        modelBuilder.Entity<Doctor>().HasIndex(a => a.email).IsUnique();
    }

    public async Task CreateDatabase()
    {
        String databasename = Database.GetDbConnection().Database;

        Console.WriteLine("Tạo " + databasename);
        bool result = await Database.EnsureCreatedAsync();
        string resultstring = result ? "tạo  thành  công" : "đã có trước đó";
        Console.WriteLine($"CSDL {databasename} : {resultstring}");
    }
    public async Task DeleteDatabase()
    {
            String databasename = Database.GetDbConnection().Database;
            Console.Write($"Có chắc chắn xóa {databasename} (y) ? ");
             string input = Console.ReadLine();

            // // Hỏi lại cho chắc
            if (input.ToLower() == "y")
            {
                bool deleted = await Database.EnsureDeletedAsync();
                string deletionInfo = deleted ? "đã xóa" : "không xóa được";
                Console.WriteLine($"{databasename} {deletionInfo}");
            }

    }

}
