namespace AlgoTraining.Topics.S06T03;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    public static bool IsBipartite(int[][] graph)
    {
        int[] colors = new int[graph.Length];
        Array.Fill(colors, -1);
        for (var start = 0; start < graph.Length; start++)
        {
            if (colors[start] >= 0)
                continue;
            Queue<int> queue = new([start]);
            colors[start] = 0;
            while (queue.TryDequeue(out var vertex))
                foreach (var next in graph[vertex])
                {
                    if (colors[next] == colors[vertex])
                        return false;
                    if (colors[next] < 0)
                    {
                        colors[next] = 1 - colors[vertex];
                        queue.Enqueue(next);
                    }
                }
        }
        return true; // Проверяются и отдельные компоненты. O(V+E), O(V).
    }
}
