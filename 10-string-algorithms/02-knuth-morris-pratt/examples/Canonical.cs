namespace AlgoTraining.Topics.S10T02;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    public static int[] Prefix(string pattern)
    {
        int[] prefix = new int[pattern.Length];
        for (int i = 1; i < pattern.Length; i++)
        {
            int length = prefix[i - 1];
            while (length > 0 && pattern[i] != pattern[length])
                length = prefix[length - 1];
            if (pattern[i] == pattern[length])
                length++;
            prefix[i] = length;
        }
        return prefix;
    }
    public static int[] Find(string text, string pattern)
    {
        if (pattern.Length == 0)
        {
            int[] all = new int[text.Length + 1];
            for (int i = 0; i < all.Length; i++)
                all[i] = i;
            return all;
        }
        int[] prefix = Prefix(pattern);
        List<int> result = new List<int>();
        int matched = 0;
        for (int i = 0; i < text.Length; i++)
        {
            while (matched > 0 && text[i] != pattern[matched])
                matched = prefix[matched - 1];
            if (text[i] == pattern[matched])
                matched++;
            if (matched == pattern.Length)
            {
                result.Add(i - pattern.Length + 1);
                matched = prefix[matched - 1];
            }
        }
        return result.ToArray(); // O(n+m), O(m) без ответа.
    }
}
