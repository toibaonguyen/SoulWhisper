using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using soul_whisper.Models.Private.Enum;

namespace soul_whisper.Models.Private.Data;

[Table("Achievement")]
public class Achievement
{
    [Key]
    public required Guid id { get; set; }
    public required Doctor doctor { get; set; }
    public required ICollection<Achievement_Image> image { get; set; }
    public required AchievementType type { get; set; }
    public required string title { get; set; }
    public required string description { get; set; }
    public required DateTime dateEarned { get; set; }
    public required RegistrationStatus status { get; set; }
    [DefaultValue("GETDATE()")]
    public required DateTime createAt { get; set; }
    public required DateTime modifiedAt { get; set; }
}
