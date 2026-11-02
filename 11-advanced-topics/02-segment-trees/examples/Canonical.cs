namespace AlgoTraining.Topics.S11T02;

// Каноничная версия: явные типы и основные шаги без LINQ.
public sealed class Canonical
{
    private readonly long[] tree;
    private readonly int count;
    public Canonical(int[] values)
    {
        count = values.Length;
        tree = new long[Math.Max(1, checked(count * 4))];
        if (count > 0)
            Build(1, 0, count, values);
    }
    private void Build(int node, int left, int right, int[] values)
    {
        if (right - left == 1)
        {
            tree[node] = values[left];
            return;
        }
        int middle = left + (right - left) / 2;
        Build(node * 2, left, middle, values);
        Build(node * 2 + 1, middle, right, values);
        tree[node] = tree[node * 2] + tree[node * 2 + 1];
    }
    public long Sum(int left, int right)
    {
        if (left < 0 || right < left || right > count)
            throw new ArgumentOutOfRangeException(nameof(left));
        if (left == right)
            return 0;
        return Query(1, 0, count, left, right);
    }
    private long Query(int node, int start, int end, int left, int right)
    {
        if (right <= start || end <= left)
            return 0;
        if (left <= start && end <= right)
            return tree[node];
        int middle = start + (end - start) / 2;
        return Query(node * 2, start, middle, left, right) + Query(node * 2 + 1, middle, end, left, right);
    }
    public void Set(int index, long value)
    {
        if (index < 0 || index >= count)
            throw new ArgumentOutOfRangeException(nameof(index));
        Update(1, 0, count, index, value);
    }
    private void Update(int node, int left, int right, int index, long value)
    {
        if (right - left == 1)
        {
            tree[node] = value;
            return;
        }
        int middle = left + (right - left) / 2;
        if (index < middle)
            Update(node * 2, left, middle, index, value);
        else
            Update(node * 2 + 1, middle, right, index, value);
        tree[node] = tree[node * 2] + tree[node * 2 + 1];
    } // Построение/память O(n), запрос/изменение O(log n).
}
