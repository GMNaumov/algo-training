namespace AlgoTraining.Topics.S04T03;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    public static IEnumerable<int[]> SubsetsWithSum(int[] prices, long target)
    {
        return Search(0, 0, []);
        IEnumerable<int[]> Search(int index, long sum, int[] chosen)
        {
            if (index == prices.Length)
            {
                if (sum == target)
                    yield return chosen;
                yield break;
            }
            foreach (var result in Search(index + 1, sum, chosen))
                yield return result;
            foreach (var result in Search(index + 1, sum + prices[index], [.. chosen, prices[index]]))
                yield return result;
        }
        // Неизменяемые снимки проще отмены выбора, но увеличивают суммарные выделения.
    }
}
