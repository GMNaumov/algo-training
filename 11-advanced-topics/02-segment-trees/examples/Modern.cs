namespace AlgoTraining.Topics.S11T02;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public sealed class Modern<T>
{
    private readonly T[] tree;
    private readonly T identity;
    private readonly Func<T, T, T> merge;
    private readonly int count;
    public Modern(ReadOnlySpan<T> values, T identity, Func<T, T, T> merge)
    {
        count = values.Length;
        this.identity = identity;
        this.merge = merge;
        tree = new T[Math.Max(2, checked(count * 2))];
        Array.Fill(tree, identity);
        values.CopyTo(tree.AsSpan(count));
        for (var i = count - 1; i > 0; i--)
            tree[i] = merge(tree[2 * i], tree[2 * i + 1]);
    }
    public T Query(Range range)
    {
        var (start, length) = range.GetOffsetAndLength(count);
        var left = start + count;
        var right = left + length;
        var before = identity;
        var after = identity;
        while (left < right)
        {
            if ((left & 1) != 0)
                before = merge(before, tree[left++]);
            if ((right & 1) != 0)
                after = merge(tree[--right], after);
            left /= 2;
            right /= 2;
        }
        return merge(before, after); // Два накопителя сохраняют порядок даже для конкатенации.
    }
    public void Set(int index, T value)
    {
        if ((uint)index >= (uint)count)
            throw new ArgumentOutOfRangeException(nameof(index));
        tree[index += count] = value;
        while ((index /= 2) > 0)
            tree[index] = merge(tree[2 * index], tree[2 * index + 1]);
    }
}
public sealed class LazySum
{
    private readonly long[] sums;
    private readonly long[] lazy;
    private readonly int count;
    public LazySum(int count)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(count);
        this.count = count;
        sums = new long[Math.Max(1, checked(4 * count))];
        lazy = new long[sums.Length];
    }
    public void Add(int left, int right, long delta)
    {
        Validate(left, right);
        if (left < right)
            Change(1, 0, count, left, right, delta);
    }
    public long Sum(int left, int right)
    {
        Validate(left, right);
        return left == right ? 0 : Read(1, 0, count, left, right);
    }
    private void Validate(int left, int right)
    {
        if (left < 0 || right < left || right > count)
            throw new ArgumentOutOfRangeException(nameof(left));
    }
    private void Apply(int node, int length, long delta)
    {
        sums[node] += length * delta;
        lazy[node] += delta;
    }
    private void Push(int node, int left, int right)
    {
        if (lazy[node] == 0 || right - left <= 1)
            return;
        var middle = left + (right - left) / 2;
        Apply(node * 2, middle - left, lazy[node]);
        Apply(node * 2 + 1, right - middle, lazy[node]);
        lazy[node] = 0;
    }
    private void Change(int node, int start, int end, int left, int right, long delta)
    {
        if (right <= start || end <= left)
            return;
        if (left <= start && end <= right)
        {
            Apply(node, end - start, delta);
            return;
        }
        Push(node, start, end);
        var middle = start + (end - start) / 2;
        Change(node * 2, start, middle, left, right, delta);
        Change(node * 2 + 1, middle, end, left, right, delta);
        sums[node] = sums[node * 2] + sums[node * 2 + 1];
    }
    private long Read(int node, int start, int end, int left, int right)
    {
        if (right <= start || end <= left)
            return 0;
        if (left <= start && end <= right)
            return sums[node];
        Push(node, start, end);
        var middle = start + (end - start) / 2;
        return Read(node * 2, start, middle, left, right) + Read(node * 2 + 1, middle, end, left, right);
    } // Прибавление диапазона и запрос суммы O(log n), память O(n).
}
