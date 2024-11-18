using MartinCostello.OpenApi;

namespace WebApi;

/// <summary>
/// Provides details about an individual weather forecast.
/// </summary>
[OpenApiExample<WeatherForecast>]
public class WeatherForecast : IExampleProvider<WeatherForecast>
{
    /// <summary>
    /// Gets or sets the date this forecast applies to.
    /// </summary>
    public DateOnly Date { get; set; }

    /// <summary>
    /// Gets or sets the temperature, in degrees celsius.
    /// </summary>
    public int TemperatureC { get; set; }

    /// <summary>
    /// Gets or sets the temperature, in degrees fahrenheit.
    /// </summary>
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    /// <summary>
    /// Gets or sets a human-readable forecast description.
    /// </summary>
    public string? Summary { get; set; }

    /// <summary/>
    public static WeatherForecast GenerateExample()
    {
        return new WeatherForecast
        {
            Summary = "Freezing",
            Date = DateOnly.FromDateTime(DateTime.Today),
            TemperatureC = -5
        };
    }
}
