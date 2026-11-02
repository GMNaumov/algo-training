namespace AlgoTraining.Topics.S11T05;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    public static int[] Tarjan(int[][] graph)
    {
        var index = Enumerable.Repeat(-1, graph.Length).ToArray();
        int[] low = new int[graph.Length];
        bool[] active = new bool[graph.Length];
        int[] labels = new int[graph.Length];
        Stack<int> stack = new();
        var clock = 0;
        var component = 0;
        for (var v = 0; v < graph.Length; v++)
            if (index[v] < 0)
                Visit(v);
        return labels;
        void Visit(int v)
        {
            index[v] = low[v] = clock++;
            active[v] = true;
            stack.Push(v);
            foreach (var next in graph[v])
                if (index[next] < 0)
                {
                    Visit(next);
                    low[v] = Math.Min(low[v], low[next]);
                }
                else if (active[next])
                    low[v] = Math.Min(low[v], index[next]);
            if (low[v] != index[v])
                return;
            int removed;
            do
            {
                removed = stack.Pop();
                active[removed] = false;
                labels[removed] = component;
            } while (removed != v);
            component++;
        } // O(V+E), память O(V) сверх графа. Важен именно стек активных вершин.
    }
}
