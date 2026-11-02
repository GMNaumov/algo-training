namespace AlgoTraining.Topics.S00T01;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    // Инвариант: best — максимум уже просмотренной части. O(n), память O(1).
    public static int Maximum(int[] values)
    {
        if (values.Length == 0)
            throw new ArgumentException("Нужен хотя бы один элемент.");
        int best = values[0];
        for (int i = 1; i < values.Length; i++)
            if (values[i] > best)
                best = values[i];
        return best;
    }
}
