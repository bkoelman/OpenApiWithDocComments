using Microsoft.EntityFrameworkCore;

namespace WebApi;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<WeatherForecast> WeatherForecasts => Set<WeatherForecast>();
}
