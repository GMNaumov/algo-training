namespace AlgoTraining.Topics.S06T06;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    public static long[] Dijkstra(int vertices, WeightedEdge[] edges, int start)
    {
        GraphInput.Validate(vertices, edges, start);
        if (edges.Any(e => e.Weight < 0))
            throw new ArgumentException("Отрицательный вес.");
        var graph = Canonical.Lists(vertices, edges);
        var distance = Enumerable.Repeat(Canonical.Infinity, vertices).ToArray();
        distance[start] = 0;
        PriorityQueue<int, long> queue = new();
        queue.Enqueue(start, 0);
        while (queue.TryDequeue(out var vertex, out var saved))
        {
            if (saved != distance[vertex])
                continue; // Устаревшие записи не обрабатываем.
            foreach (var edge in graph[vertex])
            {
                var candidate = saved + edge.Weight;
                if (candidate >= distance[edge.To])
                    continue;
                distance[edge.To] = candidate;
                queue.Enqueue(edge.To, candidate);
            }
        }
        return distance; // O((V+E) log(V+E+1)), очередь до O(E).
    }
    public static long[] ZeroOneBfs(int vertices, WeightedEdge[] edges, int start)
    {
        GraphInput.Validate(vertices, edges, start);
        if (edges.Any(e => e.Weight is not (0 or 1)))
            throw new ArgumentException("Нужны веса 0 и 1.");
        var graph = Canonical.Lists(vertices, edges);
        var distance = Enumerable.Repeat(Canonical.Infinity, vertices).ToArray();
        distance[start] = 0;
        LinkedList<(int Vertex, long Distance)> deque = new();
        deque.AddFirst((start, 0));
        while (deque.First is { } first)
        {
            var (vertex, saved) = first.Value;
            deque.RemoveFirst();
            if (saved != distance[vertex])
                continue;
            foreach (var edge in graph[vertex])
            {
                var candidate = saved + edge.Weight;
                if (candidate >= distance[edge.To])
                    continue;
                distance[edge.To] = candidate;
                if (edge.Weight == 0)
                    deque.AddFirst((edge.To, candidate));
                else
                    deque.AddLast((edge.To, candidate));
            }
        }
        return distance; // O(V+E), память O(V+E) со списками и записями дека.
    }
}
