namespace AlgoTraining.Topics.S03T03;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    public static long MaxSum(ReadOnlySpan<int> values, int size)
    {
        if (size <= 0 || size > values.Length)
            throw new ArgumentOutOfRangeException(nameof(size));
        long sum = 0;
        foreach (var value in values[..size])
            sum += value;
        var best = sum;
        for (var i = size; i < values.Length; i++)
        {
            sum += (long)values[i] - values[i - size];
            best = Math.Max(best, sum);
        }
        return best;
    }
}
