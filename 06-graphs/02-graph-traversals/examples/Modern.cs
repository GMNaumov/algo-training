namespace AlgoTraining.Topics.S06T02;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    public static int[] ShortestRoute(int[][] graph, int start, int goal)
    {
        if ((uint)start >= (uint)graph.Length || (uint)goal >= (uint)graph.Length)
            throw new ArgumentOutOfRangeException(nameof(start));
        int[] parent = new int[graph.Length];
        Array.Fill(parent, -1);
        Queue<int> queue = new([start]);
        parent[start] = start;
        while (queue.TryDequeue(out var vertex))
        {
            foreach (var next in graph[vertex])
            {
                if (parent[next] >= 0)
                    continue;
                parent[next] = vertex;
                queue.Enqueue(next);
            }
        }
        if (parent[goal] < 0)
            return [];
        List<int> route = [];
        for (var current = goal; ; current = parent[current])
        {
            route.Add(current);
            if (current == start)
                break;
        }
        route.Reverse();
        return [.. route];
    }
}
