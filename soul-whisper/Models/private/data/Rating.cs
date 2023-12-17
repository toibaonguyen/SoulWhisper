using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using soul_whisper.Models.Private.Enum;

namespace soul_whisper.Models.Private.Data;

public class Rating
{
    [Key]

    public required Patient patient{get;set;}
        [Key]

    public required Doctor doctor{get;set;}
    public required int value{get;set;}
    public required string comment{get;set;}
    public required DateTime createAt{get;set;}
    public  DateTime? modifiedAt{get;set;}
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      