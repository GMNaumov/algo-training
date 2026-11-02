namespace AlgoTraining.Topics.S03T04;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    public static long[] Prefix(int[] values)
    {
        long[] prefix = new long[values.Length + 1];
        for (int i = 0; i < values.Length; i++)
            prefix[i + 1] = prefix[i] + values[i];
        return prefix; // O(n) подготовка; [l,r) = prefix[r] - prefix[l].
    }
    public static long[] AddRanges(int size, int[,] updates)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(size);
        long[] differences = new long[size + 1];
        for (int i = 0; i < updates.GetLength(0); i++)
        {
            int left = updates[i, 0];
            int right = updates[i, 1];
            int delta = updates[i, 2];
            if (left < 0 || right < left || right > size)
                throw new ArgumentOutOfRangeException(nameof(updates));
            differences[left] += delta;
            differences[right] -= delta;
        }
        long[] result = new long[size];
        long running = 0;
        for (int i = 0; i < size; i++)
        {
            running += differences[i];
            result[i] = running;
        }
        return result; // O(n+q) времени, O(n) памяти.
    }
}
