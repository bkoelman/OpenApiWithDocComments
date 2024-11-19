using System.Reflection;
using MartinCostello.OpenApi;
using Microsoft.OpenApi.Any;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ExternalClassLibrary;

internal sealed class EntityExampleProvider(IEntityType entityType) : IOpenApiExampleMetadata
{
    public Type ExampleType => entityType.ClrType;

    public IOpenApiAny GenerateExample(JsonSerializerContext context)
    {
        var result = new OpenApiObject();

        foreach (var property in entityType.ClrType.GetProperties())
        {
            var attribute = property.GetCustomAttribute<ApiExampleValueAttribute>();
            if (attribute?.Value != null)
            {
                // This is where we'd do the enhancements mentioned in
                // https://github.com/dotnet/aspnetcore/issues/39927#issuecomment-2287762082.

                result.Add(property.Name, new OpenApiString(EnrichExampleValue(attribute.Value)));
            }
        }

        return result.Count > 0 ? result : new OpenApiNull();
    }

    private static string EnrichExampleValue(string attributeValue)
    {
        return attributeValue.ToUpperInvariant();
    }
}