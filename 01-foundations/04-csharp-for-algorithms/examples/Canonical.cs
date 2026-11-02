namespace AlgoTraining.Topics.S01T04;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    public static long Sum(int[] receipts)
    {
        long total = 0; // Преобразование в long выполняется до возможного переполнения.
        for (int i = 0; i < receipts.Length; i++)
            total = checked(total + receipts[i]);
        return total; // O(n), O(1).
    }
    public static int Remainder(int value, int modulus)
    {
        if (modulus <= 0)
            throw new ArgumentOutOfRangeException(nameof(modulus));
        int result = value % modulus;
        if (result < 0)
            result += modulus;
        return result;
    }
}
