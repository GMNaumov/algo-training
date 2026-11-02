namespace AlgoTraining.Topics.S10T01;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    public static int[] Find(ReadOnlySpan<char> text, ReadOnlySpan<char> pattern)
    {
        if (pattern.IsEmpty)
            return Enumerable.Range(0, text.Length + 1).ToArray();
        List<int> starts = [];
        var offset = 0;
        while (offset <= text.Length - pattern.Length)
        {
            var relative = text[offset..].IndexOf(pattern);
            if (relative < 0)
                break;
            starts.Add(offset + relative);
            offset += relative + 1; // +1 сохраняет перекрытия.
        }
        return [.. starts]; // Срезы без копий. Производительность поиска зависит от реализации .NET.
    }
}
