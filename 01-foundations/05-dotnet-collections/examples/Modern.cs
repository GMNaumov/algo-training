namespace AlgoTraining.Topics.S01T05;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    public static Dictionary<string, int> Frequencies(IEnumerable<string> clients) =>
        clients.GroupBy(name => name, StringComparer.Ordinal)
            .ToDictionary(group => group.Key, group => group.Count(), StringComparer.Ordinal);

    public static string NextUrgent()
    {
        PriorityQueue<string, int> deliveries = new();
        deliveries.Enqueue("Обычная", 5);
        deliveries.Enqueue("Срочная", 1); // Меньшее число обслуживается первым.
        return deliveries.Dequeue();
    }
}
