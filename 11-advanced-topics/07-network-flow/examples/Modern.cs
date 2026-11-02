namespace AlgoTraining.Topics.S11T07;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    private sealed class Edge(int to, int reverse, long residual)
    {
        public int To = to; public int Reverse = reverse; public long Residual = residual;
    }
    public static (long Flow, bool[] SourceSide) Maximum(int[,] capacity, int source, int sink)
    {
        var n = capacity.GetLength(0);
        if (n != capacity.GetLength(1) || (uint)source >= (uint)n || (uint)sink >= (uint)n || source == sink)
            throw new ArgumentException("Неверная сеть.");
        var graph = Enumerable.Range(0, n).Select(_ => new List<Edge>()).ToArray();
        for (var from = 0; from < n; from++)
            for (var to = 0; to < n; to++)
            {
                if (capacity[from, to] < 0)
                    throw new ArgumentException("Отрицательная ёмкость.");
                if (from == to || capacity[from, to] == 0)
                    continue; // Петли не увеличивают поток s→t.
                var forward = new Edge(to, graph[to].Count, capacity[from, to]);
                var backward = new Edge(from, graph[from].Count, 0);
                graph[from].Add(forward);
                graph[to].Add(backward);
            }
        long total = 0;
        while (true)
        {
            bool[] seen = new bool[n];
            int[] previous = new int[n];
            int[] edgeIndex = new int[n];
            Queue<int> queue = new([source]);
            seen[source] = true;
            while (queue.TryDequeue(out var v))
                for (var i = 0; i < graph[v].Count; i++)
                {
                    var edge = graph[v][i];
                    if (edge.Residual <= 0 || seen[edge.To])
                        continue;
                    seen[edge.To] = true;
                    previous[edge.To] = v;
                    edgeIndex[edge.To] = i;
                    queue.Enqueue(edge.To);
                }
            if (!seen[sink])
                return (total, seen); // Финальная достижимость задаёт минимальный разрез.
            var added = long.MaxValue;
            for (var v = sink; v != source; v = previous[v])
                added = Math.Min(added, graph[previous[v]][edgeIndex[v]].Residual);
            for (var v = sink; v != source; v = previous[v])
            {
                var edge = graph[previous[v]][edgeIndex[v]];
                edge.Residual -= added;
                graph[v][edge.Reverse].Residual += added;
            }
            total += added;
        } // Эдмондс — Карп: O(VE²), списки O(V+E), плюс чтение входной матрицы O(V²).
    }
}
