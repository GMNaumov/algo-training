namespace AlgoTraining.Topics.S07T05;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    public static int Lcs(string a, string b)
    {
        int[,] best = new int[a.Length + 1, b.Length + 1];
        for (int i = 1; i <= a.Length; i++)
            for (int j = 1; j <= b.Length; j++)
                best[i, j] = a[i - 1] == b[j - 1] ? best[i - 1, j - 1] + 1 : Math.Max(best[i - 1, j], best[i, j - 1]);
        return best[a.Length, b.Length]; // O(nm) времени и памяти.
    }
    public static int EditDistance(string a, string b)
    {
        int[,] distance = new int[a.Length + 1, b.Length + 1];
        for (int i = 0; i <= a.Length; i++)
            distance[i, 0] = i;
        for (int j = 0; j <= b.Length; j++)
            distance[0, j] = j;
        for (int i = 1; i <= a.Length; i++)
            for (int j = 1; j <= b.Length; j++)
                distance[i, j] = Math.Min(Math.Min(distance[i - 1, j] + 1, distance[i, j - 1] + 1), distance[i - 1, j - 1] + (a[i - 1] == b[j - 1] ? 0 : 1));
        return distance[a.Length, b.Length];
    }
    public static int Lis(int[] values)
    {
        int[] length = new int[values.Length];
        int best = 0;
        for (int i = 0; i < values.Length; i++)
        {
            length[i] = 1;
            for (int j = 0; j < i; j++)
                if (values[j] < values[i])
                    length[i] = Math.Max(length[i], length[j] + 1);
            best = Math.Max(best, length[i]);
        }
        return best; // O(n²), O(n); строго возрастающая подпоследовательность.
    }
}
