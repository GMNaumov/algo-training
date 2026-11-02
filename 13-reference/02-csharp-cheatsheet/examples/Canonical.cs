namespace AlgoTraining.Topics.S13T02;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    public static long Sum(int[] values)
    {
        long result = 0;
        for (int i = 0; i < values.Length; i++)
            result = checked(result + values[i]);
        return result;
    }
    public static int[] Copy(int[] values)
    {
        int[] copy = new int[values.Length];
        for (int i = 0; i < values.Length; i++)
            copy[i] = values[i];
        return copy;
    }
}
