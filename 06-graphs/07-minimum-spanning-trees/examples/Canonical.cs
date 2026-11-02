namespace AlgoTraining.Topics.S06T07;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    public static long Kruskal(int vertices, WeightedEdge[] undirectedEdges)
    {
        GraphInput.Validate(vertices, undirectedEdges);
        WeightedEdge[] sorted = (WeightedEdge[])undirectedEdges.Clone();
        Array.Sort(sorted, Compare);
        S06T05.Modern sets = new S06T05.Modern(vertices);
        long cost = 0;
        for (int i = 0; i < sorted.Length; i++)
            if (sets.Union(sorted[i].From, sorted[i].To))
                cost += sorted[i].Weight;
        if (sets.Components != 1)
            throw new ArgumentException("Граф не связен: единого остова нет.");
        return cost; // O(E log E), память O(V+E). Каждое неориентированное ребро дано один раз.
    }
    private static int Compare(WeightedEdge a, WeightedEdge b)
    {
        return a.Weight.CompareTo(b.Weight);
    }
}
