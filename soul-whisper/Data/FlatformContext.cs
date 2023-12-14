
using Microsoft.EntityFrameworkCore;
using soul_whisper.Models.Private.Data;
namespace soul_whisper.Data;

public class FlatformContext : DbContext
{
    public FlatformContext(DbContextOptions<FlatformContext> options) : base(options)
    {
    }
    public DbSet<Patient> patients { get; set; } = null!;
    public DbSet<Doctor> doctors {get;set;}=null!;
    public DbSet<Admin> admins {get;set;}=null!;
    
}