namespace AlgoTraining.Topics.S02T01;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    public static int[] Insert(ReadOnlySpan<int> values, int index, int value)
    {
        if ((uint)index > (uint)values.Length)
            throw new ArgumentOutOfRangeException(nameof(index));
        // Collection expression создаёт копию; spread не делает вставку бесплатной.
        return [.. values[..index], value, .. values[index..]];
    }
}
