using MartinCostello.OpenApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ExternalClassLibrary;

public static class Extensions
{
    public static IServiceCollection AddOpenApiExamplesFromDbContext<TDbContext>(this IServiceCollection services)
        where TDbContext : DbContext
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddOptions<OpenApiExtensionsOptions>().Configure<IServiceProvider>((options, serviceProvider) =>
        {
            options.AddExamples = true;

            using var serviceScope = serviceProvider.CreateScope();
            var dbContext = serviceScope.ServiceProvider.GetRequiredService<TDbContext>();

            foreach (var entityType in dbContext.Model.GetEntityTypes())
            {
                options.ExamplesMetadata.Add(new EntityExampleProvider(entityType));
            }
        });

        return services;
    }

    public static IServiceCollection AddOpenApiDescriptionEnrichment(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddOptions<OpenApiExtensionsOptions>().Configure(options =>
        {
            options.DescriptionTransformations.Clear();
            options.DescriptionTransformations.Add(description =>
            {
                // If we had more context here, we could do the enhancements from
                // https://github.com/dotnet/aspnetcore/issues/39927#issuecomment-2287762082.
                return description.ToUpperInvariant();
            });
        });

        return services;
    }
}
