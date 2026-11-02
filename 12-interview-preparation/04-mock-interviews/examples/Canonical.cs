namespace AlgoTraining.Topics.S12T04;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    public static bool IsSortedPermutation(int[] before, int[] after)
    {
        if (before.Length != after.Length)
            return false;
        for (int i = 1; i < after.Length; i++)
            if (after[i - 1] > after[i])
                return false;
        int[] expected = (int[])before.Clone();
        Array.Sort(expected);
        for (int i = 0; i < expected.Length; i++)
            if (expected[i] != after[i])
                return false;
        return true; // Проверяем и порядок, и состав. O(n log n), O(n).
    }
}
