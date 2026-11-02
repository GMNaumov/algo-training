namespace AlgoTraining.Topics.S11T05;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    public static int[] Kosaraju(int[][] graph)
    {
        bool[] seen = new bool[graph.Length];
        List<int> order = new List<int>();
        List<int>[] reverse = new List<int>[graph.Length];
        for (int v = 0; v < graph.Length; v++)
            reverse[v] = new List<int>();
        for (int v = 0; v < graph.Length; v++)
            foreach (int next in graph[v])
                reverse[next].Add(v);
        for (int v = 0; v < graph.Length; v++)
            Visit(v);
        int[] labels = new int[graph.Length];
        Array.Fill(labels, -1);
        int component = 0;
        for (int i = order.Count - 1; i >= 0; i--)
            if (labels[order[i]] < 0)
            {
                Mark(order[i]);
                component++;
            }
        return labels;
        void Visit(int v)
        {
            if (seen[v])
                return;
            seen[v] = true;
            foreach (int next in graph[v])
                Visit(next);
            order.Add(v);
        }
        void Mark(int v)
        {
            if (labels[v] >= 0)
                return;
            labels[v] = component;
            foreach (int next in reverse[v])
                Mark(next);
        }
        // O(V+E), память O(V+E), рекурсия до O(V).
    }
}
