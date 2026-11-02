namespace AlgoTraining.Topics.S10T01;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    public static int[] Find(string text, string pattern)
    {
        List<int> starts = new List<int>();
        for (int start = 0; start <= text.Length - pattern.Length; start++)
        {
            int matched = 0;
            while (matched < pattern.Length && text[start + matched] == pattern[matched])
                matched++;
            if (matched == pattern.Length)
                starts.Add(start);
        }
        return starts.ToArray(); // O(nm), память ответа O(k). Пустой образец: n+1 границ.
    }
}
