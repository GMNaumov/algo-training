namespace AlgoTraining.Topics.S13T03;

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
    public long RangeSum(Range range)
    {
        var (left, length) = range.GetOffsetAndLength(prefix.Length - 1);
        return prefix[left + length] - prefix[left]; // Много запросов: O(n) подготовка, O(1) каждый.
    }
}
