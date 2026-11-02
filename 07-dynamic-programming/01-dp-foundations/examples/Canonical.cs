namespace AlgoTraining.Topics.S07T01;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    public static long Stairs(int steps)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(steps);
        long[] ways = new long[checked(steps + 1)];
        ways[0] = 1;
        for (int i = 1; i <= steps; i++)
        {
            ways[i] = ways[i - 1];
            if (i >= 2)
                ways[i] = checked(ways[i] + ways[i - 2]);
        }
        return ways[steps]; // O(n), O(n). checked обнаруживает переполнение.
    }
    public static long Memoized(int steps)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(steps);
        Dictionary<int, long> memo = new Dictionary<int, long>();
        return Solve(steps);
        long Solve(int n)
        {
            if (n <= 1)
                return 1;
            long saved;
            if (memo.TryGetValue(n, out saved))
                return saved;
            long result = checked(Solve(n - 1) + Solve(n - 2));
            memo.Add(n, result);
            return result;
        } // Те же состояния, но есть дополнительный стек O(n).
    }
}
