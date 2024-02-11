using CardDeckShuffle;
using System.Net.Security;

internal class Program
{
    private static void Main(string[] args)
    {

        var deck = (from s in Suits()
                            from r in Ranks()
                            select new { Suit = s, Rank = r });
        var startingDeck = deck.ToArray();

        foreach (var card in startingDeck)
        {
            Console.WriteLine(card);
        }

        var topHalf = startingDeck.Take(26);
        var bottomHalf = startingDeck.Skip(26);
        var shuffledDeck = topHalf.InterleaveSequenceWith(bottomHalf);

        foreach (var card in shuffledDeck)
        {
            Console.WriteLine(card);
        }

        var times = 0;
        shuffledDeck = startingDeck;
        do {
            //shuffledDeck = shuffledDeck.Take(26).LogQuery("Bottom half").InterleaveSequenceWith(shuffledDeck.Skip(26).LogQuery("Top Half")).LogQuery("Shuffle").ToArray();
            shuffledDeck = shuffledDeck.Skip(26).LogQuery("Bottom half").InterleaveSequenceWith(shuffledDeck.Take(26).LogQuery("Top Half")).LogQuery("Shuffle").ToArray();
            foreach (var card in shuffledDeck)
            {
                Console.WriteLine(card);
            }
            Console.WriteLine();
            times++;

        } while (!startingDeck.SequenceEquals(shuffledDeck));

        Console.WriteLine($"Number of shuffles: {times}");

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