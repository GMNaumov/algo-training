namespace AlgoTraining.Topics.S03T07;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    // Простой эталон: сортируем копию. O(n log n), O(n).
    public static int[] Largest(int[] values, int k)
    {
        if (k < 0 || k > values.Length)
            throw new ArgumentOutOfRangeException(nameof(k));
        int[] copy = (int[])values.Clone();
        Array.Sort(copy);
        int[] result = new int[k];
        for (int i = 0; i < k; i++)
            result[i] = copy[copy.Length - k + i];
        return result;
    }
    public static int[] Merge(int[][] sources)
    {
        int[] positions = new int[sources.Length];
        List<int> result = new List<int>();
        while (true)
        {
            int selected = -1;
            for (int i = 0; i < sources.Length; i++)
                if (positions[i] < sources[i].Length && (selected < 0 || sources[i][positions[i]] < sources[selected][positions[selected]]))
                    selected = i;
            if (selected < 0)
                break;
            result.Add(sources[selected][positions[selected]++]);
        }
        return result.ToArray(); // O(Nk), память O(k) без ответа. Источники отсортированы.
    }
}
