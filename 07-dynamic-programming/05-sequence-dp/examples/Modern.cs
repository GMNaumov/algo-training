namespace AlgoTraining.Topics.S07T05;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    public static int Lis(ReadOnlySpan<int> values)
    {
        int[] tails = new int[values.Length];
        var count = 0;
        foreach (var value in values)
        {
            var left = 0;
            var right = count;
            while (left < right)
            {
                var mid = left + (right - left) / 2;
                if (tails[mid] < value)
                    left = mid + 1;
                else
                    right = mid;
            }
            tails[left] = value;
            if (left == count)
                count++;
        }
        return count; // Минимальные концы, не сама LIS. O(n log n), O(n).
    }
    public static int Lcs(ReadOnlySpan<char> a, ReadOnlySpan<char> b)
    {
        int[] row = new int[b.Length + 1];
        foreach (var symbol in a)
        {
            var diagonal = 0;
            for (var j = 1; j <= b.Length; j++)
            {
                var above = row[j];
                row[j] = symbol == b[j - 1] ? diagonal + 1 : Math.Max(row[j], row[j - 1]);
                diagonal = above;
            }
        }
        return row[^1]; // O(nm), O(m).
    }
}
