namespace AlgoTraining.Topics.S13T01;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    public static int Search(int[] values, int target, out int comparisons)
    {
        comparisons = 0;
        for (int i = 0; i < values.Length; i++)
        {
            comparisons++;
            if (values[i] == target)
                return i;
        }
        return -1; // O(n), O(1). Отсортированность не требуется.
    }
}
