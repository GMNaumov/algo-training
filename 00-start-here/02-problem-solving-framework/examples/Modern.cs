namespace AlgoTraining.Topics.S00T02;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    // Сначала ищем дополнение, затем добавляем текущую цену: один товар не повторяется.
    // Ожидаемо O(n), память O(n). long защищает разность от переполнения int.
    public static bool HasPair(ReadOnlySpan<int> prices, int target)
    {
        HashSet<long> seen = [];
        foreach (var price in prices)
        {
            if (seen.Contains((long)target - price))
                return true;
            seen.Add(price);
        }
        return false;
    }
}
