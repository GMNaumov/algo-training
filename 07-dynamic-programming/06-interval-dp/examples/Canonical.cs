namespace AlgoTraining.Topics.S07T06;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    public static long MergeCost(int[] sizes)
    {
        int count = sizes.Length;
        if (count == 0)
            return 0;
        long[] prefix = new long[count + 1];
        for (int i = 0; i < count; i++)
        {
            if (sizes[i] < 0)
                throw new ArgumentException("Размеры неотрицательны.");
            prefix[i + 1] = prefix[i] + sizes[i];
        }
        long[,] best = new long[count, count];
        for (int length = 2; length <= count; length++)
            for (int left = 0; left + length <= count; left++)
            {
                int right = left + length - 1;
                best[left, right] = long.MaxValue;
                for (int split = left; split < right; split++)
                    best[left, right] = Math.Min(best[left, right], best[left, split] + best[split + 1, right] + prefix[right + 1] - prefix[left]);
            }
        return best[0, count - 1]; // O(n³), O(n²). Объединяем только соседние пачки.
    }
}
