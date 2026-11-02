namespace AlgoTraining.Topics.S13T04;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    public static bool IsSubsequence<T>(ReadOnlySpan<T> needle, ReadOnlySpan<T> text) where T : IEquatable<T>
    {
        var matched = 0;
        foreach (var value in text)
            if (matched < needle.Length && value.Equals(needle[matched]))
                matched++;
        return matched == needle.Length;
    }
}
