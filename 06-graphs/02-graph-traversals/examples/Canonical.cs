namespace AlgoTraining.Topics.S06T02;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    public static int[] Distances(int[][] graph, int start)
    {
        if (start < 0 || start >= graph.Length)
            throw new ArgumentOutOfRangeException(nameof(start));
        int[] distances = new int[graph.Length];
        Array.Fill(distances, -1);
        Queue<int> queue = new Queue<int>();
        distances[start] = 0;
        queue.Enqueue(start);
        while (queue.Count > 0)
        {
            int vertex = queue.Dequeue();
            for (int i = 0; i < graph[vertex].Length; i++)
            {
                int next = graph[vertex][i];
                if (distances[next] >= 0)
                    continue;
                distances[next] = distances[vertex] + 1;
                queue.Enqueue(next);
            }
        }
        return distances; // -1 = недостижимость. BFS O(V+E), память O(V).
    }
    public static int[] DepthFirst(int[][] graph, int start)
    {
        bool[] seen = new bool[graph.Length];
        List<int> order = new List<int>();
        Visit(start);
        return order.ToArray();
        void Visit(int vertex)
        {
            if (seen[vertex])
                return;
            seen[vertex] = true;
            order.Add(vertex);
            for (int i = 0; i < graph[vertex].Length; i++)
                Visit(graph[vertex][i]);
        }
    }
}
