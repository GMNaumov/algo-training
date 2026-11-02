namespace AlgoTraining.Topics.S07T02;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    public static long NonAdjacent(int[] payments)
    {
        long[] best = new long[payments.Length + 1];
        for (int i = 1; i <= payments.Length; i++)
        {
            long take = payments[i - 1] + (i >= 2 ? best[i - 2] : 0);
            best[i] = Math.Max(best[i - 1], take);
        }
        return best[payments.Length]; // Пустой выбор разрешён. O(n), O(n).
    }
    public static long MaxSubarray(int[] values)
    {
        if (values.Length == 0)
            throw new ArgumentException("Нужен непустой вход.");
        long ending = values[0];
        long best = ending;
        for (int i = 1; i < values.Length; i++)
        {
            ending = Math.Max(values[i], ending + values[i]);
            best = Math.Max(best, ending);
        }
        return best; // Кадане: фрагмент непустой. O(n), O(1).
    }
}
