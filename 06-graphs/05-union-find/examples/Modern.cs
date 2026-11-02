namespace AlgoTraining.Topics.S06T05;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public sealed class Modern
{
    private readonly int[] parent;
    private readonly int[] sizes;
    public int Components
    {
        get; private set;
    }
    public Modern(int count)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(count);
        parent = Enumerable.Range(0, count).ToArray();
        sizes = Enumerable.Repeat(1, count).ToArray();
        Components = count;
    }
    public int Find(int value)
    {
        while (parent[value] != value)
        {
            parent[value] = parent[parent[value]];
            value = parent[value];
        }
        return value;
    }
    public bool Union(int a, int b)
    {
        (a, b) = (Find(a), Find(b));
        if (a == b)
            return false;
        if (sizes[a] < sizes[b])
            (a, b) = (b, a);
        parent[b] = a;
        sizes[a] += sizes[b];
        Components--;
        return true;
    }
    // Размеры + сжатие пути: амортизированное O(α(n)), память O(n).
}
