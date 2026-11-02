namespace AlgoTraining.Topics.S08T02;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    public static long CompletionSum(int[] durations)
    {
        int[] sorted = (int[])durations.Clone();
        Array.Sort(sorted);
        long elapsed = 0;
        long total = 0;
        for (int i = 0; i < sorted.Length; i++)
        {
            if (sorted[i] < 0)
                throw new ArgumentException("Отрицательная длительность.");
            elapsed += sorted[i];
            total += elapsed;
        }
        return total; // O(n log n), O(n). Все работы доступны сразу, веса одинаковы.
    }
    public static long PairContribution(int first, int second)
    {
        return 2L * first + second; // Обмен соседей не меняет окончание более поздних работ.
    }
}
