namespace AlgoTraining.Topics.S07T07;

// Каноничная версия: явные типы и основные шаги без LINQ.
public sealed class Node
{
    public int Benefit; public Node[] Children;
    public Node(int benefit, params Node[] children)
    {
        Benefit = benefit;
        Children = children;
    }
}
public static class Canonical
{
    public static long Best(Node root)
    {
        long take;
        long skip;
        Solve(root, out take, out skip);
        return Math.Max(take, skip);
    }
    private static void Solve(Node node, out long take, out long skip)
    {
        take = node.Benefit;
        skip = 0;
        for (int i = 0; i < node.Children.Length; i++)
        {
            long childTake;
            long childSkip;
            Solve(node.Children[i], out childTake, out childSkip);
            take += childSkip;
            skip += Math.Max(childTake, childSkip);
        }
    } // O(n), стек O(h). Вход — дерево, пустой выбор разрешён.
}
