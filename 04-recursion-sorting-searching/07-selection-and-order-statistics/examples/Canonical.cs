namespace AlgoTraining.Topics.S04T07;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    public static int Select(int[] input, int rank)
    {
        if (rank < 1 || rank > input.Length)
            throw new ArgumentOutOfRangeException(nameof(rank));
        int[] values = (int[])input.Clone();
        Array.Sort(values);
        return values[rank - 1];
        // Простой эталон O(n log n), O(n) памяти; ранги от 1, повторы учитываются.
    }
}
