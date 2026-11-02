namespace AlgoTraining.Topics.S11T04;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public sealed class Modern
{
    private readonly Canonical tree;
    private readonly int[,] up;
    public Modern(int[] parents, int root = 0)
    {
        tree = new(parents, root);
        var levels = 1;
        while ((1L << levels) <= parents.Length)
            levels++;
        up = new int[parents.Length, levels];
        for (var v = 0; v < parents.Length; v++)
            up[v, 0] = parents[v];
        for (var j = 1; j < levels; j++)
            for (var v = 0; v < parents.Length; v++)
                up[v, j] = up[up[v, j - 1], j - 1];
    }
    public int Lca(int a, int b)
    {
        if (tree.Depth(a) < tree.Depth(b))
            (a, b) = (b, a);
        var difference = tree.Depth(a) - tree.Depth(b);
        for (var bit = 0; difference > 0; bit++, difference >>= 1)
            if ((difference & 1) != 0)
                a = up[a, bit];
        if (a == b)
            return a;
        for (var j = up.GetLength(1) - 1; j >= 0; j--)
            if (up[a, j] != up[b, j])
                (a, b) = (up[a, j], up[b, j]);
        return up[a, 0]; // O(log n), подготовка и память O(n log n).
    }
    public int Distance(int a, int b) => tree.Depth(a) + tree.Depth(b) - 2 * tree.Depth(Lca(a, b));
}
