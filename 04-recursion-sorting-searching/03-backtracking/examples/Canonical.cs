namespace AlgoTraining.Topics.S04T03;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    public static List<int[]> SubsetsWithSum(int[] prices, long target)
    {
        List<int[]> result = new List<int[]>();
        List<int> chosen = new List<int>();
        Search(prices, target, 0, 0, chosen, result);
        return result;
    }
    private static void Search(int[] prices, long target, int index, long sum, List<int> chosen, List<int[]> result)
    {
        if (index == prices.Length)
        {
            if (sum == target)
                result.Add(chosen.ToArray()); // Копия защищает готовый ответ.
            return;
        }
        Search(prices, target, index + 1, sum, chosen, result);
        chosen.Add(prices[index]);
        Search(prices, target, index + 1, sum + prices[index], chosen, result);
        chosen.RemoveAt(chosen.Count - 1); // Отмена выбора перед возвратом.
    }
    // O(n*2^n) с копированием ответов; O(n) стека без результатов.
}
