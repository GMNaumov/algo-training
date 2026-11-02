namespace AlgoTraining.Topics.S03T01;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    public static (int Left, int Right)? FindPair(ReadOnlySpan<int> sorted, long target)
    {
        var left = 0;
        var right = sorted.Length - 1;
        while (left < right)
        {
            var sum = (long)sorted[left] + sorted[right];
            if (sum == target)
                return (left, right);
            if (sum < target)
                left++;
            else
                right--;
        }
        return null; // Nullable tuple явно выражает отсутствие ответа.
    }
}
