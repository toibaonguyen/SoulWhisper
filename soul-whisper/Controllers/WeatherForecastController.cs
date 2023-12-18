using Microsoft.AspNetCore.Mvc;

namespace soul_whisper.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase 
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet("{id}")]
    public int Get(string id,string numb)
    {
        Console.WriteLine(id);
        Console.WriteLine(numb);
        Console.WriteLine($"i'm here: {this._logger}");
        return 10;
    }
}
