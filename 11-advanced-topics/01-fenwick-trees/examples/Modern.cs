namespace AlgoTraining.Topics.S11T01;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public sealed class Modern<T> where T : INumber<T>
{
    private readonly T[] tree;
    public Modern(int count)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(count);
        tree = new T[checked(count + 1)];
        Array.Fill(tree, T.Zero);
    }
    public void Add(int index, T delta)
    {
        if ((uint)index >= (uint)(tree.Length - 1))
            throw new ArgumentOutOfRangeException(nameof(index));
        for (var i = index + 1; i < tree.Length; i += i & -i)
            tree[i] += delta;
    }
    public T Prefix(int length)
    {
        if ((uint)length >= (uint)tree.Length)
            throw new ArgumentOutOfRangeException(nameof(length));
        var sum = T.Zero;
        for (var i = length; i > 0; i -= i & -i)
            sum += tree[i];
        return sum; // Generic math: long, decimal, BigInteger; стоимость арифметики зависит от типа.
    }
}
