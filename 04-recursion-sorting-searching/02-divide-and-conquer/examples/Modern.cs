namespace AlgoTraining.Topics.S04T02;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    public static int[] Sort(ReadOnlySpan<int> input)
    {
        var values = input.ToArray();
        SortPart(values.AsSpan());
        return values;
    }
    private static void SortPart(Span<int> values)
    {
        if (values.Length <= 1)
            return;
        var middle = values.Length / 2;
        SortPart(values[..middle]);
        SortPart(values[middle..]);
        // Срезы не копируют, но буфер каждого слияния выделяется отдельно.
        int[] merged = new int[values.Length];
        var i = 0;
        var j = middle;
        for (var k = 0; k < merged.Length; k++)
            merged[k] = j == values.Length || (i < middle && values[i] <= values[j]) ? values[i++] : values[j++];
        merged.AsSpan().CopyTo(values);
        // Пиковая дополнительная память O(n); суммарные выделения O(n log n).
    }
}
