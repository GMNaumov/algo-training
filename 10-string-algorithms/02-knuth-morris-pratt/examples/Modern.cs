namespace AlgoTraining.Topics.S10T02;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    // Итератор отдаёт позиции по одной. Префиксная таблица общая с каноничным вариантом.
    public static IEnumerable<int> Find(string text, string pattern)
    {
        if (pattern.Length == 0)
        {
            for (var i = 0; i <= text.Length; i++)
                yield return i;
            yield break;
        }
        var prefix = Canonical.Prefix(pattern);
        var matched = 0;
        for (var i = 0; i < text.Length; i++)
        {
            while (matched > 0 && text[i] != pattern[matched])
                matched = prefix[matched - 1];
            if (text[i] == pattern[matched])
                matched++;
            if (matched != pattern.Length)
                continue;
            yield return i - pattern.Length + 1;
            matched = prefix[matched - 1];
        }
    }
}
