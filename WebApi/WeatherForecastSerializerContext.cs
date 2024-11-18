using System.Text.Json.Serialization;

namespace WebApi;

/// <summary/>
[JsonSerializable(typeof(WeatherForecast))]
[JsonSourceGenerationOptions(
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase,
    WriteIndented = true)]
public partial class WeatherForecastSerializerContext : JsonSerializerContext;
