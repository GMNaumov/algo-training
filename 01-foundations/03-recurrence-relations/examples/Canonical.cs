namespace AlgoTraining.Topics.S01T03;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    // T(n) = 2T(n/2) + O(1): всего O(n), стек O(log n).
    public static long Sum(int[] values, int start, int length)
    {
        if (start < 0 || length < 0 || start > values.Length - length)
            throw new ArgumentOutOfRangeException(nameof(length));
        if (length == 0)
            return 0;
        if (length == 1)
            return values[start];
        int half = length / 2;
        return Sum(values, start, half) + Sum(values, start + half, length - half);
    }
}
