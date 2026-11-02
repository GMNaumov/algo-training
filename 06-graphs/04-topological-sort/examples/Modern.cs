namespace AlgoTraining.Topics.S06T04;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    public static int[] Sort(int[][] graph)
    {
        int[] degree = new int[graph.Length];
        foreach (var neighbors in graph)
            foreach (var next in neighbors)
                degree[next]++;
        SortedSet<int> ready = new(Enumerable.Range(0, graph.Length).Where(v => degree[v] == 0));
        List<int> result = [];
        while (ready.Count > 0)
        {
            var vertex = ready.Min;
            ready.Remove(vertex);
            result.Add(vertex);
            foreach (var next in graph[vertex])
                if (--degree[next] == 0)
                    ready.Add(next);
        }
        if (result.Count != graph.Length)
            throw new ArgumentException("Цикл зависимостей.");
        return [.. result]; // Наименьшая готовая вершина: O(E+V log V), O(V).
    }
}
