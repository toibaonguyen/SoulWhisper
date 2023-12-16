using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using soul_whisper.Models.Private.Enum;

namespace soul_whisper.Models.Private.Data;

public class Achievement
{
    public required string id { get; set; }
    public required Doctor doctor{get;set;}
    public required string image { get; set; }
    public required AchievementType type { get; set; }
    public required string title { get; set; }
    public required string description { get; set; }
    public required DateTime DateEarned { get; set; }
    public required RegistrationStatus Status { get; set; }
    public required DateTime createAt{get;set;}
    public required DateTime modifiedAt{get;set;}
}
