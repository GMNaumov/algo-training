namespace AlgoTraining.Topics.S11T01;

// Каноничная версия: явные типы и основные шаги без LINQ.
public sealed class Canonical
{
    private readonly long[] tree;
    public Canonical(int count)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(count);
        tree = new long[checked(count + 1)];
    }
    // Внешние индексы от 0, внутренние от 1. O(log n).
    public void Add(int index, long delta)
    {
        if (index < 0 || index >= tree.Length - 1)
            throw new ArgumentOutOfRangeException(nameof(index));
        for (int i = index + 1; i < tree.Length; i += i & -i)
            tree[i] += delta;
    }
    public long Prefix(int length)
    {
        if (length < 0 || length >= tree.Length)
            throw new ArgumentOutOfRangeException(nameof(length));
        long sum = 0;
        for (int i = length; i > 0; i -= i & -i)
            sum += tree[i];
        return sum;
    }
    public long Sum(int left, int right)
    {
        if (left > right)
            throw new ArgumentException("Перепутаны границы.");
        return Prefix(right) - Prefix(left);
    }
}
