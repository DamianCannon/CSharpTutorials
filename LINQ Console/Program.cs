internal class Program
{
    private static void Main(string[] args)
    {
        var startingDeck = from s in Suits()
                           from r in Ranks()
                           select new { Suit = s, Rank = r };

        foreach (var card in startingDeck)
        {
            Console.WriteLine(card);
        }
    }

    private static IEnumerable<string> Suits()
    {
        yield return "Clubs";
        yield return "Diamonds";
        yield return "Hearts";
        yield return "Spades";
    }

    private static IEnumerable<string> Ranks()
    {
        yield return "ace";
        yield return "two";
        yield return "three";
        yield return "four";
        yield return "five";
        yield return "six";
        yield return "seven";
        yield return "eight";
        yield return "nine";
        yield return "ten";
        yield return "jack";
        yield return "queen";
        yield return "king";
    }
}