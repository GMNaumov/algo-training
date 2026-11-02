namespace AlgoTraining.Topics.S06T01;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    public static int[][] FromEdges(int vertices, IEnumerable<(int From, int To)> edges)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(vertices);
        var lists = Enumerable.Range(0, vertices).Select(_ => new List<int>()).ToArray();
        foreach (var (from, to) in edges)
        {
            if ((uint)from >= (uint)vertices || (uint)to >= (uint)vertices)
                throw new ArgumentException("Неизвестная вершина.");
            lists[from].Add(to);
        }
        return lists.Select(list => list.ToArray()).ToArray(); // O(V+E).
    }
}
