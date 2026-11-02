namespace AlgoTraining.Topics.S03T04;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public sealed class Modern
{
    private readonly long[] prefix;
    public Modern(ReadOnlySpan<int> values)
    {
        prefix = new long[values.Length + 1];
        for (var i = 0; i < values.Length; i++)
            prefix[i + 1] = prefix[i] + values[i];
    }
    public long Sum(Range range)
    {
        var (start, length) = range.GetOffsetAndLength(prefix.Length - 1);
        return prefix[start + length] - prefix[start]; // O(1), в том числе ^индексы.
    }
}
