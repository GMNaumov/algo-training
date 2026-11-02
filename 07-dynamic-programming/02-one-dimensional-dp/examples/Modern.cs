namespace AlgoTraining.Topics.S07T02;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    public static long NonAdjacent(ReadOnlySpan<int> payments)
    {
        long previous = 0, current = 0;
        foreach (var payment in payments)
            (previous, current) = (current, Math.Max(current, previous + payment));
        return current; // O(n), O(1). Правая часть использует старые значения.
    }
    public static long MaxSubarray(IEnumerable<int> values)
    {
        using var iterator = values.GetEnumerator();
        if (!iterator.MoveNext())
            throw new ArgumentException("Пустой поток.");
        long ending = iterator.Current, best = ending;
        while (iterator.MoveNext())
        {
            ending = Math.Max(iterator.Current, ending + iterator.Current);
            best = Math.Max(best, ending);
        }
        return best;
    }
}
