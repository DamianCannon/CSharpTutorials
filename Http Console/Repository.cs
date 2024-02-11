using System.Text.Json.Serialization;

namespace WebAPIClient
{
    public record class Repository([property: JsonPropertyName("name")] string Name, [property: JsonPropertyName("full_name")] string FullName);
}
