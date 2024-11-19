using ExternalClassLibrary;

namespace WebApi;

/// <summary>
/// Provides details about an individual weather forecast.
/// </summary>
public class WeatherForecast
{
    /// <summary>
    /// Gets or sets the identity of this forecast.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets the date this forecast applies to.
    /// </summary>
    [ApiExampleValue("2024-01-01")]
    public DateOnly Date { get; set; }

    /// <summary>
    /// Gets or sets the temperature, in degrees celsius.
    /// </summary>
    [ApiExampleValue("-5")]
    public int TemperatureC { get; set; }

    /// <summary>
    /// Gets or sets the temperature, in degrees fahrenheit.
    /// </summary>
    [ApiExampleValue("24")]
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    /// <summary>
    /// Gets or sets a human-readable forecast description.
    /// </summary>
    [ApiExampleValue("Freezing")]
    public string? Summary { get; set; }
}
