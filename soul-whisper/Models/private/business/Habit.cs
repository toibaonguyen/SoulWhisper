namespace soul_whisper.Models.Private.Business.Habit;

public abstract class Habit
{
    public string name {get;set;}
    public string description {get; set;}

    protected Habit(string name, string description)
    {
        this.name=name;
        this.description=description;
    }
}
