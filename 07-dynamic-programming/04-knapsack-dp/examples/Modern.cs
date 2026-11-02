namespace AlgoTraining.Topics.S07T04;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    public static long ZeroOne(int[] weights, int[] benefits, int capacity)
    {
        Canonical.Validate(weights, benefits, capacity);
        long[] best = new long[capacity + 1];
        foreach (var (weight, benefit) in weights.Zip(benefits))
            for (var c = capacity; c >= weight; c--)
                best[c] = Math.Max(best[c], best[c - weight] + benefit);
        return best[^1]; // Обход вниз запрещает повторное использование предмета. O(nW), O(W).
    }
}
