namespace AlgoTraining.Topics.S06T03;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    public static int[] Components(int[][] undirected)
    {
        int[] labels = new int[undirected.Length];
        Array.Fill(labels, -1);
        int component = 0;
        for (int start = 0; start < undirected.Length; start++)
        {
            if (labels[start] >= 0)
                continue;
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);
            labels[start] = component;
            while (queue.Count > 0)
            {
                int vertex = queue.Dequeue();
                for (int i = 0; i < undirected[vertex].Length; i++)
                {
                    int next = undirected[vertex][i];
                    if (labels[next] < 0)
                    {
                        labels[next] = component;
                        queue.Enqueue(next);
                    }
                }
            }
            component++;
        }
        return labels; // O(V+E), O(V). У входа должны быть обратные рёбра.
    }
}
