namespace AlgoTraining.Topics.S11T03;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public sealed class Modern
{
    private readonly int[] values; private readonly int[] minima; private readonly int block;
    public Modern(ReadOnlySpan<int> source)
    {
        values = source.ToArray();
        block = Math.Max(1, (int)Math.Sqrt(values.Length));
        minima = values.Chunk(block).Select(chunk => chunk.Min()).ToArray();
    }
    public void Set(int index, int value)
    {
        if ((uint)index >= (uint)values.Length)
            throw new ArgumentOutOfRangeException(nameof(index));
        values[index] = value;
        var group = index / block;
        var best = int.MaxValue;
        foreach (var item in values.AsSpan(group * block, Math.Min(block, values.Length - group * block)))
            best = Math.Min(best, item);
        minima[group] = best; // Минимум не обратим: пересчитываем блок за O(sqrt n).
    }
    public int Minimum(Range range)
    {
        var (left, length) = range.GetOffsetAndLength(values.Length);
        var right = left + length;
        var best = int.MaxValue;
        while (left < right)
            if (left % block == 0 && right - left >= block)
            {
                best = Math.Min(best, minima[left / block]);
                left += block;
            }
            else
                best = Math.Min(best, values[left++]);
        return best; // Для пустого диапазона возвращается нейтральное int.MaxValue.
    }
}
