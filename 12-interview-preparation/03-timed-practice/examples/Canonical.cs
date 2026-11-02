namespace AlgoTraining.Topics.S12T03;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    public static long Measure(Action action)
    {
        Stopwatch watch = Stopwatch.StartNew();
        action();
        watch.Stop();
        return watch.ElapsedTicks;
        // Измеряем реальный запуск, но одно измерение не доказывает сложность.
    }
    public static long Sum(int[] values)
    {
        long sum = 0;
        for (int i = 0; i < values.Length; i++)
            sum += values[i];
        return sum;
    }
}
