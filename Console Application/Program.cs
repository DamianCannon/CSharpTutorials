namespace TeleprompterConsole;

internal class Program
{
    private static void Main(string[] args)
    {
        var lines = ReadFrom("sampleQuotes.txt");
        foreach (var line in lines)
        {
            Console.Write(line);

            if (!string.IsNullOrWhiteSpace(line))
            {
                var pause = Task.Delay(200);
                pause.Wait();
            }
        }
    }

    private static IEnumerable<string> ReadFrom(string file)
    {
        string? line;

        using (var reader = File.OpenText(file))
        {
            while ((line = reader.ReadLine()) != null )
            {
                //yield return line;
                var words = line.Split(" ");
                foreach (var word in words)
                {
                    yield return $"{word} ";
                }
                yield return Environment.NewLine;
            }
        }
    }

}