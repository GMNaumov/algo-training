namespace AlgoTraining.Topics.S07T07;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    public static (long Take, long Skip) Solve(Node node)
    {
        long take = node.Benefit, skip = 0;
        foreach (var child in node.Children)
        {
            var result = Solve(child);
            (take, skip) = (take + result.Skip, skip + Math.Max(result.Take, result.Skip));
        }
        return (take, skip);
    }
    public static int SubtreeSize(Node node) => 1 + node.Children.Sum(SubtreeSize);
}
