namespace AlgoTraining.Topics.S13T03;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    public static long RangeSum(int[] values, int left, int right)
    {
        if (left < 0 || right < left || right > values.Length)
            throw new ArgumentOutOfRangeException(nameof(left));
        long result = 0;
        for (int i = left; i < right; i++)
            result += values[i];
        return result;
        // Один запрос O(n), дополнительная память O(1): разумно для редкого запроса.
    }
}
