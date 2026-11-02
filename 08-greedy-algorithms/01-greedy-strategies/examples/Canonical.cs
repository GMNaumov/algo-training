namespace AlgoTraining.Topics.S08T01;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    public static int Attend(int[][] meetings)
    {
        int[][] sorted = (int[][])meetings.Clone();
        Array.Sort(sorted, CompareEnd);
        int count = 0;
        long end = long.MinValue;
        for (int i = 0; i < sorted.Length; i++)
        {
            if (sorted[i][0] >= sorted[i][1])
                throw new ArgumentException("Положительная длительность обязательна.");
            if (sorted[i][0] >= end)
            {
                count++;
                end = sorted[i][1];
            }
        }
        return count; // Самое раннее окончание. O(n log n), O(n) копии.
    }
    private static int CompareEnd(int[] a, int[] b)
    {
        return a[1].CompareTo(b[1]);
    }
    public static int GreedyCoins(int[] denominations, int target)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(target);
        int[] coins = (int[])denominations.Clone();
        Array.Sort(coins);
        int count = 0;
        for (int i = coins.Length - 1; i >= 0; i--)
        {
            if (coins[i] <= 0)
                throw new ArgumentException("Номиналы положительны.");
            count += target / coins[i];
            target %= coins[i];
        }
        return target == 0 ? count : -1; // ДЕМОНСТРАЦИЯ ГИПОТЕЗЫ, не универсальный оптимум.
    }
}
