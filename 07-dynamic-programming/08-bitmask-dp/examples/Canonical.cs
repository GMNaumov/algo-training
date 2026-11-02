namespace AlgoTraining.Topics.S07T08;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    public static long Assignment(int[,] costs)
    {
        int n = costs.GetLength(0);
        if (n != costs.GetLength(1) || n > 20)
            throw new ArgumentException("Квадратная матрица, n <= 20.");
        int states = 1 << n;
        long[] best = new long[states];
        Array.Fill(best, long.MaxValue);
        best[0] = 0;
        for (int mask = 0; mask < states; mask++)
        {
            int worker = 0;
            for (int bits = mask; bits > 0; bits >>= 1)
                worker += bits & 1;
            if (worker == n)
                continue;
            for (int task = 0; task < n; task++)
                if ((mask & (1 << task)) == 0)
                {
                    int next = mask | (1 << task);
                    best[next] = Math.Min(best[next], best[mask] + costs[worker, task]);
                }
        }
        return best[states - 1]; // O(n*2^n), O(2^n). Все назначения разрешены.
    }
}
