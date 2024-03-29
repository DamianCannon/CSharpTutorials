﻿namespace CardDeckShuffle
{
    internal static class Extensions
    {
        internal static IEnumerable<T> InterleaveSequenceWith<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            var firstIterator = first.GetEnumerator();
            var secondIterator = second.GetEnumerator();

            while (firstIterator.MoveNext() && secondIterator.MoveNext())
            {
                yield return firstIterator.Current;
                yield return secondIterator.Current;
            }
        }

        internal static bool SequenceEquals<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            var firstIterator = first.GetEnumerator();
            var secondIterator = second.GetEnumerator();

            while (firstIterator.MoveNext() && secondIterator.MoveNext())
            {
                if(firstIterator.Current == null || !firstIterator.Current.Equals(secondIterator.Current))
                {
                    return false;
                }
            }

            return true;
        }

        internal static IEnumerable<T> LogQuery<T>(this IEnumerable<T> sequence, string tag)
        {
            using (var writer = File.AppendText("debug.log"))
            {
                writer.WriteLine($"Executing Query {tag}");
            }
            return sequence;
        }
    }
}
