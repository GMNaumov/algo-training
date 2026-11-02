namespace AlgoTraining.Topics.S00T02;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    // Очевидное решение-эталон: разные индексы i < j. O(n²), память O(1).
    public static bool HasPair(int[] prices, int target)
    {
        for (int i = 0; i < prices.Length; i++)
            for (int j = i + 1; j < prices.Length; j++)
                if ((long)prices[i] + prices[j] == target)
                    return true;
        return false;
    }
}
