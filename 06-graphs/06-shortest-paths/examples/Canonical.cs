namespace AlgoTraining.Topics.S06T06;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    public const long Infinity = long.MaxValue / 4;
    public static long[] BellmanFord(int vertices, WeightedEdge[] edges, int start)
    {
        GraphInput.Validate(vertices, edges, start);
        long[] distance = new long[vertices];
        Array.Fill(distance, Infinity);
        distance[start] = 0;
        for (int pass = 1; pass < vertices; pass++)
        {
            bool changed = false;
            for (int i = 0; i < edges.Length; i++)
            {
                WeightedEdge edge = edges[i];
                if (distance[edge.From] != Infinity && distance[edge.From] + edge.Weight < distance[edge.To])
                {
                    distance[edge.To] = distance[edge.From] + edge.Weight;
                    changed = true;
                }
            }
            if (!changed)
                break;
        }
        for (int i = 0; i < edges.Length; i++)
        {
            WeightedEdge edge = edges[i];
            if (distance[edge.From] != Infinity && distance[edge.From] + edge.Weight < distance[edge.To])
                throw new ArgumentException("Достижимый отрицательный цикл.");
        }
        return distance; // O(VE), O(V). Отрицательные веса допустимы.
    }
    public static long[] Dijkstra(int vertices, WeightedEdge[] edges, int start)
    {
        GraphInput.Validate(vertices, edges, start);
        List<WeightedEdge>[] graph = Lists(vertices, edges);
        for (int i = 0; i < edges.Length; i++)
            if (edges[i].Weight < 0)
                throw new ArgumentException("Отрицательный вес.");
        long[] distance = new long[vertices];
        bool[] used = new bool[vertices];
        Array.Fill(distance, Infinity);
        distance[start] = 0;
        for (int step = 0; step < vertices; step++)
        {
            int selected = -1;
            for (int v = 0; v < vertices; v++)
                if (!used[v] && (selected < 0 || distance[v] < distance[selected]))
                    selected = v;
            if (selected < 0 || distance[selected] == Infinity)
                break;
            used[selected] = true;
            foreach (WeightedEdge edge in graph[selected])
                distance[edge.To] = Math.Min(distance[edge.To], distance[selected] + edge.Weight);
        }
        return distance; // O(V²+E), O(V) сверх графа.
    }
    public static long[,] FloydWarshall(int vertices, WeightedEdge[] edges)
    {
        GraphInput.Validate(vertices, edges);
        long[,] distance = new long[vertices, vertices];
        for (int i = 0; i < vertices; i++)
            for (int j = 0; j < vertices; j++)
                distance[i, j] = i == j ? 0 : Infinity;
        foreach (WeightedEdge edge in edges)
            distance[edge.From, edge.To] = Math.Min(distance[edge.From, edge.To], edge.Weight);
        // k — разрешённая промежуточная вершина; этот цикл обязан быть внешним.
        for (int k = 0; k < vertices; k++)
            for (int i = 0; i < vertices; i++)
                for (int j = 0; j < vertices; j++)
                    if (distance[i, k] != Infinity && distance[k, j] != Infinity)
                        distance[i, j] = Math.Min(distance[i, j], distance[i, k] + distance[k, j]);
        for (int v = 0; v < vertices; v++)
            if (distance[v, v] < 0)
                throw new ArgumentException("Отрицательный цикл.");
        return distance; // O(V³), O(V²).
    }
    public static long[] Dag(int vertices, WeightedEdge[] edges, int start)
    {
        GraphInput.Validate(vertices, edges, start);
        List<WeightedEdge>[] graph = Lists(vertices, edges);
        int[][] unweighted = new int[vertices][];
        for (int v = 0; v < vertices; v++)
        {
            unweighted[v] = new int[graph[v].Count];
            for (int i = 0; i < graph[v].Count; i++)
                unweighted[v][i] = graph[v][i].To;
        }
        int[] order = S06T04.Canonical.Sort(unweighted);
        long[] distance = new long[vertices];
        Array.Fill(distance, Infinity);
        distance[start] = 0;
        foreach (int v in order)
            if (distance[v] != Infinity)
                foreach (WeightedEdge edge in graph[v])
                    distance[edge.To] = Math.Min(distance[edge.To], distance[v] + edge.Weight);
        return distance; // O(V+E), O(V+E). Веса могут быть отрицательными, циклы запрещены.
    }
    public static List<WeightedEdge>[] Lists(int vertices, WeightedEdge[] edges)
    {
        List<WeightedEdge>[] graph = new List<WeightedEdge>[vertices];
        for (int i = 0; i < vertices; i++)
            graph[i] = new List<WeightedEdge>();
        foreach (WeightedEdge edge in edges)
            graph[edge.From].Add(edge);
        return graph;
    }
}
