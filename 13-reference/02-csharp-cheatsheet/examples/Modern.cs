namespace AlgoTraining.Topics.S13T02;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    // Extension block — возможность C# 14. Получатель здесь IEnumerable<int>.
    extension(IEnumerable<int> values)
    {
        public long CheckedTotal() => values.Aggregate(0L, (sum, value) => checked(sum + value));
    }
    public static int[] SortedCopy(ReadOnlySpan<int> values)
    {
        int[] copy = [.. values];
        copy.AsSpan().Sort();
        return copy;
    }
}
