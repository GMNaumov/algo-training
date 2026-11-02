namespace AlgoTraining.Topics.S07T03;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    public static long Paths(bool[,] blocked)
    {
        int rows = blocked.GetLength(0);
        int columns = blocked.GetLength(1);
        if (rows == 0 || columns == 0)
            return 0;
        long[,] ways = new long[rows, columns];
        for (int r = 0; r < rows; r++)
            for (int c = 0; c < columns; c++)
            {
                if (blocked[r, c])
                    continue;
                if (r == 0 && c == 0)
                    ways[r, c] = 1;
                else
                    ways[r, c] = checked((r > 0 ? ways[r - 1, c] : 0) + (c > 0 ? ways[r, c - 1] : 0));
            }
        return ways[rows - 1, columns - 1]; // O(RC) времени и памяти.
    }
    public static long MinCost(int[,] cost)
    {
        int rows = cost.GetLength(0);
        int columns = cost.GetLength(1);
        if (rows == 0 || columns == 0)
            throw new ArgumentException("Пустая сетка.");
        long[,] best = new long[rows, columns];
        for (int r = 0; r < rows; r++)
            for (int c = 0; c < columns; c++)
            {
                if (r == 0 && c == 0)
                    best[r, c] = cost[r, c];
                else
                    best[r, c] = Math.Min(r > 0 ? best[r - 1, c] : long.MaxValue / 4, c > 0 ? best[r, c - 1] : long.MaxValue / 4) + cost[r, c];
            }
        return best[rows - 1, columns - 1]; // Стоимость стартовой клетки включена.
    }
}
