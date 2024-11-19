using MartinCostello.OpenApi;
using Microsoft.OpenApi.Any;
using System.Text.Json.Serialization;

namespace ExternalClassLibrary;

public class DynamicExampleProvider(Type modelType, Func<object?> generate)
    : IOpenApiExampleMetadata
{
    public Type ExampleType => modelType;

    public IOpenApiAny GenerateExample(JsonSerializerContext context)
    {
        var instance = generate();
        return instance == null ? new OpenApiNull() : AsJson(instance, context);
    }

    private IOpenApiAny AsJson<T>(T example, JsonSerializerContext context)
    {
        var formatterType = typeof(IOpenApiExampleMetadata).Assembly.GetType("MartinCostello.OpenApi.ExampleFormatter", true)!;
        var openAsJsonMethod = formatterType.GetMethod("AsJson")!;
        var constructedAsJsonMethod = openAsJsonMethod.MakeGenericMethod(modelType);
        var returnValue = constructedAsJsonMethod.Invoke(null, [example, context])!;
        return (IOpenApiAny)returnValue;
    }
}
