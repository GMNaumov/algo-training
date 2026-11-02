namespace AlgoTraining.Topics.S07T04;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    public static long ZeroOne(int[] weights, int[] benefits, int capacity)
    {
        Validate(weights, benefits, capacity);
        long[,] best = new long[weights.Length + 1, capacity + 1];
        for (int i = 1; i <= weights.Length; i++)
            for (int c = 0; c <= capacity; c++)
            {
                best[i, c] = best[i - 1, c];
                if (weights[i - 1] <= c)
                    best[i, c] = Math.Max(best[i, c], best[i - 1, c - weights[i - 1]] + benefits[i - 1]);
            }
        return best[weights.Length, capacity]; // O(nW) времени и памяти, вес не больше W.
    }
    public static long Unlimited(int[] weights, int[] benefits, int capacity)
    {
        Validate(weights, benefits, capacity);
        long[] best = new long[capacity + 1];
        for (int c = 1; c <= capacity; c++)
            for (int i = 0; i < weights.Length; i++)
                if (weights[i] <= c)
                    best[c] = Math.Max(best[c], best[c - weights[i]] + benefits[i]);
        return best[capacity]; // O(nW), O(W). Повторный выбор разрешён.
    }
    public static void Validate(int[] weights, int[] benefits, int capacity)
    {
        if (capacity < 0 || weights.Length != benefits.Length)
            throw new ArgumentException("Неверные размеры.");
        for (int i = 0; i < weights.Length; i++)
            if (weights[i] <= 0)
                throw new ArgumentException("Нужны положительные веса.");
    }
}
