namespace AlgoTraining.Topics.S13T01;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    public static (int Index, int Comparisons) Search(ReadOnlySpan<int> sorted, int target)
    {
        var left = 0;
        var right = sorted.Length;
        var comparisons = 0;
        while (left < right)
        {
            var middle = left + (right - left) / 2;
            comparisons++;
            var comparison = sorted[middle].CompareTo(target);
            if (comparison == 0)
                return (middle, comparisons);
            if (comparison < 0)
                left = middle + 1;
            else
                right = middle;
        }
        return (-1, comparisons); // O(log n), O(1), вход отсортирован.
    }
}
