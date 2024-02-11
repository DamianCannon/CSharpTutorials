using System.Text.Json.Serialization;

namespace WebAPIClient
{
    public record class Repository(
        [property: JsonPropertyName("name")] string Name, 
        [property: JsonPropertyName("full_name")] string FullName,
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("html_url")] Uri GitHubHomeUrl,
        [property: JsonPropertyName("homepage")] Uri Homepage,
        [property: JsonPropertyName("watchers")] int Watchers,
        [property: JsonPropertyName("pushed_at")] DateTime LastPushUtc)
    {
        public DateTime LastPush { get; } = LastPushUtc.ToLocalTime();
    }
}
