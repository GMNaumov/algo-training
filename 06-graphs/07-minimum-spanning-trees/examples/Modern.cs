namespace AlgoTraining.Topics.S06T07;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    public static long Prim(int vertices, WeightedEdge[] edges)
    {
        GraphInput.Validate(vertices, edges);
        var graph = Enumerable.Range(0, vertices).Select(_ => new List<(int To, int Weight)>()).ToArray();
        foreach (var edge in edges)
        {
            graph[edge.From].Add((edge.To, edge.Weight));
            graph[edge.To].Add((edge.From, edge.Weight));
        }
        bool[] used = new bool[vertices];
        var visited = 0;
        long cost = 0;
        PriorityQueue<int, int> queue = new();
        queue.Enqueue(0, 0);
        while (queue.TryDequeue(out var vertex, out var weight))
        {
            if (used[vertex])
                continue;
            used[vertex] = true;
            visited++;
            cost += weight;
            foreach (var edge in graph[vertex])
                if (!used[edge.To])
                    queue.Enqueue(edge.To, edge.Weight);
        }
        if (visited != vertices)
            throw new ArgumentException("Несвязный граф.");
        return cost; // O((V+E) log(E+1)), память O(V+E), включая ленивую очередь.
    }
}
