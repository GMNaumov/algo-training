namespace AlgoTraining.Topics.S05T03;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    public static int[] PricesWithin(IEnumerable<int> prices, int minimum, int maximum)
    {
        if (minimum > maximum)
            throw new ArgumentException("Перепутаны границы.");
        SortedSet<int> tree = new(prices);
        return [.. tree.GetViewBetween(minimum, maximum)];
        // Построение O(n log n), диапазон выдаёт k значений; хранение O(n).
    }
}
