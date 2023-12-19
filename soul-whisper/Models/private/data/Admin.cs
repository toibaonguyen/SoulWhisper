using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using soul_whisper.Models.Private.Enum;

namespace soul_whisper.Models.Private.Data;

[Table("Admin")]
public class Admin
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public required Guid id { get; set; }
    //unique
    public required string email { get; set; }
    public required string password { get; set; }
    public required string name { get; set; }
    public required DateOnly birthday { get; set; }
    public required Gender gender { get; set; }
    public required ActivationStatus activationStatus { get; set; }
}
