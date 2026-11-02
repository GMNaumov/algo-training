namespace AlgoTraining.Topics.S01T01;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    // Считаем сравнения, а не миллисекунды: результат не зависит от нагрузки компьютера.
    public static long PairComparisons(int count)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(count);
        long comparisons = 0;
        for (int i = 0; i < count; i++)
            for (int j = i + 1; j < count; j++)
                comparisons++;
        return comparisons; // O(n²) времени, O(1) памяти.
    }
}
