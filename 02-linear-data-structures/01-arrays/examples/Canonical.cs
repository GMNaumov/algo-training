namespace AlgoTraining.Topics.S02T01;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    // Новый массив сохраняет вход. O(n) времени и памяти.
    public static int[] Insert(int[] values, int index, int value)
    {
        if (index < 0 || index > values.Length)
            throw new ArgumentOutOfRangeException(nameof(index));
        int[] result = new int[values.Length + 1];
        for (int i = 0; i < index; i++)
            result[i] = values[i];
        result[index] = value;
        for (int i = index; i < values.Length; i++)
            result[i + 1] = values[i];
        return result;
    }
    public static int[] Remove(int[] values, int index)
    {
        if (index < 0 || index >= values.Length)
            throw new ArgumentOutOfRangeException(nameof(index));
        int[] result = new int[values.Length - 1];
        for (int i = 0; i < result.Length; i++)
            result[i] = values[i < index ? i : i + 1];
        return result;
    }
}
