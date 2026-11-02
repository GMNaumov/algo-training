namespace AlgoTraining.Topics.S13T04;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    public static bool IsSubsequence(string needle, string text)
    {
        int matched = 0;
        for (int i = 0; i < text.Length && matched < needle.Length; i++)
            if (text[i] == needle[matched])
                matched++;
        return matched == needle.Length; // O(n+m), O(1); пропуски в text допустимы.
    }
}
