namespace ExternalClassLibrary;

[AttributeUsage(AttributeTargets.Property)]
public sealed class ApiExampleValueAttribute(string? value) : Attribute
{
    public string? Value { get; set; } = value;
}