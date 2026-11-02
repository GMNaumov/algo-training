namespace AlgoTraining.Topics.S05T04;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    public static string[] Schedule(IEnumerable<(string Name, int Time)> events)
    {
        PriorityQueue<string, (int Time, int Sequence)> queue = new();
        var sequence = 0;
        foreach (var item in events)
            queue.Enqueue(item.Name, (item.Time, sequence++));
        List<string> result = [];
        while (queue.TryDequeue(out var name, out _))
            result.Add(name);
        return [.. result]; // Второй ключ гарантирует порядок поступления при равном времени.
    }
}
