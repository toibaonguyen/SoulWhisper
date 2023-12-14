

namespace soul_whisper.Models.Private.Business.Exercise;


using soul_whisper.Models.Private.Business.User;
public abstract class Exercise
{
    public string name { get; set; }
    public string description { get; set; }
    public User author { get; set; }
    protected Exercise(string name, string description, User author)
    {
        this.name = name;
        this.description = description;
        this.author = author;
    }
}