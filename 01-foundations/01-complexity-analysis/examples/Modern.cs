namespace AlgoTraining.Topics.S01T01;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    // Формула считает тот же объём работы за O(1), не выполняя сами сравнения.
    public static long PairComparisons(int count)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(count);
        return (long)count * (count - 1) / 2;
    }
}
