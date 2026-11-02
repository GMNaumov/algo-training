namespace AlgoTraining.Topics.S07T08;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    public static long Assignment(int[,] costs)
    {
        var n = costs.GetLength(0);
        if (n != costs.GetLength(1) || n > 20)
            throw new ArgumentException("Нужна квадратная матрица n <= 20.");
        var best = Enumerable.Repeat(long.MaxValue, 1 << n).ToArray();
        best[0] = 0;
        for (var mask = 0; mask < best.Length; mask++)
        {
            var worker = BitOperations.PopCount((uint)mask);
            if (worker == n)
                continue;
            for (var task = 0; task < n; task++)
                if ((mask & (1 << task)) == 0)
                {
                    var next = mask | (1 << task);
                    best[next] = Math.Min(best[next], best[mask] + costs[worker, task]);
                }
        }
        return best[^1];
    }
    // Кратчайший цикл по всем городам, старт в 0. Полная матрица стоимостей.
    public static long Tour(int[,] costs)
    {
        var n = costs.GetLength(0);
        if (n == 0 || n != costs.GetLength(1) || n > 16)
            throw new ArgumentException("Полная матрица, 1 <= n <= 16.");
        if (n == 1)
            return 0;
        var states = 1 << n;
        var infinity = long.MaxValue / 4;
        long[,] best = new long[states, n];
        for (var mask = 0; mask < states; mask++)
            for (var last = 0; last < n; last++)
                best[mask, last] = infinity;
        best[1, 0] = 0;
        for (var mask = 1; mask < states; mask++)
            for (var last = 0; last < n; last++)
            {
                if (best[mask, last] == infinity)
                    continue;
                for (var next = 0; next < n; next++)
                    if ((mask & (1 << next)) == 0)
                    {
                        var added = mask | (1 << next);
                        best[added, next] = Math.Min(best[added, next], best[mask, last] + costs[last, next]);
                    }
            }
        return Enumerable.Range(1, n - 1).Min(last => best[states - 1, last] + costs[last, 0]);
        // O(n²*2^n), O(n*2^n). last необходим: от него зависит следующий переход.
    }
}
