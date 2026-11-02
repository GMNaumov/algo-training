namespace AlgoTraining.Topics.S11T06;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    public static int[] Directed(int vertices, (int From, int To)[] edges)
    {
        if (vertices <= 0)
            throw new ArgumentOutOfRangeException(nameof(vertices));
        var graph = Enumerable.Range(0, vertices).Select(_ => new Queue<int>()).ToArray();
        int[] balance = new int[vertices];
        foreach (var (from, to) in edges)
        {
            if ((uint)from >= (uint)vertices || (uint)to >= (uint)vertices)
                throw new ArgumentException("Неизвестная вершина.");
            graph[from].Enqueue(to);
            balance[from]++;
            balance[to]--;
        }
        var starts = Enumerable.Range(0, vertices).Where(v => balance[v] == 1).ToArray();
        var ends = balance.Count(value => value == -1);
        if (balance.Any(value => Math.Abs(value) > 1) || starts.Length != ends || starts.Length > 1)
            throw new ArgumentException("Неверные степени.");
        var start = starts.Length == 1 ? starts[0] : Array.FindIndex(graph, neighbors => neighbors.Count > 0);
        if (start < 0)
            return [0];
        Stack<int> stack = new([start]);
        List<int> route = [];
        while (stack.TryPeek(out var v))
            if (graph[v].TryDequeue(out var next))
                stack.Push(next);
            else
                route.Add(stack.Pop());
        if (route.Count != edges.Length + 1)
            throw new ArgumentException("Не все рёбра достижимы.");
        route.Reverse();
        return [.. route]; // O(V+E), O(V+E).
    }
}
