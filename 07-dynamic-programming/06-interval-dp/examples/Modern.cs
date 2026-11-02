namespace AlgoTraining.Topics.S07T06;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    public static long MergeCost(ReadOnlySpan<int> sizes)
    {
        var data = sizes.ToArray();
        if (data.Any(x => x < 0))
            throw new ArgumentException("Отрицательный размер.");
        Dictionary<(int Left, int Right), long> memo = [];
        return Solve(0, data.Length);
        long Solve(int left, int right)
        {
            if (right - left <= 1)
                return 0;
            if (memo.TryGetValue((left, right), out var saved))
                return saved;
            long sum = 0;
            for (var i = left; i < right; i++)
                sum += data[i];
            var best = long.MaxValue;
            for (var split = left + 1; split < right; split++)
                best = Math.Min(best, Solve(left, split) + Solve(split, right) + sum);
            return memo[(left, right)] = best;
        } // Мемоизация тех же O(n²) интервалов, O(n³) времени, стек O(n).
    }
}
