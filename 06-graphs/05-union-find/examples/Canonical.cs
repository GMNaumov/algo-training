namespace AlgoTraining.Topics.S06T05;

// Каноничная версия: явные типы и основные шаги без LINQ.
public sealed class Canonical
{
    private readonly int[] parent;
    public Canonical(int size)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(size);
        parent = new int[size];
        for (int i = 0; i < size; i++)
            parent[i] = i;
    }
    public int Find(int value)
    {
        while (parent[value] != value)
            value = parent[value];
        return value;
    }
    public bool Union(int a, int b)
    {
        int first = Find(a);
        int second = Find(b);
        if (first == second)
            return false;
        parent[second] = first;
        return true;
    }
    // Без оптимизаций возможна цепочка: O(n) на Find, O(n) хранения.
}
