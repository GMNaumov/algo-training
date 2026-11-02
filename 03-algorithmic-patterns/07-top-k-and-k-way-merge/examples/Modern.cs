namespace AlgoTraining.Topics.S03T07;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    public static int[] Largest(IEnumerable<int> values, int k)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(k);
        PriorityQueue<int, int> heap = new();
        foreach (var value in values)
        {
            heap.Enqueue(value, value);
            if (heap.Count > k)
                heap.Dequeue();
        }
        if (heap.Count < k)
            throw new ArgumentException("Элементов меньше k.");
        List<int> result = [];
        while (heap.TryDequeue(out var value, out _))
            result.Add(value);
        return [.. result]; // O(n log(k+1)), O(k), результат отсортирован извлечениями.
    }
    public static int[] Merge(int[][] sources)
    {
        PriorityQueue<(int Source, int Position), int> heap = new();
        for (var i = 0; i < sources.Length; i++)
            if (sources[i].Length > 0)
                heap.Enqueue((i, 0), sources[i][0]);
        List<int> result = [];
        while (heap.TryDequeue(out var item, out var value))
        {
            result.Add(value);
            var next = item.Position + 1;
            if (next < sources[item.Source].Length)
                heap.Enqueue((item.Source, next), sources[item.Source][next]);
        }
        return [.. result]; // O(N log(k+1)), O(k) без результата.
    }
}
