namespace AlgoTraining.Topics.S06T04;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    public static int[] Sort(int[][] graph)
    {
        int[] degree = new int[graph.Length];
        for (int v = 0; v < graph.Length; v++)
            for (int i = 0; i < graph[v].Length; i++)
                degree[graph[v][i]]++;
        Queue<int> ready = new Queue<int>();
        for (int v = 0; v < graph.Length; v++)
            if (degree[v] == 0)
                ready.Enqueue(v);
        List<int> result = new List<int>();
        while (ready.Count > 0)
        {
            int vertex = ready.Dequeue();
            result.Add(vertex);
            for (int i = 0; i < graph[vertex].Length; i++)
            {
                int next = graph[vertex][i];
                degree[next]--;
                if (degree[next] == 0)
                    ready.Enqueue(next);
            }
        }
        if (result.Count != graph.Length)
            throw new ArgumentException("Зависимости содержат цикл.");
        return result.ToArray(); // O(V+E), O(V).
    }
}
