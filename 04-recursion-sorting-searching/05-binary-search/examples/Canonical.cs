namespace AlgoTraining.Topics.S04T05;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    public static int LowerBound(int[] sorted, int target)
    {
        int left = 0;
        int right = sorted.Length;
        while (left < right)
        {
            int middle = left + (right - left) / 2;
            if (sorted[middle] < target)
                left = middle + 1;
            else
                right = middle; // Подходящую середину оставляем кандидатом.
        }
        return left; // O(log n), O(1); n означает отсутствие подходящего элемента.
    }
}
