namespace AlgoTraining.Topics.S04T05;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    public static int LowerBound<T>(ReadOnlySpan<T> sorted, T target) where T : IComparable<T>
    {
        var left = 0;
        var right = sorted.Length;
        while (left < right)
        {
            var middle = left + (right - left) / 2;
            if (sorted[middle].CompareTo(target) < 0)
                left = middle + 1;
            else
                right = middle;
        }
        return left; // Generic-версия работает и с DateOnly, и с числами.
    }
}
