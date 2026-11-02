namespace AlgoTraining.Topics.S11T04;

// Каноничная версия: явные типы и основные шаги без LINQ.
public sealed class Canonical
{
    private readonly int[] parents;
    private readonly int[] depth;
    public int Count
    {
        get
        {
            return parents.Length;
        }
    }
    public int Parent(int vertex)
    {
        return parents[vertex];
    }
    public int Depth(int vertex)
    {
        return depth[vertex];
    }
    public Canonical(int[] parent, int root = 0)
    {
        if (root < 0 || root >= parent.Length || parent[root] != root)
            throw new ArgumentException("Корень ссылается на себя.");
        parents = (int[])parent.Clone();
        depth = new int[parent.Length];
        Array.Fill(depth, -1);
        List<int>[] children = new List<int>[parent.Length];
        for (int i = 0; i < parent.Length; i++)
            children[i] = new List<int>();
        for (int i = 0; i < parent.Length; i++)
        {
            if (parent[i] < 0 || parent[i] >= parent.Length)
                throw new ArgumentException("Неизвестный родитель.");
            if (i != root)
                children[parent[i]].Add(i);
        }
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(root);
        depth[root] = 0;
        while (queue.Count > 0)
        {
            int v = queue.Dequeue();
            foreach (int child in children[v])
            {
                depth[child] = depth[v] + 1;
                queue.Enqueue(child);
            }
        }
        for (int i = 0; i < depth.Length; i++)
            if (depth[i] < 0)
                throw new ArgumentException("Вход не является одним деревом.");
    }
    public int Lca(int a, int b)
    {
        while (depth[a] > depth[b])
            a = parents[a];
        while (depth[b] > depth[a])
            b = parents[b];
        while (a != b)
        {
            a = parents[a];
            b = parents[b];
        }
        return a; // O(h), подготовка O(n).
    }
}
