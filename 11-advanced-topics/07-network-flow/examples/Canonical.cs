namespace AlgoTraining.Topics.S11T07;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    public static long Maximum(int[,] capacity, int source, int sink)
    {
        int n = capacity.GetLength(0);
        if (n != capacity.GetLength(1) || source < 0 || sink < 0 || source >= n || sink >= n || source == sink)
            throw new ArgumentException("Неверная сеть.");
        long[,] residual = new long[n, n];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
            {
                if (capacity[i, j] < 0)
                    throw new ArgumentException("Отрицательная ёмкость.");
                residual[i, j] = capacity[i, j];
            }
        long total = 0;
        while (true)
        {
            bool[] seen = new bool[n];
            int[] parent = new int[n];
            if (!Find(source))
                break;
            long added = long.MaxValue;
            for (int v = sink; v != source; v = parent[v])
                added = Math.Min(added, residual[parent[v], v]);
            for (int v = sink; v != source; v = parent[v])
            {
                residual[parent[v], v] -= added;
                residual[v, parent[v]] += added;
            }
            total += added;
            bool Find(int v)
            {
                if (v == sink)
                    return true;
                seen[v] = true;
                for (int next = 0; next < n; next++)
                    if (!seen[next] && residual[v, next] > 0)
                    {
                        parent[next] = v;
                        if (Find(next))
                            return true;
                    }
                return false;
            }
        }
        return total; // Форд — Фалкерсон с матрицей: O(V² * (F+1)) при целых ёмкостях; память O(V²).
    }
}
