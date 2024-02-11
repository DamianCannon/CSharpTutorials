using System.Net.Http.Headers;
using System.Text.Json;
using WebAPIClient;
internal class Program
{
    private static async Task Main(string[] args)
    {
        using (HttpClient client = new())
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var repositories = await ProcessRepositoriesAsync(client);
            foreach (var repo in repositories ?? Enumerable.Empty<Repository>())
            {
                Console.WriteLine($"Name: {repo.Name}");
                Console.WriteLine($"Full Name: {repo.FullName}");
                Console.WriteLine($"Homepage: {repo.Homepage}");
                Console.WriteLine($"GitHub: {repo.GitHubHomeUrl}");
                Console.WriteLine($"Description: {repo.Description}");
                Console.WriteLine($"Watchers: {repo.Watchers:#,0}");
                Console.WriteLine($"Last Push: {repo.LastPush}");
                Console.WriteLine();
            }
        }
    }

    static async Task<List<Repository>> ProcessRepositoriesAsync(HttpClient client)
    {
        using (var stream = await client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos"))
        {
            var repositories = await JsonSerializer.DeserializeAsync<List<Repository>>(stream);
            return repositories ?? [];
        }
    }
}