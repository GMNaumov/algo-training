namespace AlgoTraining.Topics.S01T06;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    // Эталон для маленьких входов. O(n²), O(1).
    public static bool HasDuplicates(int[] values)
    {
        for (int i = 0; i < values.Length; i++)
            for (int j = i + 1; j < values.Length; j++)
                if (values[i] == values[j])
                    return true;
        return false;
    }
}
